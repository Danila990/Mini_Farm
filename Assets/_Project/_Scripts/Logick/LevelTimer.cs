using System;
using System.Collections;
using UnityEngine;

namespace MiniFarm
{
    public class LevelTimer : MonoBehaviour
    {
        public event Action<int> OnTime;

        public int time {  get; private set; }

        [Inject]
        public void Setup(GameSettings gameSettings)
        {
            time = gameSettings.levelDuration;
        }

        public void StartTimer()
        {
            StartCoroutine(TickTimer());
        }

        private IEnumerator TickTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                time--;
                OnTime?.Invoke(time);
            }
        }
    }
}