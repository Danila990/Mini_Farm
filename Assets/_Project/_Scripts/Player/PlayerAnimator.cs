using UnityEngine;

namespace MiniFarm
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Transform[] _wheels;
        [SerializeField] private float _rotationSpeed = 30f;
        [SerializeField] private GameObject _whellEffect;

        private bool _isActive = false;

        private void Update()
        {
            if (!_isActive) return;

            foreach (Transform wheel in _wheels)
                wheel.Rotate(Vector3.right, _rotationSpeed * Time.deltaTime);
        }

        public void MoveState(bool state)
        {
            _isActive = state;

            if (!_isActive)
                _whellEffect.gameObject.SetActive(false);
            else
                _whellEffect.gameObject.SetActive(true);

        }

        public void RightRotate(Direction directionType)
        {

        }

        public void StopAnimation()
        {

        }
    }
}