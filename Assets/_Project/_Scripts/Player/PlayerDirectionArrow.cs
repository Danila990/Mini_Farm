using UnityEngine;

namespace MiniFarm
{
    public class PlayerDirectionArrow : MonoBehaviour, IInputControllable
    {
        [SerializeField, Range(0, 10)] private float _arrowOffsetY = 5;
        [SerializeField, Range(0, 1),] private float _rotateDuration = 0.2f;

        private DirectionRotator _rotate;
        private Transform _target;

        [Inject]
        public void Setup(Player player, IInputService inputService)
        {
            _target = player.transform;
            _rotate = new DirectionRotator(_rotateDuration, transform);
            inputService.RegistControllable(this);
        }

        private void Update()
        {
            if(_target == null) return;

            Vector3 position = _target.position;
            position.y = _arrowOffsetY;
            transform.position = position;
        }

        public void Restart()
        {
            _rotate.ResetRotate();
            Update();
        }

        public void InputDirection(Direction direction)
        {
            if (!_rotate.isRotated)
                StartCoroutine(_rotate.RotateToDirection(direction));
        }
    }
}