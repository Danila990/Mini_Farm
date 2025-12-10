using System.Collections;
using UnityEngine;

namespace MiniFarm
{
    public class PlayerMover : TargetMover
    {
        private readonly PlayerAnimator _playerAnimator;

        public PlayerMover(Transform target, float jumpDuration, PlayerAnimator playerAnimator)
            : base(target, jumpDuration)
        {
            _playerAnimator = playerAnimator;
        }

        public override IEnumerator MoveToTarget(Vector3 targetPosition)
        {
            if (isMoved) yield break;

            _playerAnimator.MoveState(true);
            yield return base.MoveToTarget(targetPosition);
            _playerAnimator.MoveState(false);
        }
    }
}