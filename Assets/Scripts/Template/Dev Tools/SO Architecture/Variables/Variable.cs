using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class Variable<T> : ScriptableObject
{
    [SerializeField, HideLabel]
    [OnValueChanged(nameof(InspectorOnValueChanged))]
    private T _value;

    public T Value
    {
        get
        {
            return _value;
        }

        set
        {
            LastValue = _value;
            _value = value;
            OnValueChanged?.Invoke();
        }
    }

    public T LastValue { get; private set; }

    public event Action OnValueChanged;

    private void InspectorOnValueChanged()
    {
        if (!Application.isPlaying) return;
        OnValueChanged?.Invoke();
    }
}
