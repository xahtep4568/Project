using System;
using Unity.Mathematics;

namespace TicTacToe.Models
{

	public class Player : IPlayer
	{

		private readonly IPlayerTurnController turnController;
		
		public Player(CellSign sign, IPlayerTurnController turnController)
		{
			Sign = sign;
			this.turnController = turnController;
		}
		
		public CellSign Sign { get; }
		
		public event Action<IPlayer, int2> OnMadeTurn;

		public void StartTurn(IGameField field) => turnController.MakeTurn(pos => OnMadeTurn?.Invoke(this, pos));
		
		public interface IPlayerTurnController
		{

			void MakeTurn(Action<int2> onMadeTurn);

		}
		
	}

}