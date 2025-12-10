using System.Collections;
using UnityEngine;

namespace MiniFarm
{
    public class TargetMover
    {
        private readonly Transform _target;
        private readonly float _moveDuration = 0.3f;

        public bool isMoved { get; private set; } = false;

        public TargetMover(Transform target, float jumpDuration)
        {
            _target = target;
            _moveDuration = jumpDuration;
        }

        public virtual IEnumerator MoveToTarget(Vector3 targetPos)
        {
            isMoved = true;
            Vector3 startPos = _target.position;
            float time = 0f;
            while (time < _moveDuration)
            {
                time += Time.deltaTime;
                float t = time / _moveDuration;

                _target.position = Vector3.Lerp(startPos, targetPos, t);
                yield return null;
            }

            _target.position = targetPos;
            isMoved = false;
        }
    }
}