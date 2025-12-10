using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace MiniFarm
{
    public class GameManager : MonoBehaviour
    {
        private IGridMap _gridMap;
        private Player _player;
        private PlayerDirectionArrow _directionArrow;
        private IInputService _inputService;

        [Inject]
        public void Setup(IGridMap gridMap, Player player, PlayerDirectionArrow playerDirectionArrow, IInputService inputService)
        {
            _gridMap = gridMap;
            _player = player;
            _directionArrow = playerDirectionArrow;
            _inputService = inputService;
        }

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            RestartGame();
            _player.StartPlayer();
            PlayGame();
        }

        public void RestartGame()
        {
            _gridMap.ResetGrid();
            _player.Restart();
            _directionArrow.Restart();
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
            RestartGame();
            //PauseGame();
        }

        public void WinGame()
        {
            RestartGame();
        }
    }
}