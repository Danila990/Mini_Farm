using System;
using UnityEngine;

namespace MiniFarm
{
    public class KeybordInput : InputService
    {
        private void Update()
        {
            if (!_isActive) return;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                SetDirectionInput(Direction.Up);
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                SetDirectionInput(Direction.Down);
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                SetDirectionInput(Direction.Left);
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                SetDirectionInput(Direction.Right);
        }
    }
}