using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MiniFarm
{
    [System.Serializable]
    public struct ArrayLine<T> 
    {
        public T[] Values;
    }

    [System.Serializable]
    public class MultiArray<T> where T : Object
    {
        [SerializeField] private ArrayLine<T>[] _values;

        public int CountX => _values.Length;
        public int CountY => _values[0].Values.Length;

        public Vector2Int SizeGrid => new Vector2Int(CountX, CountY);

        public void Set(ArrayLine<T>[] values) => _values = values;

        public ArrayLine<T>[] GetAll() => _values;

        public T Get(int x, int y)
        {
            if (!Check(x, y))
                throw new ArgumentException($"Data index error: X-{x}, Y-{y}");

            return _values[x].Values[y];
        }

        public bool Check(int x, int y)
        {
            if (x < 0 || y < 0 || x >= CountX || y >= CountY)
                return false;

            return true;
        }

        public T[,] Convert()
        {
            T[,] newArray = new T[CountX, CountY];
            for (int x = 0; x < CountX; x++)
                for (int y = 0; y < CountY; y++)
                    newArray[x, y] = _values[x].Values[y];

            return newArray;
        }
    }
}