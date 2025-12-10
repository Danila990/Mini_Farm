using System;
using UnityEditor;
using UnityEngine;

namespace MiniFarm.GridEditor
{
    [Serializable]
    public class ConstructorLine
    {
        public CellType[] lineY;
    }

    public class GridWindowEditor : EditorWindow
    {
        private const string BUTTON_NAME_CREATE_GRID = "Create Grid";
        private const string BUTTON_NAME_DESTROY_GRID = "Destroy Grid";
        private const string BUTTON_NAME_RESET_TYPES_TO_TEST_MAP = "Test map";
        private const string BUTTON_NAME_RESET_TO_BASE_TYPES = "Reset Grid to Base Types";

        [SerializeField] private GridCreator _gridCreator;

        private Vector2Int _sizeGrid = new Vector2Int(1, 1);
        private ConstructorLine[] _linesX;

        [MenuItem("Tools/Grid Window")]
        public static void ShowWindow() => GetWindow<GridWindowEditor>("Grid Window");

        private void OnEnable()
        {
            _gridCreator = new GridCreator();
            
            if (_gridCreator.Map == null)
                ResetGrid();
            else
                ConverGridMapToPreviewGrid();
        }

        private void OnGUI()
        {
            GridEditorExtension.CustomPropetry(this, "_gridCreator");

            EditorGUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();
            _sizeGrid = EditorGUILayout.Vector2IntField("Grid map SizeGrid", _sizeGrid);
            _sizeGrid = Vector2Int.Max(Vector2Int.Min(_sizeGrid, new Vector2Int(10, 10)), new Vector2Int(0, 0));
            if (GUILayout.Button("Create Prew map", GUILayout.Width(100)))
            {
                if (_sizeGrid.x > 0 && _sizeGrid.y > 0)
                    CreateBaseGridBySize(_sizeGrid);
            }
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(BUTTON_NAME_CREATE_GRID))
                _gridCreator.CreateGrid(ConvertPreviewGridToCellTypes());
            if (GUILayout.Button(BUTTON_NAME_DESTROY_GRID))
                _gridCreator.DestroyGrid();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(BUTTON_NAME_RESET_TYPES_TO_TEST_MAP))
                ResetGrid();
            if (GUILayout.Button(BUTTON_NAME_RESET_TO_BASE_TYPES))
                ResetTypes();
            EditorGUILayout.EndHorizontal();

            GridEditorExtension.MidlleText("GridMap", 15, 5);
            DrawPreviewGrid();
        }

        #region Draw Preview Grid

        private CellType[,] ConvertPreviewGridToCellTypes()
        {
            if (_linesX == null || _linesX.Length == 0) return new CellType[0, 0];

            int width = _linesX.Length;
            int height = _linesX[0].lineY.Length;
            CellType[,] platforms = new CellType[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    platforms[x, y] = _linesX[x].lineY[y];

            return platforms;
        }

        /*private CellType[,] ConvertGridMood()
        {
            CellType[,] platfromTypes = ConvertPreviewGridToCellTypes();
            int originalWidth = platfromTypes.GetLength(0);
            int originalHeight = platfromTypes.GetLength(1);

            int width = originalWidth + 2;
            int height = originalHeight + 2;
            CellType[,] gridPlatforms = new CellType[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    gridPlatforms[x, y] = CellType.Empty;

            for (int x = 0; x < originalWidth; x++)
                for (int y = 0; y < originalHeight; y++)
                    gridPlatforms[x + 1, y + 1] = platfromTypes[x, y];

            return gridPlatforms;
        }*/

        private void ConverGridMapToPreviewGrid()
        {
            if (_gridCreator.Map == null) return;

            var cell = _gridCreator.Map.GetCells();

            _linesX = new ConstructorLine[cell.Length];
            for (int x = 0; x < _linesX.Length; x++)
            {
                _linesX[x] = new ConstructorLine();
                _linesX[x].lineY = new CellType[cell[x].Values.Length];
                for (int y = 0; y < _linesX[x].lineY.Length; y++)
                    _linesX[x].lineY[y] = cell[x].Values[y].CellType;
            }
        }

        private void ResetGrid()
        {
            _linesX = new ConstructorLine[3]
            {
                    new ConstructorLine(){
                        lineY = new CellType[3]{ CellType.Player, CellType.Base, CellType.Fruit }
                    },
                    new ConstructorLine(){
                        lineY = new CellType[3]{ CellType.Empty, CellType.Fruit, CellType.Rock }
                    },
                    new ConstructorLine(){
                        lineY = new CellType[3]{ CellType.Fruit, CellType.Base, CellType.Finish }
                    }
            };
        }

        private void CreateBaseGridBySize(Vector2Int size)
        {
            _linesX = new ConstructorLine[size.x];
            for (int x = 0; x < size.x; x++)
            {
                _linesX[x] = new ConstructorLine();
                _linesX[x].lineY = new CellType[size.y];
                for (int y = 0; y < size.y; y++)
                    _linesX[x].lineY[y] = CellType.Base;
            }
        }

        private void ResetTypes()
        {
            if (_linesX == null) return;

            for (int x = 0; x < _linesX.Length; x++)
                for (int y = 0; y < _linesX[x].lineY.Length; y++)
                    _linesX[x].lineY[y] = CellType.Base;
        }

        private void DrawPreviewGrid()
        {
            if (_linesX == null || _linesX.Length == 0) return;

            for (int x = 0; x < _linesX.Length; x++)
            {
                EditorGUILayout.Space(5);
                EditorGUILayout.BeginHorizontal(GUILayout.Width(100));

                for (int y = 0; y < _linesX[x].lineY.Length; y++)
                {
                    EditorGUILayout.BeginVertical(GUILayout.Width(60));

                    Rect rect = GUILayoutUtility.GetRect(20, 20);
                    EditorGUI.DrawRect(rect, GetCellColor(_linesX[x].lineY[y]));

                    _linesX[x].lineY[y] = (CellType)EditorGUILayout.EnumPopup(_linesX[x].lineY[y]);
                    if(_gridCreator.Map != null && _gridCreator.Map.GetSize() == new Vector2Int(_linesX.Length, _linesX[x].lineY.Length))
                    {
                        Cell cell = _gridCreator.Map.GetCells()[x].Values[y];
                        EditorGUILayout.ObjectField(cell.gameObject, typeof(Cell), true);
                    }

                    EditorGUILayout.EndVertical();
                    EditorGUILayout.Space(5);
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        private Color GetCellColor(CellType platformType)
        {
            return platformType switch
            {
                CellType.Base => Color.white,
                CellType.Player => Color.green,
                CellType.Empty => Color.black,
                CellType.Finish => Color.blue,
                CellType.Fruit => Color.yellow,
                CellType.Rock => Color.red,
                _ => Color.gray,
            };
        }
        #endregion
    }
}