using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace MiniFarm.GridEditor
{
    [System.Serializable]
    public class GridCreator : MoodArray<CellBase>
    {
        private const string PATH_PREFABS_CELL = "Assets/_Project/Prefabs/Cells";
        private const string NAME_CELL_LOAD = "Cell t:prefab";
        private const string NAME_CELL = "Cell";

        public GridMap Map;
        public float OffsetCell = 3f;

        public GridCreator() : base(default)
        {
            LoadPrefabs();
            Map = Object.FindAnyObjectByType<GridMap>();
        }

        public void CreateGrid(CellType[,] cellTypes)
        {
            if (Map != null)
                DestroyGrid();

            CreateNewGrid(cellTypes);
        }

        public void DestroyGrid()
        {
            if (Map == null) return;

            Object.DestroyImmediate(Map.gameObject);
            Map = null;
        }

        public CellType[,] ConvertGridToCellType()
        {
            if (Map == null) return new CellType[0, 0];

            Vector2Int size = Map.GetSize();
            CellType[,] cellTypes = new CellType[size.x, size.y];

            for (int x = 0; x < size.x; x++)
                for (int y = 0; y < size.y; y++)
                    cellTypes[x, y] = Map.GetCell(new Vector2Int(x, y)).CellType;

            return cellTypes;
        }

        private const string PATH_PREFABS_FRUIT = "Assets/_Project/Prefabs/Fruits";
        private const string NAME_FRUIT_LOAD = "t:prefab";

        public void ChangeFruit(FruitType fruitType, FruitCell fruitCell)
        {
            if(fruitCell.fruit != null)
                if (fruitType == fruitCell.fruit.fruitType) return;

            Object.DestroyImmediate(fruitCell.fruit.gameObject);

            string[] guids = AssetDatabase.FindAssets(NAME_FRUIT_LOAD, new[] { PATH_PREFABS_FRUIT });
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Fruit prefab = AssetDatabase.LoadAssetAtPath<Fruit>(path);

                if (prefab != null && prefab.fruitType == fruitType)
                {
                    Fruit newFruit = Object.Instantiate(prefab, fruitCell.transform);
                    fruitCell.SetFruit(newFruit);
                    Undo.RegisterCreatedObjectUndo(fruitCell.fruit.gameObject, "Change Fruit");
                    EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
                    return;
                }
            }
        }

        private const string PATH_PREFABS_TRAP = "Assets/_Project/Prefabs/Traps";
        private const string NAME_TRAP_LOAD = "t:prefab";

        public void ChangeTrap(TrapType trapType, TrapCell trapCell)
        {
            if (trapCell.trap != null)
                if (trapType == trapCell.trap.trapType) return;

            Object.DestroyImmediate(trapCell.trap.gameObject);

            string[] guids = AssetDatabase.FindAssets(NAME_TRAP_LOAD, new[] { PATH_PREFABS_TRAP });
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Trap prefab = AssetDatabase.LoadAssetAtPath<Trap>(path);

                if (prefab != null && prefab.trapType == trapType)
                {
                    Trap newFruit = Object.Instantiate(prefab, trapCell.transform);
                    trapCell.SetTrap(newFruit);
                    Undo.RegisterCreatedObjectUndo(trapCell.trap.gameObject, "Change trap");
                    EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
                    return;
                }
            }
        }


        private void CreateNewGrid(CellType[,] cellTypes)
        {
            Vector2Int gridSize = new Vector2Int(cellTypes.GetLength(0), cellTypes.GetLength(1));
            Vector3 middleOffset = MiddleOffest(OffsetCell, gridSize);

            Map = new GameObject($"GridMap: X-{gridSize.x},Y-{gridSize.y}").AddComponent<GridMap>();

            ArrayLine<CellBase>[] newGrid = new ArrayLine<CellBase>[gridSize.x];
            for (int x = 0; x < gridSize.x; x++)
            {
                Transform parrentLine = new GameObject("Line " + x).transform;
                parrentLine.parent = Map.transform;
                newGrid[x].Values = new CellBase[gridSize.y];
                for (int y = 0; y < gridSize.y; y++)
                {
                    CellBase platform = CreateCell(cellTypes[x, y], x, y, middleOffset);
                    platform.transform.parent = parrentLine;
                    newGrid[x].Values[y] = platform;
                    platform.SetCellIndex(new Vector2Int(x, y));
                    platform.gameObject.name = $"{x}, {y}";
                }
            }

            Map.SetupMap(newGrid);
            Undo.RegisterCreatedObjectUndo(Map.gameObject, "Create Grid map");
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }

        private CellBase CreateCell(CellType cellType, int gridX, int gridY, Vector3 spawnOffset)
        {
            string findCellName = $"{NAME_CELL}_{cellType}";
            CellBase newCell = Object.Instantiate(Get<CellBase>(findCellName));
            newCell.transform.position = new Vector3(gridX * OffsetCell, 0, gridY * OffsetCell) - spawnOffset;
            newCell.transform.parent = Map.transform;
            return newCell;
        }

        private Vector3 MiddleOffest(float cellOffset, Vector2Int gridSize)
        {
            float gridWidth = gridSize.y * cellOffset - cellOffset;
            float gridHeight = gridSize.x * cellOffset - cellOffset;
            return new Vector3(gridWidth, 0, gridHeight) / 2;
        }

        private void LoadPrefabs()
        {
            List<CellBase> listCells = new List<CellBase>();
            string[] guids = AssetDatabase.FindAssets(NAME_CELL_LOAD, new[] { PATH_PREFABS_CELL });
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                CellBase prefab = AssetDatabase.LoadAssetAtPath<CellBase>(path);

                if (prefab != null)
                    listCells.Add(prefab);
            }

            _array = listCells.ToArray();
        }

    }
}