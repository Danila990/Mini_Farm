using UnityEngine;

namespace MiniFarm
{
    [RequireComponent(typeof(PlayerGridMover))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject _virtualCamera;

        private PlayerGridMover _playerMover;

        private void Awake()
        {
            _playerMover = GetComponent<PlayerGridMover>();
        }

        public void StartPlayer()
        {
            _virtualCamera.gameObject.SetActive(true);
            _playerMover.StartMove();
        }
    }
}