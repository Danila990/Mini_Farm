using TMPro;
using UnityEngine;

namespace MiniFarm
{
    public class FruitView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private FruitCounter _fruitCounter;

        private void Start()
        {
            _fruitCounter = ServiceLocator.Get<FruitCounter>();
            UpdateText(_fruitCounter.currentFruit, _fruitCounter.maxFruit);
            _fruitCounter.OnFruit += UpdateText;
        }

        private void OnDestroy()
        {
            _fruitCounter.OnFruit -= UpdateText;
        }

        private void UpdateText(int count, int max)
        {
            _text.text = $"{count}/{max}";
        }
    }
}