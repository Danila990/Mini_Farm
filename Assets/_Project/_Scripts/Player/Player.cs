using System.Collections;
using UnityEngine;

namespace MiniFarm
{
    [RequireComponent(typeof(PlayerGridMover))]
    public class Player : MonoBehaviour
    {

        [SerializeField] private GameObject _virtualCamera;

        private PlayerGridMover _playerMover;

        [Inject]
        public void Setup(IGridMap gridMap, IInputService inputService)
        {
            _playerMover = GetComponent<PlayerGridMover>();
            _playerMover.Setup(gridMap);
            inputService.RegistControllable(_playerMover);
        }

        public void StartPlayer()
        {
            _virtualCamera.gameObject.SetActive(true);
            _playerMover.StartMove();
        }

        public void Restart()
        {
            _virtualCamera.gameObject.SetActive(false);
            _playerMover.Restart();
        }
    }
}