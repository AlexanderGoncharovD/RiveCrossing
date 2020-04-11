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

	public int Column { get; set; }
	public int Row { get; set; }

	#endregion

	#region Private Methods

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

	#endregion

	#region Public Methods

	/// <summary>
	///		Генерировать блоки для установки платформ
	/// </summary>
	public void GenerateTriggers()
	{

		if (NextPoint != null)
		{
			var center = (NextPoint.position + transform.position) / 2.0f;
			var isVertical = NextPoint.position.y == transform.position.y;
			var trigger = Instantiate(_trigger, center, Quaternion.Euler(0, 0, isVertical ? 90 : 0));

			trigger.transform.localScale = new Vector3(0.4f, _lengthWay - 0.75f, 0.4f);
			trigger.GetComponent<Trigger>().length = (int)_lengthWay;
		}
		if (OtherPoints.Any())
		{
			foreach (var otherPoint in OtherPoints)
			{
				var center = (otherPoint.position + transform.position) / 2.0f;
				var isVertical = otherPoint.position.y == transform.position.y;
				var trigger = Instantiate(_trigger, center, Quaternion.Euler(0, 0, isVertical ? 90 : 0));
				var length = Vector3.Distance(transform.position, otherPoint.position);

				trigger.transform.localScale = new Vector3(0.4f, length - 0.75f, 0.4f);
				trigger.GetComponent<Trigger>().length = (int)length;
			}
		}
	}

	#endregion
}
