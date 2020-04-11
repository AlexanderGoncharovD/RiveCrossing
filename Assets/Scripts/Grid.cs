﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid
{
	#region Private Fileds

	private int _row = 7;
	private int _col = 5;
	private float _step = 1.0f;
	private GameObject _pointModel;
	/// <summary>
	///		Карта точек уровня
	/// </summary>
	private List<string> _map;
	private List<string> _solution;
	private List<GameObject> _points = new List<GameObject>();


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

	#endregion

	#region .ctor

	public Grid(GameObject pointModel, string map, string solution)
	{
		_pointModel = pointModel;
		_map = map.Split(';').ToList();
		_solution = solution.Split(';').ToList();
		GenerationGrid();
	}

	public Grid(int row, int col, float step, GameObject pointModel)
	{
		_row = row;
		_col = col;
		_step = step;
		_pointModel = pointModel;
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

				}
				position += new Vector3(1, 0, 0);
			}
			position = new Vector3(-2, position.y - 1, 0);
		}

		SetNextBackPoints();
		SetOthersPoints();
		_points.ForEach(p => p.GetComponent<Point>().GenerateTriggers());
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

	private List<GameObject> GetOtherPoints(GameObject point, int row, int col)
	{
		var result = new List<GameObject>();
		var horizontalPoints = _points.Where(p => p.transform != point.transform);

		// Если у точки нет ни следующей ни придыдущей точки, занчит она побочная
		if (point.GetComponent<Point>().NextPoint == null && point.GetComponent<Point>().BackPoint == null)
		{
			point.GetComponent<Point>().Type = PointType.Side;
			return result;
		}

		for (int i = row-1; i > 0; i--)
		{
			var po = horizontalPoints.FirstOrDefault(p => p.name.Equals($"{i}-{col}"));
			if (po != null)
			{
				if (po.transform == point.GetComponent<Point>().NextPoint)
					break;
				if (po.transform == point.GetComponent<Point>().BackPoint)
					break;
				result.Add(po); 
				break;
			}
		}
		for (int i = row + 1; i < 6; i++)
		{
			var po = horizontalPoints.FirstOrDefault(p => p.name.Equals($"{i}-{col}"));
			if (po != null)
			{

				if (po.transform == point.GetComponent<Point>().NextPoint)
					break;
				if (po.transform == point.GetComponent<Point>().BackPoint)
					break;
				result.Add(po);
				break;
			}
		}

		for (int i = col - 1; i > 0; i--)
		{
			var po = horizontalPoints.FirstOrDefault(p => p.name.Equals($"{row}-{i}"));
			if (po != null)
			{

				if (po.transform == point.GetComponent<Point>().NextPoint)
					break;
				if (po.transform == point.GetComponent<Point>().BackPoint)
					break;
				result.Add(po);
				break;
			}
		}
		for (int i = col + 1; i < 6; i++)
		{
			var po = horizontalPoints.FirstOrDefault(p => p.name.Equals($"{row}-{i}"));
			if (po != null)
			{

				if (po.transform == point.GetComponent<Point>().NextPoint)
					break;
				if (po.transform == point.GetComponent<Point>().BackPoint)
					break;
				result.Add(po);
				break;
			}
		}
		return result;

	}

	#endregion
}
