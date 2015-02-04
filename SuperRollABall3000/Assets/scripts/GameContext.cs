using UnityEngine;
using System.Collections;

public class GameContext
{
	public enum GameStates{Play, LevelDesign};

	public GameStates GameState{get; set;}
	private static GameContext gameStatus;

	private GameContext()
	{
		GameState = GameStates.LevelDesign;
	}

	public static GameContext Game
	{
		get 
		{
			if (gameStatus == null)
			{
				gameStatus = new GameContext();
			}
			return gameStatus;
		}
	}
}
