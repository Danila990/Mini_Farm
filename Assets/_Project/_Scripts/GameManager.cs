using UnityEngine;

namespace MiniFarm
{
    public class GameManager
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
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("Loss");
            RestartGame();
        }

        public void WinGame()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("Win");
            RestartGame();
        }
    }
}