using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace MiniFarm
{
    public class GameManager
    {
        private Player _player;
        private IInputService _inputService;
        private LevelTimer _timer;
        private WindowController _windowController;

        [Inject]
        public void Setup(Player player, IInputService inputService, LevelTimer levelTimer, WindowController window)
        {
            _player = player;
            _inputService = inputService;
            _timer = levelTimer;
            _windowController = window;
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
            _inputService.ActiveState(false);
            Time.timeScale = 0;
        }

        public void LossGame()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("Loss");
            _windowController.ShowWindow(WindowType.Game_Loss);
            PauseGame();
        }

        public void WinGame()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex < SceneManager.sceneCountInBuildSettings - 1 && YG2.saves.currentLevel <= sceneIndex)
            {
                YG2.saves.currentLevel = sceneIndex + 1;
                YG2.SaveProgress();
            }

            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("Win");
            _windowController.ShowWindow(WindowType.Game_Win);
            PauseGame();
        }
    }
}