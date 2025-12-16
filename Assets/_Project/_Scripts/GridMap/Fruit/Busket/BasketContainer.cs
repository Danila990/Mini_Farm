using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MiniFarm
{
    [CreateAssetMenu(fileName = "BasketSettings", menuName = "BasketSettings")]
    public class BasketSettings : ScriptableObject
    {
        [SerializeField] private List<BasketFruitData> _basketFruits = new List<BasketFruitData>();

        [field: SerializeField] public BasketButton _buttonPrefab { get; private set; }

        public BasketFruitData GetBasketData(FruitType needFruitType)
        {
            return _basketFruits.FirstOrDefault(data => data.fruitType == needFruitType);
        }
    }

    [Serializable]
    public class BasketFruitData
    {
        [field: SerializeField] public FruitType fruitType { get; private set; }
        [field: SerializeField] public Sprite fruitIcon { get; private set; }
    }
}