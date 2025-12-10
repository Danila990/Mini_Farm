using UnityEngine;

namespace MiniFarm
{
    public interface IGridMap
    {
        public void ResetGrid();
        public ICell GetCell(Vector2Int cellIndex);
        public bool TryGetCell(Vector2Int cellIndex, out ICell cell);
        public bool CheckCell(Vector2Int cellIndex);
        public T FindCell<T>(CellType cellType) where T : Cell;
        public T[] FindCells<T>(CellType cellType) where T : Cell;
    }
}