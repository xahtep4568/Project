using System;
using TicTacToe.Models;
using Unity.Mathematics;
using UnityEngine;

namespace TicTacToe.Controllers
{
    
    public class PlayerTurnController : MonoBehaviour, Player.IPlayerTurnController
    {

        [SerializeField] private FieldCellButton[] cells;

        private Action<int2> clickCallback;

        private void Start()
        {
            foreach (var cell in cells) cell.OnCellSelected += OnCellSelected;
            SetActiveCells(false);
        }

        private void OnDestroy()
        {
            foreach (var cell in cells) cell.OnCellSelected -= OnCellSelected;
        }

        public void MakeTurn(Action<int2> callback)
        {
            SetActiveCells(true);
            clickCallback = callback;   
        }

        private void OnCellSelected(int2 pos)
        {
            SetActiveCells(false);
            clickCallback?.Invoke(pos);
        }

        private void SetActiveCells(bool active)
        {
            foreach (var cell in cells) cell.enabled = active;
        }
        
    }
    
}