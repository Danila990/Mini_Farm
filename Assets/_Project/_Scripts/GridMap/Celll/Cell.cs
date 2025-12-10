using UnityEngine;

namespace MiniFarm
{
    public class Cell : MonoBehaviour, ICell
    {
        [SerializeField] private CellType _cellType;
        [SerializeField] private bool _isLoked = false;

        [SerializeField, HideInInspector] private Vector2Int _cellIndex;

        public Vector2Int CellIndex => _cellIndex;

        public CellType CellType => _cellType;

        public virtual Vector3 MovePos => transform.position;

        public bool IsLocked => _isLoked;

        public virtual void Event() { }

        public virtual void Restart() { }

        public void SetCellIndex(Vector2Int cellIndex) => _cellIndex = cellIndex;
    }
}