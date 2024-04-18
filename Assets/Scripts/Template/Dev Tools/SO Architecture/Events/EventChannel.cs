using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class EventChannel<T> : ScriptableObject
{
    public event Action<T> OnEvent;

    [Button, HideInEditorMode]
    public void RaiseEvent(T param)
    {
        OnEvent?.Invoke(param);
    }
}
