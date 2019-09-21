using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Controllers
{
    
    [RequireComponent(typeof(Button))]
    public class FieldCellButton : MonoBehaviour
    {

        [SerializeField] private int2 position;

        private Button button;

        private Button Button => button != null ? button : (button = GetComponent<Button>());

        public event Action<int2> OnCellSelected;

        private void Start()
        {
            Button.onClick.AddListener(() => OnCellSelected?.Invoke(position));
        }

        private void OnEnable() => Button.interactable = true;

        private void OnDisable() => Button.interactable = false;

    }
    
}