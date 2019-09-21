using System;
using Unity.Mathematics;
using UnityEngine.Assertions;

namespace TicTacToe.Models
{

    public class GameSessionManager
    {

        private readonly IPlayer player1;
        private readonly IPlayer player2;

        private readonly GameField field;

        private IPlayer currentPlayer;

        public GameSessionManager(IPlayer player1, IPlayer player2, int fieldSize)
        {
            Assert.IsNotNull(player1);
            Assert.IsNotNull(player2);
            
            this.player1 = player1;
            this.player1.OnMadeTurn += OnMadeTurn;
            
            this.player2 = player2;
            this.player2.OnMadeTurn += OnMadeTurn;
            
            field = new GameField(fieldSize);
        }
        
        public IPlayer CurrentPlayer
        {
            get => currentPlayer;
            private set
            {
                if (currentPlayer == value) return;
                
                currentPlayer = value;
                OnPlayerChanged?.Invoke(currentPlayer);

                currentPlayer.StartTurn(field);
            }
        }

        public IGameField Field => field;

        public event Action<IPlayer> OnPlayerChanged;
        public event Action<IPlayer> OnPlayerWin;
        public event Action OnDraw;

        public void StartGame()
        {
            CurrentPlayer = player1;
        }

        private void OnMadeTurn(IPlayer player, int2 position)
        {
            if (player != currentPlayer) return;

            if (field.TrySetSign(position, player.Sign))
            {
                if (field.IsSignFillAnyLine(player.Sign)) OnPlayerWin?.Invoke(player);
                else if (field.IsFull()) OnDraw?.Invoke();
                else SwitchPlayer();
            }
            else
            {
                player.StartTurn(field);
            }
        }

        private void SwitchPlayer() => CurrentPlayer = CurrentPlayer == player1 ? player2 : player1;
        
    }

}