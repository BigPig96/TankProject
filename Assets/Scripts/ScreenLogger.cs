using TankProject.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TankProject
{
    public sealed class ScreenLogger : MonoBehaviour
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

        private void ShowMessage()
        {
            messageText.text = string.Format(message, MonsterManager.Instance.KilledCount.ToString());
        }

        private void ClearMessage()
        {
            messageText.text = "";
        }
    }
}
