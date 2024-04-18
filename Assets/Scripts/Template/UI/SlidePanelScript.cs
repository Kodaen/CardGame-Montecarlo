using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidePanelScript : MonoBehaviour
{
    [SerializeField] Vector2 _targetPosition = Vector2.zero;
    [SerializeField] private float _duration = 0.4f;

    private RectTransform _rectTransform;
    private Tween _tween;
    private bool _isEnable;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        _tween = _rectTransform.DOAnchorPos(_targetPosition, _duration).SetEase(Ease.InOutBack).Pause().SetAutoKill(false);
    }

    private void OnDestroy() => _rectTransform.DOKill();

    public void EnablePanel(bool enable)
    {
        _isEnable = enable;
        if (enable) _tween.PlayForward();
        else _tween.PlayBackwards();
    }

    public void SwitchPanel()
    {
        EnablePanel(!_isEnable);
    }
}
