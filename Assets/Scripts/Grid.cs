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
	private List<string> _map;

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

	public Grid(GameObject pointModel, string map)
	{
		_pointModel = pointModel;
		_map = map.Split(';').ToList();
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
		{
			throw new System.Exception($"{nameof(_map)} is null");
		}

		var position = new Vector3(-2.0f, 3.0f, 0.0f);

		for (var r = 0; r < _row; r++)
		{
			for (var c = 0; c < _col; c++)
			{
				if (_map.Any(e => e.Equals($"{r}-{c}")))
				{
					var point = MonoBehaviour.Instantiate(_pointModel, position, Quaternion.Euler(90, 0, 0));
					point.name = $"{r}-{c}";
				}
				position += new Vector3(1, 0, 0);
			}
			position = new Vector3(-2, position.y - 1, 0);
		}
	}

	#endregion
}
