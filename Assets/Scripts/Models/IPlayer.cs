using System;
using Unity.Mathematics;

namespace TicTacToe.Models
{

	public interface IPlayer
	{

		CellSign Sign { get; }
		
		event Action<IPlayer, int2> OnMadeTurn;

		void StartTurn(IGameField field);

	}

}