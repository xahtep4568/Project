using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLoader 
{
	private GameManager gameManager;
	private UIController uiController;
	Button button;
	// Use this for initialization
	public GameLoader(UIController uiController)
	{
		this.uiController = uiController;
		gameManager = new GameManager ();
	}
	public void SetButton(Button button)
	{
		this.button = button;
	}
	public void SetCoord(int x,int y)
	{
		uiController.UISet(x,y,gameManager.GameRun (x, y));
	}

	public bool GetGameOver()
	{
		return gameManager.GetGameOver;
	}

	public string GetPlayer()
	{
		return gameManager.GetPlayer;
	}
	public void GenerateUI(int size)
	{
		//uiController.UiCreate (size);
	}

	public void Generate(int size, char symbPlayer)
	{
		Debug.Log (size);
		gameManager.StartGame (size,symbPlayer);
	}
}
