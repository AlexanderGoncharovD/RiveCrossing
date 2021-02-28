using System.Collections;
using System.Collections.Generic;
using PLExternal.Level;
using UnityEngine;

public class LevelGenerator
{
	#region Private Fileds

    private readonly LevelConverter _converter;
    private readonly LevelManager _manager;
	private Grid _grid;
	
	/// <summary>
	///		Карта уровня
	/// </summary>
	private IEnumerable<string> _map;

    /// <summary>
    ///		Решение уровня
    /// </summary>
    private IEnumerable<string> _solution;

	/// <summary>
	///		Расположение платформ
	/// </summary>
	private IEnumerable<IEnumerable<string>> _platforms;

	#endregion

    public LevelGenerator(LevelManager manager)
    {
        _manager = manager;
        _converter = new LevelConverter();
	}
	
	#region Private Methods
	
	/// <summary>
	///		Загрузить игровой уровень
	/// </summary>
	public void LoadLevel(int level)
    {
        _map = _converter.GetLevelByNumber(level);
        _platforms = _converter.GetLevelPlatformsByNumber(level);
        _solution = _converter.GetLevelSolutionByNumber(level);
        _grid = new Grid(_manager.Helper.pointModel, _manager.Helper.platformModel, _map, _solution, _platforms);
        SpawnPlayer();
	}

	/// <summary>
	///		Создать игрока
	/// </summary>
	private void SpawnPlayer()
	{
		var player = Player.Initialize(
            model:    _manager.Helper.playerModel,
            position: _grid.StartPoint.transform.position + new Vector3(0, 0, -1),
            rotation: Quaternion.identity);

        var playerComponent = player.GetComponent<Player>();
        player.CurPoint = _grid.StartPoint.transform;
		_manager.Player = playerComponent;
	}
	
	#endregion
}
