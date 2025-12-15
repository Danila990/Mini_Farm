using System;
using UnityEngine;

namespace MiniFarm
{
    [Serializable]
    public class GameSettings
    {
        [field: SerializeField] public int levelDuration { get; private set; } = 15;
    }
}