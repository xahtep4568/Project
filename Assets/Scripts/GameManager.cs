using TicTacToe.Controllers;
using TicTacToe.Models;
using UnityEngine;

namespace TicTacToe
{
    
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance { get; private set; }

        [SerializeField] private PlayerTurnController turnController;
        [SerializeField] private FieldController fieldController;

        private GameSessionManager session;
        
        private void Awake()
        {
            Instance = this;
        }

        public void StartGame(bool withAi)
        {
            var player1 = new Player(CellSign.X, turnController);
            IPlayer player2;
            
            if (withAi) player2 = new AiPlayer(CellSign.O);
            else player2 = new Player(CellSign.O, turnController);
            
            session = new GameSessionManager(player1, player2, GameField.MinFieldSize);
            fieldController.SetSession(session);
            
            session.StartGame();
        }
        
    }
    
}