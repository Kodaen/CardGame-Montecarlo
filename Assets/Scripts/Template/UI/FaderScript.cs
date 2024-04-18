using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FaderScript : MonoBehaviour
{
    private Image _blackImage;
    private Tween _tween;

    [SerializeField] private float _duration = 0.3f;
    [SerializeField] private float _endValue;
    private bool _isEnable = false;

    private void Awake()
    {
        _blackImage = GetComponent<Image>();

        _tween = _blackImage.DOFade(_endValue, _duration).From(0).SetEase(Ease.InOutSine)
            .Pause().SetAutoKill(false).OnRewind(() => gameObject.SetActive(false)); ;
    }

    private void OnDestroy() => _blackImage.DOKill();

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
