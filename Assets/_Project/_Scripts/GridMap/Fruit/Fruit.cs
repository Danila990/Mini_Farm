using DG.Tweening;
using UnityEngine;

namespace MiniFarm
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deactivateEffect;
        [SerializeField] private float _targety = 2f;
        [SerializeField] private float _duraction = 0.5f;

        [field: SerializeField] public FruitType fruitType { get; private set; }

        private Tween _animTween;

        private void Awake()
        {
            _animTween = transform.DOMoveY(_targety, _duraction)
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void OnEnable()
        {
            _animTween.Play();
        }

        public void DisableFruit()
        {
            var effect = Instantiate(_deactivateEffect, transform.position, Quaternion.identity);
            Destroy(effect.gameObject, 0.5f);
            _animTween.Pause();
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _animTween?.Kill();
        }
    }
}