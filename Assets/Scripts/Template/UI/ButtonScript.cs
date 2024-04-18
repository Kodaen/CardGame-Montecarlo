using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ButtonScript : MonoBehaviour
{
    private RectTransform _rectTransform;
    private TextMeshProUGUI _tmpText;
    private Button _button;

    private Tween tweenScale;
    private Tween tweenShake;

    [SerializeField] private float _duration = 0.15f;
    [SerializeField] private float _scale = 1.1f;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _button = GetComponent<Button>();
        _tmpText = GetComponentInChildren<TextMeshProUGUI>();

        tweenScale = _rectTransform.DOScale(_scale, _duration).SetEase(Ease.InOutSine).Pause().SetAutoKill(false);
        tweenShake = _rectTransform.DOPunchScale(-0.05f * Vector3.one, _duration).SetEase(Ease.InOutSine).Pause().SetAutoKill(false);
    }

    public void OnPointerEnter()
    {
        if (!_button.interactable) return;
        tweenScale.PlayForward();
    }

    public void OnPointerExit()
    {
        tweenScale.PlayBackwards();
    }

    public void OnPointerClick()
    {
        if (!_button.interactable) return;
        tweenShake.Restart();
    }

    public void EnableButton(bool enable) => _button.interactable = enable;
    private void OnDestroy() => _rectTransform.DOKill();

    public void ChangeText(string newText)
    {
        if (_tmpText == null)
        {
            Debug.Log("MainText du bouton " + name + " non trouvé");
            return;
        }
        _tmpText.text = newText;
    }
}
