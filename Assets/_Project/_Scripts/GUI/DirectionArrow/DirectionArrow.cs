using UnityEngine;
using YG;

namespace MiniFarm
{
    public class DirectionArrow : MonoBehaviour, IInputControllable
    {
        private Arrow[] _arrows;
        private IInputService _inputService;

        private void Start()
        {
            if (!YG2.envir.isMobile)
            {
                gameObject.SetActive(false);
                return;
            }

            _inputService = ServiceLocator.Resolver.Resolve<IInputService>();
            _inputService.RegistControllable(this);
            _arrows = GetComponentsInChildren<Arrow>();
            foreach (var arrow in _arrows)
                arrow.Setup(this);
        }

        public void ClickArrow(Direction direction)
        {
            _inputService.SetDirectionInput(direction);
        }

        public void InputDirection(Direction direction)
        {
            UpdateArrow(direction);
        }

        private void UpdateArrow(Direction direction)
        {
            foreach (var arrow in _arrows)
            {
                if (arrow.direction == direction)
                    arrow.ChangeInterable(false);
                else
                    arrow.ChangeInterable(true);
            }
        }
    }
}