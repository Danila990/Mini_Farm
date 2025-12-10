using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniFarm
{
    public enum Direction
    {
        None = 0,
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4
    }
    public static class DirectionExtension
    {
        private static readonly Dictionary<Direction, Vector2Int> _directions = new Dictionary<Direction, Vector2Int>()
        {
                {Direction.None, Vector2Int.zero},
                {Direction.Up, Vector2Int.up},
                {Direction.Down, Vector2Int.down},
                {Direction.Left, Vector2Int.left},
                {Direction.Right, Vector2Int.right},
        };

        public static Quaternion ToQuaternionY(this Direction directionType)
        {
            return directionType switch
            {
                Direction.None => Quaternion.identity,
                Direction.Up => Quaternion.Euler(0, 0, 0),
                Direction.Down => Quaternion.Euler(0, 180, 0),
                Direction.Left => Quaternion.Euler(0, 270, 0),
                Direction.Right => Quaternion.Euler(0, 90, 0),
                _ => throw new ArgumentException("Direction type To Quaternion mistake"),
            };
        }

        public static Vector2Int ToVector(this Direction directionType)
        {
            if (_directions.TryGetValue(directionType, out Vector2Int index))
                return index;

            throw new ArgumentException("Direction type To Vector mistake");
        }

        public static Direction ToDirection(this Vector2Int directionType)
        {
            foreach (var direction in _directions)
            {
                if (direction.Value == directionType)
                    return direction.Key;
            }

            throw new ArgumentException("Vector To Direction type mistake");
        }
    }
}