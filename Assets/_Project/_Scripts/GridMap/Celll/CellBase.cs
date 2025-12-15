using UnityEngine;

namespace MiniFarm
{
    public class CellBase : MonoBehaviour, ICell
    {
        [SerializeField, HideInInspector] private Vector2Int _cellIndex;

        public Vector2Int CellIndex => _cellIndex;

        public virtual CellType CellType => CellType.Base;

        public virtual Vector3 MovePos => transform.position;

        public virtual bool IsLocked => false;

        public virtual void Event() { }

        public void SetCellIndex(Vector2Int cellIndex) => _cellIndex = cellIndex;
    }
}