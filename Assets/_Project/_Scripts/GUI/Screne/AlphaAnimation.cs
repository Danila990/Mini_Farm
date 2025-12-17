using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AlphaAnimation : MonoBehaviour 
{
    [SerializeField] private bool _playInStart = false;
    [SerializeField] private float _openDuration = 0.5f;
    [SerializeField] private float _closeDuration = 0.5f;

    private CanvasGroup _canvasGroup;

    private Tween _tween;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_playInStart)
        {
            Show();
        }
    }

    public void Show()
    {
        _canvasGroup.alpha = 0f;
        _tween?.Kill();
        _tween = Animation(_openDuration, 1);
    }

    public void Hide()
    {
        _tween?.Kill();
        _tween = Animation(_closeDuration, 0f);
        _tween.onComplete += () => { gameObject.SetActive(false); };
    }

    private void OnDestroy()
    {
        _tween?.Kill();
    }

    private Tween Animation(float  duration, float targetAlpha)
    {
        return _canvasGroup.DOFade(targetAlpha, duration)
            .SetUpdate(UpdateType.Normal, true).
            SetEase(Ease.Linear);
    }
}
