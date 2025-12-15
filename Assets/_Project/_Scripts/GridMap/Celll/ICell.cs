
using UnityEngine;

namespace MiniFarm
{
    public interface ICell
    {
        public Vector2Int CellIndex { get; }
        public CellType CellType { get; }
        public Vector3 MovePos { get; }
        public bool IsLocked { get; }
        public void Event();
    }
}