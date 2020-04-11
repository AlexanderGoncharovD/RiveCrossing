using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	#region Private Fileds

	private Grid _grid;

	/// <summary>
	///		Модель игровой точки
	/// </summary>
	[SerializeField]
	private GameObject _pointModel;

	/// <summary>
	///		Карта уровня
	/// </summary>
	private string _map = "6-1;4-1;3-1;3-3;2-3;0-3";

	#endregion

	#region Public Fields



	#endregion

	#region Private Methods

	private void Start()
	{
		LoadLevel();
	}

	/// <summary>
	///		Загрузить игровой уровень
	/// </summary>
	private void LoadLevel()
	{
		_grid = new Grid(_pointModel, _map);

	}
	
	#endregion
}
