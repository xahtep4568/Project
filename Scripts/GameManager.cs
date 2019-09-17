using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager
{
	//я так понимаю он должен вызываться где-то в GameManager
	public static int battleFieldSize;
	private string winPlayer;
	private bool gameFinish = false;
	private int count = 0;
	IPlayer player1;
	IPlayer player2;
	IPlayer currentPlayer;
	GameField gameField;

	public GameManager()
	{
		gameField = new GameField ();
		player1 = new Player ();
		player2 = new Player ();
	}
	public void StartGame(int size, char symbPlayer)
	{
		battleFieldSize = size;
		SetPlayer (symbPlayer);
		gameField.CreateGameField (battleFieldSize);
		currentPlayer = player1;
	}
	public char GameRun(int x, int y)
	{
		return Step (x, y);
	}

	char Step(int x, int y)
	{
		gameFinish = currentPlayer.Turn (x, y);
		count++;
		if (count >= (battleFieldSize * battleFieldSize)) 
		{
			winPlayer = "Draw";
			GameOver ();
		} 
		else if (gameFinish) 
		{
			winPlayer = "Win is " + currentPlayer.GetSymb.ToString ();
			GameOver ();
		}
			if (currentPlayer == player1) 
			{
				currentPlayer = player2;
				return player1.GetSymb;
			} 
			else 
			{
				currentPlayer = player1;
				return player2.GetSymb;
			}
		ChangePlayer ();
	}
	void GameOver()
	{
		count = 0;
		gameFinish = true;

	}

	void SetPlayer(char symbPlayer)
	{
		if (symbPlayer == 'X') 
		{
			player1.SetSymb ('X');
			player2.SetSymb ('O');
		} 
		else 
		{
			player1.SetSymb ('O');
			player2.SetSymb ('X');
		}
	}
	public bool GetGameOver
	{
		get { return gameFinish;}
	}
	public string GetPlayer
	{
		get { return winPlayer;}
	}
	private void ChangePlayer()
	{
		if (currentPlayer == player1)
			currentPlayer = player2;
		else
			currentPlayer = player1;
	}


}
