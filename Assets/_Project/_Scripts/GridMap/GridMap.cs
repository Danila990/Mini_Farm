using System.Linq;
using UnityEngine;

namespace MiniFarm
{
    public class GridMap : MonoBehaviour, IGridMap
    {
        [SerializeField] private MultiArray<CellBase> _array = new MultiArray<CellBase>();

        public ArrayLine<CellBase>[] GetCells() => _array.GetAll();

        public void SetupMap(ArrayLine<CellBase>[] values) => _array.Set(values);

        public Vector2Int GetSize() => _array.SizeGrid;

        public void ResetGrid()
        {
            foreach (var cellLine in _array.GetAll())
                foreach(var cell in cellLine.Values)
                    cell.Restart();
        }

        public bool CheckCell(Vector2Int cellIndex) => _array.Check(cellIndex.x, cellIndex.y);

        public ICell GetCell(Vector2Int cellIndex) => _array.Get(cellIndex.x, cellIndex.y);

        public bool TryGetCell(Vector2Int cellIndex, out ICell cell)
        {
            if (!CheckCell(cellIndex))
            {
                cell = null;
                return false;
            }

            cell = GetCell(cellIndex);
            return true;
        }

        public T FindCell<T>(CellType cellType) where T : CellBase
        {
            return _array.GetAll()
                .SelectMany(line => line.Values)
                .Where(cell => cell.CellType == cellType)
                .Cast<T>()
                .FirstOrDefault();
        }

        public T[] FindCells<T>(CellType cellType) where T : CellBase
        {
            return _array.GetAll()
                .SelectMany(line => line.Values)
                .Where(cell => cell.CellType == cellType)
                .Cast<T>()
                .ToArray();
        }
    }
}