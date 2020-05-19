using TankProject.Interfaces;
using TankProject.Managers;
using TankProject.Units;
using UnityEngine;
using UnityEngine.UI;

namespace TankProject
{
    public sealed class GameEventScreenLogger : MonoBehaviour, IScreenLogger
    {
        [TextArea(5, 20)] [SerializeField] private string message;
        [SerializeField] private Text messageText;


        private void Start()
        {
            ShowMessage();
        }

        private void OnEnable()
        {
            GameManager.OnGameOver += OnGameOver;
            GameManager.OnGameStart += OnGameStart;
        }

        private void OnDisable()
        {
            GameManager.OnGameOver -= OnGameOver;
            GameManager.OnGameStart -= OnGameStart;
        }

        private void OnGameStart()
        {
            ClearMessage();   
        }

        private void OnGameOver()
        {
            ShowMessage();
        }

        public void ShowMessage()
        {
            messageText.text = string.Format(message, MonsterManager.MonstersKilled.ToString());
        }

        public void ClearMessage()
        {
            messageText.text = "";
        }
    }
}
