using UnityEngine;

namespace MiniFarm
{
    public class GameManager : MonoBehaviour
    {
        private Player _player;
        private IInputService _inputService;
        private LevelTimer _timer;

        [Inject]
        public void Setup(Player player, IInputService inputService, LevelTimer levelTimer)
        {
            _player = player;
            _inputService = inputService;
            _timer = levelTimer;
        }

        public void StartGame()
        {
            _inputService.ActiveState(true);
            _player.StartPlayer();
            _timer.StartTimer();
        }

        public void RestartGame()
        {
            ServiceLocator.ResetContainer();
            SceneLoader.RestartScene();
        }

        public void PlayGame()
        {
            _inputService.ActiveState(true);
            Time.timeScale = 1;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void LossGame()
        {
            RestartGame();
        }

        public void WinGame()
        {
            RestartGame();
        }
    }
}