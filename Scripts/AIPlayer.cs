using UnityEngine;
using System.Collections;

public class AIPlayer: IPlayer
{
	private CheckWin checkWin = new CheckWin();
	private char symbolPlayer;

	public  void SetSymb(char startSymbol)
	{
		symbolPlayer = startSymbol;
	}

	public bool Hold()
	{
		int x = Random.Range(0,GameManager.battleFieldSize);
		int y = Random.Range(0,GameManager.battleFieldSize);
		while (GameField.gameField [x, y] != ' ') 
		{
			x = Random.Range(0,GameManager.battleFieldSize);
			y = Random.Range(0,GameManager.battleFieldSize);
		}
		GameField.gameField [x, y] = symbolPlayer;
		Debug.Log (x + " " + y + " " + symbolPlayer);
		//GameLoader.instance.SetCoord (x, y, symbolPlayer);
		return checkWin.CheckResult (symbolPlayer);

	}

	public bool Turn(int x, int y)
	{
		GameField.gameField [x, y] = symbolPlayer;
		Debug.Log (x + " " + y+" "+symbolPlayer);
		return checkWin.CheckResult (symbolPlayer);

	}

	public char GetSymb
	{
		get { return symbolPlayer;}
	}

}
