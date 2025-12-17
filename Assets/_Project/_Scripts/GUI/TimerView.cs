using TMPro;
using UnityEngine;

namespace MiniFarm
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private LevelTimer _levelTimer;

        private void Start()
        {
            _levelTimer = ServiceLocator.Resolver.Resolve<LevelTimer>();
            UpdateText(_levelTimer.time);
            _levelTimer.OnTime += UpdateText;
        }

        private void OnDestroy()
        {
            _levelTimer.OnTime -= UpdateText;
        }

        private void UpdateText(int time)
        {
            _text.text = $"{time}";
        }
    }
}