using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class BannerScript : MonoBehaviour
{
    private TextMeshProUGUI _tmpText;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _tmpText = transform.GetComponentInChildren<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _rectTransform.DOLocalMoveY(8, 1.25f).SetRelative().SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

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
