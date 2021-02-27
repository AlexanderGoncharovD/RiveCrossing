using System.Collections;
using System.Collections.Generic;
using PLExternal.Level;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	#region Private Fileds

	private Grid _grid;
	private GameObject _player;

	/// <summary>
	///		Модель игровой точки
	/// </summary>
	[SerializeField]
	private GameObject _pointModel;

	/// <summary>
	///		Модель игровой точки
	/// </summary>
	[SerializeField]
	private GameObject _platformModel;

	/// <summary>
	///		Модель игрока
	/// </summary>
	[SerializeField]
	private GameObject _playerModel;

	/// <summary>
	///		Карта уровня
	/// </summary>
	private string _map = /*"6-1;3-1;3-3;2-3;4-1;0-3;4-3"*/ "6-1;5-1;5-2;5-3;5-4;4-2;4-3;3-3;3-0;2-4;2-1;1-4;1-2;0-3";

	/// <summary>
	///		Решение уровня
	/// </summary>
	private string _solution = /*"6-1;4-1;3-1;3-3;2-3;0-3"*/ "6-1;5-1;5-2;5-3;4-3;3-3;0-3";

	/// <summary>
	///		Расположение платформ
	/// </summary>
	private string _platforms = "6-1;5-1#5-4;2-4#2-4;1-4";

	private Camera _camera;
    private GameControl _gameControl;
    private LevelConverter _levelConverter;

	#endregion

	#region Public Fields



	#endregion

	#region Private Methods

	private void Start()
	{
		_camera = Camera.main;
		_levelConverter = new LevelConverter();
		LoadLevel(4);
		SpawnPlayer();
	}

	/// <summary>
	///		Загрузить игровой уровень
	/// </summary>
	private void LoadLevel(int level)
    {
        _gameControl = _camera.GetComponent<GameControl>();
        _map = _levelConverter.GetLevelByNumber(level);
        _platforms = _levelConverter.GetLevelPlatformsByNumber(level);
        _solution = _levelConverter.GetLevelSolutionByNumber(level);
        _grid = new Grid(_pointModel, _platformModel, _map, _solution, _platforms);
        _gameControl.UpdateTriggerList();
	}

	/// <summary>
	///		Создать игрока
	/// </summary>
	private void SpawnPlayer()
	{
		_player = Instantiate(_playerModel, _grid.StartPoint.transform.position + new Vector3(0, 0, -1), Quaternion.identity);
		_player.GetComponent<Player>().CurPoint = _grid.StartPoint.transform;
		_camera.GetComponent<GameControl>().Player = _player.GetComponent<Player>();
	}
	
	#endregion
}
