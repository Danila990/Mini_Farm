using UnityEngine;

namespace MiniFarm
{
    [CreateAssetMenu(fileName = nameof(LevelData), menuName = nameof(LevelData))]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public Direction directionPlayer { get; private set; }
        [field: SerializeField] public int levelNumber { get; private set; } = 1;
        [field: SerializeField] public int levelDuration { get; private set; } = 15;
        [field: SerializeField] public GridMap gridMap { get; private set; }
    }
}