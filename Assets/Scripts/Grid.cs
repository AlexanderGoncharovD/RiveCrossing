using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PLExternal.Enums;
using PLExternal.Helper;
using PLExternal.Level;
using UnityEngine;

public class Grid
{
	#region Private Fileds

	private int _row = 7;
	private int _col = 5;
	private float _step = 1.0f;
	private GameObject _pointModel;
	private GameObject _platformModel;

	/// <summary>
	///		Карта точек уровня
	/// </summary>
	private IEnumerable<string> _map;
	private List<string> _solution;
	private IEnumerable<IEnumerable<string>> _platforms;
	private List<GameObject> _points = new List<GameObject>();
	private Point _startpoint;
	private Point _finishpoint;
	private GameControl _gameControl;

    #endregion

	#region Properties

	/// <summary>
	///		Количество строк на игровом поле
	/// </summary>
	public int Rows => _row;

	/// <summary>
	///		Количество колонок на игровом поле
	/// </summary>
	public int Columns => _col;

	/// <summary>
	///		Шаг игровой сетки
	/// </summary>
	public float Step => _step;

	public Point StartPoint => _startpoint;
	public Point FinishPoint => _finishpoint;

	/// <summary>
	///		Длины платформ на уровне
	/// </summary>
	public List<int> PlatformLengths { get; private set; }

	#endregion

	#region .ctor

	public Grid(GameObject pointModel, GameObject platformModel, IEnumerable<string> map, IEnumerable<string> solution, IEnumerable<IEnumerable<string>> platforms)
	{
		_gameControl = Camera.main.GetComponent<GameControl>();
		_pointModel = pointModel;
		_platformModel = platformModel;
        _map = map;
		_solution = solution.ToList();
        _platforms = platforms;
		
        PlatformLengths = PlatformHelper.GetPlatformLengths(_platforms);
		GenerationGrid();
	}

    #endregion

	#region Private Methods

	/// <summary>
	///		Создать сетку из модели игровой точки
	/// </summary>
	private void GenerationGrid()
	{
		if (!_map.Any())
			throw new System.Exception($"{nameof(_map)} is null");

		var position = new Vector3(-2.0f, 3.0f, 0.0f);

		/*
		 * Карта генерируется сверху вниз - слева направо. А уровень идёт снизу вверху
		 */

		for (var r = 0; r < _row; r++)
		{
			for (var c = 0; c < _col; c++)
			{
				if (_map.Any(e => e.Equals($"{r}-{c}")))
				{
					var point = MonoBehaviour.Instantiate(_pointModel, position, Quaternion.Euler(90, 0, 0));
					point.name = $"{r}-{c}";
					var component = point.GetComponent<Point>();
					component.Column = c;
					component.Row = r;
					_points.Add(point);
					_gameControl.pointsColliders.Add(point.GetComponent<CapsuleCollider>());

				}
				position += new Vector3(1, 0, 0);
			}
			position = new Vector3(-2, position.y - 1, 0);
		}

		_startpoint = _points.Last().GetComponent<Point>();
		_startpoint.Type = PointType.Start;

		_finishpoint = _points.First().GetComponent<Point>();
		_finishpoint.Type = PointType.Finish;

		SetNextBackPoints();
		SetOthersPoints();
		_points.ForEach(p => p.GetComponent<Point>().GenerateTriggers());
		GenerationPlatforms();
	}

	/// <summary>
	///		Назначить следующую и предыдущую точку
	/// </summary>
	private void SetNextBackPoints()
	{
		foreach (var name in _solution)
		{
			var index = _solution.IndexOf(name);
			var point = _points.First(p => p.name.Equals(name));
			var component = point.GetComponent<Point>();

			if (index != _solution.Count-1)
				component.NextPoint = _points.First(p => p.name.Equals(_solution[index + 1])).transform;

			if (index != 0)
				component.BackPoint = _points.First(p => p.name.Equals(_solution[index - 1])).transform;
		}
	}

	/// <summary>
	///		Установить побочные точки
	/// </summary>
	private void SetOthersPoints()
	{
		for (var r = 0; r < _row; r++)
		{
			for (var c = 0; c < _col; c++)
			{
				var point = _points.FirstOrDefault(p => p.name.Equals($"{r}-{c}"));
				if (point != null)
				{
					point.GetComponent<Point>().OtherPoints = GetOtherPoints(point, r, c).Select(p => p.transform).ToList();
				}
			}
		}
	}

	/// <summary>
	///		Генерировать начальные платформы
	/// </summary>
	private void GenerationPlatforms()
	{
		foreach (var item in _platforms)
		{
			var onePoint = _points.First(p => p.name.Equals(item.First())).transform;
			var twoPoint = _points.First(p => p.name.Equals(item.Last())).transform;
			var center = (onePoint.position + twoPoint.position) / 2.0f;
			var length = Vector3.Distance(onePoint.position, twoPoint.position);
			var isVertical = onePoint.position.y == twoPoint.position.y;

			var platform = MonoBehaviour.Instantiate(_platformModel, center, Quaternion.Euler(0, 0, isVertical ? 90 : 0));
			platform.GetComponent<BoxCollider>().size = new Vector3(0.5f, length, 0.5f);
			platform.GetComponent<TouchPlatform>().Points.SetPoints(onePoint, twoPoint);
			_gameControl.Platforms.Add(platform.GetComponent<TouchPlatform>().Points);
		}
	}

	/// <summary>
	///		Задаёт побочные точки
	/// </summary>
	/// <param name="basePoint">Точка для которой ищутся побочные</param>
	private List<GameObject> GetOtherPoints(GameObject basePoint, int row, int col)
	{
		var result = new List<GameObject>();
		var otherPoints = _points.Where(p => p.transform != basePoint.transform);
		var component = basePoint.GetComponent<Point>();

		// Если у точки нет ни следующей ни придыдущей точки, занчит она побочная
		if (component.NextPoint == null && component.BackPoint == null)
		{
			component.Type = PointType.Side;
		}

		for (int i = row-1; i > 0; i--)
		{
			var po = otherPoints.FirstOrDefault(p => p.name.Equals($"{i}-{col}"));
            CheckAndAddPoint(po);
		}
		for (int i = row + 1; i < 6; i++)
		{
			var po = otherPoints.FirstOrDefault(p => p.name.Equals($"{i}-{col}"));
            CheckAndAddPoint(po);
		}

		for (int i = col - 1; i > 0; i--)
		{
			var po = otherPoints.FirstOrDefault(p => p.name.Equals($"{row}-{i}"));
            CheckAndAddPoint(po);
		}
		for (int i = col + 1; i < 6; i++)
		{
			var po = otherPoints.FirstOrDefault(p => p.name.Equals($"{row}-{i}"));
            CheckAndAddPoint(po);
        }
		return result;


        void CheckAndAddPoint(GameObject point)
        {
            if (point == null)
            {
				return;
            }

            if (point.transform == component.NextPoint || point.transform == component.BackPoint)
            {
				return;
            }

            if(Mathf.CeilToInt(Vector3.Distance(basePoint.transform.position, point.transform.position)) <= PlatformLengths.Max())
            {
                result.Add(point);
			}
        }
	}

    #endregion
}
