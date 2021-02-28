using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PLExternal.Enums;
using PLExternal.Level;
using PLExternal.Map;
using UnityEngine;

public class Point : MonoBehaviour
{
	#region Private Fields

    private LevelPoint _levelPoint;

	private Transform _nextPoint;
    private GameControl _gameControl;
    private Camera _camera;

	/// <summary>
	///		Блок установки платформы
	/// </summary>
	[SerializeField]
	private GameObject _trigger;

	/// <summary>
	///		Длина пути до следующей верной точки
	/// </summary>
	private float _lengthWay;


    [SerializeField]
	private Sprite _iceFloeStartFinishSprite;

	#endregion

	#region Properties

	/// <summary>
	///		Тип чтоки
	/// </summary>
	[SerializeField]
	public PointType Type { get; set; } = PointType.Side;

	/// <summary>
	///		Следующая точка для прохождения уровня
	/// </summary>
	public Transform NextPoint
	{
		get => _nextPoint;
		set
		{
			_nextPoint = value;
			_lengthWay = Vector3.Distance(transform.position, NextPoint.position);
		}
	}

	/// <summary>
	///		Предыдущая точка для возвращения к началу
	/// </summary>
	public Transform BackPoint { get; set; }

	/// <summary>
	///		Побочные точки, по которым нельзя пройти или вернуться для успешного прохождения уровня
	/// </summary>
	public List<Transform> OtherPoints { get; set; } = new List<Transform>();

	/// <summary>
	///		Номер колонки точки
	/// </summary>
	public int Column { get; set; }

	/// <summary>
	///		Номер строки точки
	/// </summary>
	public int Row { get; set; }

    public LevelPoint LevelPoint => _levelPoint;

	/// <summary>
	///		Длинная до NextPoint
	/// </summary>
	public int Length => Mathf.CeilToInt(_lengthWay);

	#endregion

    public static GameObject Initialize(GameObject model, Vector3 position, Quaternion rotation, int row, int col)
    {
        var point = MonoBehaviour.Instantiate(model, position, rotation);
        point.name = $"{row}-{col}";
        var component = point.GetComponent<Point>();
        component.Column = col;
        component.Row = row;
		component._levelPoint = new LevelPoint(row, col);
		component.Instantiate();

        return point;
    }

    public void Instantiate()
    {
        _camera = Camera.main;
        _gameControl = _camera.GetComponent<GameControl>();
        _gameControl.LevelPoints[transform] = _levelPoint;
    }

	#region Private Methods

	private void Start()
	{
        var spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
		switch (Type)
        {
			case PointType.Side:
			case PointType.Default:
		        //transform.rotation = Quaternion.Euler(Random.Range(0, 360), 90, 90);
                break;
			case PointType.Finish:
                spriteRenderer.sprite = _iceFloeStartFinishSprite;
				break;
            case PointType.Start:
                spriteRenderer.flipX = true;
                spriteRenderer.flipY = true;
                spriteRenderer.sprite = _iceFloeStartFinishSprite;
                break;
		}
	}

	private void Update()
	{
		DebugingUpdate();

		
	}
	
	/// <summary>
	///		Выполняется при отладке приложения. Обновляется каждый кадр
	/// </summary>
	private void DebugingUpdate()
	{
		if (AppDebug.IsDebug)
		{
			if (NextPoint != null)
			{
				Debug.DrawLine(transform.position, NextPoint.position, Color.white);
			}
		}
	}

	/// <summary>
	///		Создать Триггер для перемещения
	/// </summary>
	/// <param name="point">
	///		Позиция точки
	/// </param>
	/// <param name="isSide">
	///		Является ли точка побочной
	/// </param>
	private TriggerModel CreateTrigger(Transform point, bool isSide = false)
	{
		var center = (point.position + transform.position) / 2.0f;
		var isVertical = point.position.y == transform.position.y;
		var trigger = Instantiate(_trigger, center, Quaternion.Euler(0, 0, isVertical ? 90 : 0));
		var length = _lengthWay;

		if (isSide)
		{
			length = Vector3.Distance(transform.position, point.position);
		}

		trigger.GetComponent<BoxCollider>().size = new Vector3(1.0f, length, 0.25f);
        var triggerComponent = trigger.GetComponent<Trigger>();
        triggerComponent.length = (int)length;
        triggerComponent.Platform = new Platform(point, transform);

        return new TriggerModel(trigger, triggerComponent);
    }

	#endregion

	#region Public Methods

	/// <summary>
	///		Генерировать блоки для установки платформ
	/// </summary>
	public IEnumerable<TriggerModel> GenerateTriggers(Grid grid)
	{
		var triggerModel = new List<TriggerModel>();
		if (NextPoint != null)
        {
			var component = NextPoint.GetComponent<Point>();
			if (TryCreate(NextPoint, component, false, out var trigger))
            {
                triggerModel.Add(trigger);
            }
		}

		if (OtherPoints.Any())
		{
			foreach (var otherPoint in OtherPoints)
			{
				var component = otherPoint.GetComponent<Point>();
                if (TryCreate(otherPoint, component, true, out var trigger))
                {
                    triggerModel.Add(trigger);
                }
            }
		}

        return triggerModel;

        bool TryCreate(Transform pointTransform, Point point, bool isSide, out TriggerModel trigger)
        {
            if (!grid.TriggerLinkMap.ContainsKey($"{Row}-{Column};{point.Row}-{point.Column}")
                && !grid.TriggerLinkMap.ContainsKey(
                    $"{point.Row}-{point.Column};{Row}-{Column}"))
            {
                trigger = CreateTrigger(pointTransform, isSide);
                grid.TriggerLinkMap[$"{Row}-{Column};{point.Row}-{point.Column}"] = trigger;
                return true;
            }
			trigger = TriggerModel.Empty();
            return false;
        }
	}

	#endregion
}
