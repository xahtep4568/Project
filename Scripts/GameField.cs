using UnityEngine;
using System.Collections;

public class GameField 
{
	public static char[,] gameField;

	public void CreateGameField(int size)
	{
		gameField = new char[size, size];
		for (int i = 0; i < size; i++)
			for (int j = 0; j < size; j++) 
			{
				gameField [i, j] = ' ';
			}
	}
		
}
