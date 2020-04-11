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
	private string _map = "6-1;3-1;3-3;2-3;4-1;0-3;4-3";
	private string _solution = "6-1;4-1;3-1;3-3;2-3;0-3";

	private Camera _camera;

	#endregion

	#region Public Fields



	#endregion

	#region Private Methods

	private void Start()
	{
		_camera = Camera.main;
		LoadLevel();
	}

	/// <summary>
	///		Загрузить игровой уровень
	/// </summary>
	private void LoadLevel()
	{
		_grid = new Grid(_pointModel, _map, _solution);
		_camera.GetComponent<GameControl>().UpdateTriggerList();

	}
	
	#endregion
}
