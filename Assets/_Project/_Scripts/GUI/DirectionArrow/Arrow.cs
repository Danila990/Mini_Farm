using UnityEngine;
using UnityEngine.UI;

namespace MiniFarm
{
    public class Arrow : UIButton
    {
        [field: SerializeField] public Direction direction { get; private set; }

        private DirectionArrow _directionArrow;
        private Button _button;

        public void Setup(DirectionArrow directionArrow)
        {
            _button = GetComponent<Button>();
            _directionArrow = directionArrow;
        }

        public void ChangeInterable(bool state)
        {
            _button.interactable = state;
        }

        protected override void OnClick()
        {
            _directionArrow.InputDirection(direction);
        }
    }
}