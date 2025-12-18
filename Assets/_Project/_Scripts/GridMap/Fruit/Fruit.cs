using DG.Tweening;
using UnityEngine;

namespace MiniFarm
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deactivateEffect;
        [SerializeField] private float _moveOffsetY = 2f;
        [SerializeField] private float _moveDuration = 0.5f;
        [SerializeField] private float _rotateDuration= 2f;

        [field: SerializeField] public FruitType fruitType { get; private set; }

        private void Awake()
        {
            transform.DOMoveY(_moveOffsetY, _moveDuration).
                SetLoops(-1, LoopType.Yoyo);

            transform.DORotate(new Vector3(0, -360f, 0), _rotateDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1)
                .SetRelative();
        }

        private void OnEnable()
        {
            DOTween.Play(transform);
        }

        public void DisableFruit()
        {
            var effect = Instantiate(_deactivateEffect, transform.position, Quaternion.identity);
            Destroy(effect.gameObject, 0.5f);
            DOTween.Pause(transform);
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            DOTween.Kill(transform);
        }
    }
}