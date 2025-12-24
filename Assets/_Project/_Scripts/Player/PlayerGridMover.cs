using System.Collections;
using UnityEngine;

namespace MiniFarm
{
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerGridMover : MonoBehaviour, IInputControllable
    {
        [SerializeField, Range(0, 1),] private float _rotateDuration = 0.5f;
        [SerializeField, Range(0, 1)] private float _jumpDuration = 0.5f;
        [SerializeField] private Transform _rotateTarget;

        private DirectionRotator _rotator;
        private PlayerMover _jumper;
        private PlayerAnimator _animator;

        private ICell _spawnCell;
        private Vector2Int _playerIndex;
        private Direction _targetDirection;
        private IGridMap _gridMap;

        public bool IsActived => _jumper.isMoved || _rotator.isRotated;

        [Inject]
        public void Setup(IGridMap gridMap, IInputService inputService, LevelData levelData)
        {
            _gridMap = gridMap;
            _animator = GetComponent<PlayerAnimator>();
            _jumper = new PlayerMover(transform, _jumpDuration, _animator);
            _rotator = new DirectionRotator(_rotateDuration, _rotateTarget, levelData.directionPlayer);
            inputService.RegistControllable(this);

            Restart();
        }

        public void InputDirection(Direction direction) => _targetDirection = direction;

        public void Restart()
        {
            StopAllCoroutines();
            _rotator.ResetRotate();
            _spawnCell = _gridMap.FindCell<CellBase>(CellType.Player);
            _playerIndex = _spawnCell.CellIndex;
            transform.position = _spawnCell.MovePos;
        }

        public void StartMove()
        {
            StartCoroutine(PlayerTick());
        }

        private IEnumerator PlayerTick()
        {
            while (true)
            {
                if (TryGetNextCell(_playerIndex, out ICell cell))
                {
                    if(!cell.IsLocked) 
                    {
                        yield return RotateAndMove(cell.MovePos);
                        _playerIndex = cell.CellIndex;
                        cell.Event();
                    }
                }

                yield return null;
            }
        }

        private bool TryGetNextCell(Vector2Int playerIndex, out ICell cell)
        {
            if (_targetDirection != Direction.None)
            {
                Vector2Int nextIndex = playerIndex + _targetDirection.ToVector();
                return _gridMap.TryGetCell(nextIndex, out cell);
            }

            cell = default;
            return false;
        }

        private IEnumerator RotateAndMove(Vector3 movePos)
        {
            if (IsActived) yield break;

            yield return _rotator.RotateToDirection(_targetDirection);
            yield return _jumper.MoveToTarget(movePos);
        }
    }
}