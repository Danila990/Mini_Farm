using UnityEngine;

namespace MiniFarm
{
    public class BasketFruit : MonoBehaviour
    {
        [SerializeField] private Transform _parentButton;
        [SerializeField] private BasketSettings _basketSettings;

        private BasketButton[] _basketButton;
        private FruitController _fruitController;

        [Inject]
        public void Setup(FruitController fruitController)
        {
            _fruitController = fruitController;
            CreateButtons(_fruitController.GetActualFruitTypes());
            ChangeFruitButton(_fruitController.currentFruitType);
        }

        public void ChangeFruitButton(FruitType typeFruit)
        {
            _fruitController.SetFruitType(typeFruit);

            foreach (BasketButton fruitButton in _basketButton)
            {
                if (fruitButton.fruitType.Equals(_fruitController.currentFruitType))
                    fruitButton.ChangeInteractable(false);
                else
                    fruitButton.ChangeInteractable(true);
            }
        }


        private void CreateButtons(FruitType[] fruitsTypes)
        {
            _basketButton = new BasketButton[fruitsTypes.Length];

            for (int i = 0; i < _basketButton.Length; i++)
            {
                BasketButton newButton = Instantiate(_basketSettings._buttonPrefab, _parentButton);
                BasketFruitData basketData = _basketSettings.GetBasketData(fruitsTypes[i]);
                newButton.SetupButton(basketData.fruitType, basketData.fruitIcon, this);
                _basketButton[i] = newButton;
            }
        }
    }
}