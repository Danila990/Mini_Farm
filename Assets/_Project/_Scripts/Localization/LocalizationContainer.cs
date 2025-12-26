using System;
using UnityEngine;
using YG;

namespace MiniFarm
{
    [CreateAssetMenu(fileName = nameof(LocalizationContainer), menuName = "MySo/LocalizationContainer")]
    public class LocalizationContainer : ScriptableObject
    {
        [SerializeField] private TextInfo[] _infos;

        public string GetText(int id)
        {
            var text = _infos[id];
            if (YG2.envir.language != "en")
                return text.Ru;
            else
                return text.En;
        }
    }

    [Serializable]
    public struct TextInfo
    {
        public string Ru;
        public string En;
    }
}