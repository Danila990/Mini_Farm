using MiniFarm;
using UnityEngine;
using UnityEngine.UI;

namespace MiniFarm
{
    public class BasketButton : UIButton
    {
        [SerializeField] private Image _icon;

        private Button _button;
        private BasketFruit _basketFruit;

        public FruitType fruitType { get; private set; }

        public void SetupButton(FruitType fruitType, Sprite icon, BasketFruit basketFruit)
        {
            _button = GetComponent<Button>();
            _basketFruit = basketFruit;
            this.fruitType = fruitType;
            _icon.sprite = icon;
        }
        
        public void ChangeInteractable(bool state) => _button.interactable = state;
        
        protected override void OnClick()
        {
            ServiceLocator.Resolver.Resolve<AudioSystem>().Play("ButtonClick");
            _basketFruit.ChangeFruitButton(fruitType);
        }
    }
}