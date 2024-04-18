using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private IntVariable _health, _maxHealth;

    private void OnEnable()
    {
        _health.OnValueChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.OnValueChanged -= UpdateHealth;
    }

    private void UpdateHealth()
    {
        _fillImage.fillAmount = _health.Value * 1.0f / _maxHealth.Value;
    }
}
