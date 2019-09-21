using TicTacToe.Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace TicTacToe.Controllers
{
    
    public class FieldController : MonoBehaviour
    {

        [FormerlySerializedAs("views")] [SerializeField] private FieldCellController[] controllers;
        
        private GameSessionManager session;

        private void OnDestroy()
        {
            UnsubscribeFromCurrentSession();
        }

        public void SetSession(GameSessionManager session)
        {
            UnsubscribeFromCurrentSession();
            this.session = session;
            SubscribeToCurrentSession();
            
            UpdateViews();
        }

        private void SubscribeToCurrentSession()
        {
            if (session == null) return;
            session.OnPlayerChanged += OnPlayerAction;
            session.OnPlayerWin += OnPlayerAction;
            session.OnDraw += UpdateViews;
        }

        private void UnsubscribeFromCurrentSession()
        {
            if (session == null) return;
            session.OnPlayerChanged -= OnPlayerAction;
            session.OnPlayerWin -= OnPlayerAction;
            session.OnDraw -= UpdateViews;
        }

        private void OnPlayerAction(IPlayer _) => UpdateViews();
        
        private void UpdateViews()
        {
            foreach (var view in controllers) view.Sign = session.Field[view.Position];
        }
        
    }
    
}