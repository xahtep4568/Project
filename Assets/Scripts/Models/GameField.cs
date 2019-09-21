using Unity.Mathematics;
using UnityEngine.Assertions;

namespace TicTacToe.Models
{

	public class GameField : IGameField
	{

		public const int MinFieldSize = 3;
		
		private readonly CellSign[,] field;

		public GameField(int size)
		{
			Assert.IsTrue(size >= MinFieldSize);
			
			field = new CellSign[size, size];
			
			for (int i = 0; i < size; ++i)
			{
				for (int j = 0; j < size; ++j)
				{
					field[i, j] = CellSign.Empty;
				}
			}
		}

		public int2 Size => new int2(field.GetLength(0), field.GetLength(1));

		public CellSign this[int2 pos] => field[pos.x, pos.y];
		
		public bool TrySetSign(int2 pos, CellSign playerSign)
		{
			if (field[pos.x, pos.y] != CellSign.Empty) return false;
			
			field[pos.x, pos.y] = playerSign;
			return true;

		}

		public bool IsSignFillAnyLine(CellSign sign)
		{
			if (IsFillAnyHorizontalLine(sign)) return true;
			if (IsFillAnyVerticalLine(sign)) return true;
			if (IsFillMainDiagonalLine(sign)) return true;
			if (IsFillSideDiagonalLine(sign)) return true;
			
			return false;
		}

		public bool IsFull()
		{
			for (int x = 0; x < field.GetLength(0); ++x)
			{
				for (int y = 0; y < field.GetLength(1); ++y)
				{
					if (field[x, y] == CellSign.Empty) return false;
				}
			}

			return true;
		}

		private bool IsFillAnyHorizontalLine(CellSign sign)
		{
			var size = Size;
			
			for (int y = 0; y < size.y; ++y)
			{
				for (int x = 0; x <= size.x; ++x)
				{
					if (x == size.x) return true;
					
					if (field[x, y] != sign) break;
				}
			}

			return false;
		}
		
		private bool IsFillAnyVerticalLine(CellSign sign)
		{
			var size = Size;
			
			for (int x = 0; x < size.x; ++x)
			{
				for (int y = 0; y <= size.y; ++y)
				{
					if (y == size.y) return true;
					
					if (field[x, y] != sign) break;
				}
			}

			return false;
		}

		private bool IsFillMainDiagonalLine(CellSign sign)
		{
			var size = Size;

			for (int i = 0; i < size.x; ++i)
			{
				if (field[i, i] != sign) return false;
			}

			return true;
		}
		
		private bool IsFillSideDiagonalLine(CellSign sign)
		{
			var size = Size;

			for (int i = 0; i < size.x; ++i)
			{
				if (field[i, size.x - 1 - i] != sign) return false;
			}

			return true;
		}
		
	}

}