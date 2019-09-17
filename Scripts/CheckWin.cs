using UnityEngine;
using System.Collections;

public class CheckWin  
{
	public bool CheckResult(char getSymbol)
	{
		return (CheckDiagonal (getSymbol) || CheckLines (getSymbol));
	}

	bool CheckDiagonal(char symbol)
	{
		bool toRight = true, toLeft = true;
		for (int i = 0; i < GameManager.battleFieldSize; i++) 
		{
			toRight = ( toRight && (GameField.gameField[i,i] == symbol));
			toLeft = (toLeft && (GameField.gameField [GameManager.battleFieldSize - i - 1, i] == symbol));
		}

		if (toLeft || toRight) return true;

		return false;
	}

	bool CheckLines(char symbol)
	{
		bool rows, cows ;
		for (int i = 0; i < GameManager.battleFieldSize; i++) 
		{
			rows = true;
			cows = true;
			for (int j = 0; j < GameManager.battleFieldSize; j++) 
			{
				rows = (rows && (GameField.gameField [j, i] == symbol));
				cows = (cows && (GameField.gameField [i, j] == symbol));
			}
			if (cows || rows)return true;
		}

		return false;
	}

}
