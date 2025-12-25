using System;
using UnityEngine;

namespace MiniFarm
{
    [CreateAssetMenu(fileName = nameof(LocalizationContainer), menuName = "MySo/LocalizationContainer")]
    public class LocalizationContainer : ScriptableObject
    {
        [SerializeField] private TextInfo[] _infos;

        public TextInfo GetText(int id)
        {
            return _infos[id];
        }
    }

    [Serializable]
    public struct TextInfo
    {
        public string Ru;
        public string En;
    }
}