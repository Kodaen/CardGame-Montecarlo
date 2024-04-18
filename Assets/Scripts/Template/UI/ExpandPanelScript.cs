using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExpandPanelScript : MonoBehaviour
{
    [SerializeField] private float _punchDuration = 0.2f;
    [SerializeField] private float _fadeDuration = 0.3f;

    private RectTransform _rectTransform;
    private Tween _tween;
    private bool _isEnable;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        _tween = _rectTransform.DOScale(1, _fadeDuration).From(0).SetEase(Ease.InOutSine)
            .Pause().SetAutoKill(false).OnRewind(() => gameObject.SetActive(false)).
            OnComplete(() => _rectTransform.DOPunchScale(0.1f * Vector3.one, _punchDuration));
    }

    private void OnDestroy() => _rectTransform.DOKill();

    public void EnablePanel(bool enable)
    {
        _isEnable = enable;

        if (enable)
        {
            gameObject.SetActive(true);
            _tween.PlayForward();
        }

        else _tween.PlayBackwards();
    }

    public void SwitchPanel()
    {
        EnablePanel(!_isEnable);
    }
}
