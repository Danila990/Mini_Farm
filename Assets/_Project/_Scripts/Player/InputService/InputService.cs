using System.Collections.Generic;
using UnityEngine;

namespace MiniFarm
{
    public class InputService : MonoBehaviour, IInputService
    {
        private List<IInputControllable> _controllables = new List<IInputControllable>();
        protected bool _isActive = false;

        public void RegistControllable(IInputControllable controllable)
        {
            if (!_controllables.Contains(controllable))
                _controllables.Add(controllable);
        }

        public void UnregistControllable(IInputControllable controllable)
        {
            if (_controllables.Contains(controllable))
                _controllables.Remove(controllable);
        }

        public void ActiveState(bool activeState)
        {
            _isActive = activeState;
        }

        public void SetDirectionInput(Direction direction)
        {
            if (!_isActive || direction.Equals(Direction.None)) return;

            foreach (var controllable in _controllables)
                controllable.InputDirection(direction);
        }
    }
}