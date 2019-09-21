using System;
using TicTacToe.Models;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Controllers
{
    
    public class FieldCellController : MonoBehaviour
    {

        private const string SignTextEmpty = "";
        private const string SignTextX = "X";
        private const string SignTextO = "O";
        
        [SerializeField] private Text signText;
        [SerializeField] private int2 position;

        private CellSign sign = CellSign.Empty;
        
        public int2 Position => position;

        public CellSign Sign
        {
            get => sign;
            set
            {
                if (sign == value) return;
                sign = value;
                UpdateText();
            }
        }

        private void Start()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            switch (sign)
            {
                case CellSign.Empty: signText.text = SignTextEmpty; return;
                case CellSign.X: signText.text = SignTextX; return;
                case CellSign.O: signText.text = SignTextO; return;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        
    }
    
}