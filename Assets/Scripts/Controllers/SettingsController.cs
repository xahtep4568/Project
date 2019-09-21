using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Controllers
{
    
    public class SettingsController : MonoBehaviour
    {

        [SerializeField] private Toggle withAiToggle;
        [SerializeField] private Button startButton;

        private void Start()
        {
            startButton.onClick.AddListener(OnStartClick);
        }

        private void OnStartClick()
        {
            GameManager.Instance.StartGame(withAiToggle.isOn);
        }
        
    }
    
}