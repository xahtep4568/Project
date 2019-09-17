using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Collections;

public class Player : IPlayer
{
	private CheckWin checkWin = new CheckWin();
	private char symbolPlayer;

	public  void SetSymb(char startSymbol)
	{
		symbolPlayer = startSymbol;
	}

	public bool Hold()
	{
		return true;
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
