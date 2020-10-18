using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Point : MonoBehaviour
{
	#region Private Fields

	private Transform _nextPoint;

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

	/// <summary>
	///		Длинная до NextPoint
	/// </summary>
	public int Length => Mathf.CeilToInt(_lengthWay);

	#endregion

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
	private void CreateTrigger(Transform point, bool isSide = false)
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
		trigger.GetComponent<Trigger>().length = (int)length;
		trigger.GetComponent<Trigger>().Points.SetPoints(point, transform);
	}

	#endregion

	#region Public Methods

	/// <summary>
	///		Генерировать блоки для установки платформ
	/// </summary>
	public void GenerateTriggers()
	{
		if (NextPoint != null)
		{
			CreateTrigger(NextPoint);
		}

		if (OtherPoints.Any())
		{
			foreach (var otherPoint in OtherPoints)
			{
				CreateTrigger(otherPoint, true);
			}
		}
	}

	#endregion
}
