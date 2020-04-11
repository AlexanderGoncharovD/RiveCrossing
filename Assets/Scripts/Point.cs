using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
	#region Properties

	/// <summary>
	///		Тип чтоки
	/// </summary>
	[SerializeField]
	public PointType Type { get; set; } = PointType.Default;

	/// <summary>
	///		Следующая точка для прохождения уровня
	/// </summary>
	public Transform NextPoint { get; set; }
	/// <summary>
	///		Предыдущая точка для возвращения к началу
	/// </summary>
	public Transform BackPoint { get; set; }

	/// <summary>
	///		Побочные точки, по которым нельзя пройти или вернуться для успешного прохождения уровня
	/// </summary>
	public List<Transform> OtherPoints { get; set; } = new List<Transform>() { null, null };

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
}
