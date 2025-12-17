using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AlphaAnimation : MonoBehaviour 
{
    [SerializeField] private bool _playInStart = false;
    [SerializeField] private float _openDuration = 0.5f;
    [SerializeField] private float _closeDuration = 0.5f;

    private CanvasGroup _canvasGroup;

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
        Animation(_openDuration, 1);
    }

    public void Hide()
    {
        Tween tween = Animation(_closeDuration, 0f);
        tween.onKill += () => { gameObject.SetActive(false); };
    }

    private Tween Animation(float  duration, float targetAlpha)
    {
        return _canvasGroup.DOFade(targetAlpha, duration)
            .SetUpdate(UpdateType.Normal, true).
            SetEase(Ease.Linear);
    }
}
