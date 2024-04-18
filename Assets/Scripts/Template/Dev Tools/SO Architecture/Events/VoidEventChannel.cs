using UnityEngine;
using System;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Events/void", order = 0)]
public class VoidEventChannel : ScriptableObject
{
    public event Action OnEvent;

    [Button, HideInEditorMode]
    public void RaiseEvent()
    {
        OnEvent?.Invoke();
    }
}
