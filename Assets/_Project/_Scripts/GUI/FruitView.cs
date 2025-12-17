using TMPro;
using UnityEngine;

namespace MiniFarm
{
    public class FruitView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private FruitController _fruitController;

        private void Start()
        {
            _fruitController = ServiceLocator.Resolver.Resolve<FruitController>();
            UpdateText(_fruitController.currentCountFruit);
            _fruitController.OnFruit += UpdateText;
        }

        private void OnDestroy()
        {
            _fruitController.OnFruit -= UpdateText;
        }

        private void UpdateText(int count)
        {
            _text.text = $"{count}/{_fruitController.maxFruit}";
        }
    }
}