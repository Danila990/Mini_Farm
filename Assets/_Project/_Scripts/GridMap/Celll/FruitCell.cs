using UnityEditor;
using UnityEngine;

namespace MiniFarm
{
    public class FruitCell : Cell
    {
        [SerializeField] private Fruit _fruit;

        public FruitType fruitType => _fruit.fruitType;

        public override void Event()
        {
            if (!_fruit.gameObject.activeInHierarchy) return;

            _fruit.DisableFruit();
        }

        public override void Restart()
        {
            _fruit.gameObject.SetActive(true);
        }

#if UNITY_EDITOR

        private const string PATH_PREFABS_FRUIT = "Assets/_Project/Prefabs/Fruit";
        private const string NAME_FRUIT_LOAD = "t:prefab";

        [Header("Fruit Changer"), SerializeField] private FruitType _needFruit;

        [Button("Change Fruit")]
        private void ChangeFruit()
        {
            if (_needFruit == _fruit.fruitType) return;

            if (_fruit != null)
                DestroyImmediate(_fruit.gameObject);

            string[] guids = AssetDatabase.FindAssets(NAME_FRUIT_LOAD, new[] { PATH_PREFABS_FRUIT });
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Fruit prefab = AssetDatabase.LoadAssetAtPath<Fruit>(path);

                if (prefab != null && prefab.fruitType == _needFruit)
                {
                    _fruit = Instantiate(prefab, transform);
                    return;
                }
            }
        }
#endif
    }
}