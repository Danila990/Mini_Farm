using System.Linq;
using UnityEngine;

namespace MiniFarm
{
    [CreateAssetMenu(fileName = nameof(LevelSettings), menuName = nameof(LevelSettings))]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private LevelData[] _levels;

        public int LevelCount => _levels.Length;

        public LevelData GetLevelData(int levelNumber)
        {
            return _levels.FirstOrDefault(_ => _.levelNumber == levelNumber);
        }
    }
}