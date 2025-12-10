using System.Collections;
using UnityEngine;

namespace MiniFarm
{
    public class DirectionRotator
    {
        private readonly float _rotateDuration = 0.2f;
        private readonly Transform _target;
        private readonly Direction _startDirection;

        public Direction currentDirection { get; private set; }
        public bool isRotated { get; private set; } = false;

        public DirectionRotator(float rotateDuration, Transform target, Direction startDirection = Direction.None)
        {
            _rotateDuration = rotateDuration;
            _target = target;
            _startDirection = startDirection;
            currentDirection = _startDirection;
        }

        public void ResetRotate()
        {
            currentDirection = _startDirection;
            Quaternion targetRotation = currentDirection.ToQuaternionY();
            _target.rotation = targetRotation;
        }

        public virtual IEnumerator RotateToDirection(Direction direction)
        {
            if (direction == Direction.None || currentDirection == direction) yield break;

            currentDirection = direction;
            isRotated = true;

            Quaternion startRotation = _target.rotation;
            Quaternion targetRotation = direction.ToQuaternionY();

            float elapsed = 0f;

            while (elapsed < _rotateDuration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / _rotateDuration);
                _target.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
                yield return null;
            }

            _target.rotation = targetRotation;
            isRotated = false;
        }
    }
}