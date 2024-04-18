using UnityEngine;
using System;
using Sirenix.OdinInspector;

[InlineProperty]
public class Reference<T>
{
    [SerializeField, HideInInspector]
    private bool _useValue = true;

    [ShowIf(nameof(_useValue), Animate = false)]
    [HorizontalGroup("Reference")]
    [SerializeField, HideLabel]
    private T _constantValue;

    [InlineEditor, GUIColor(0.85f, 0.85f, 1)]
    [HideIf(nameof(_useValue), Animate = false)]
    [HorizontalGroup("Reference")]
    [SerializeField, HideLabel]
    private Variable<T> _variable;

    [HorizontalGroup("Reference", 30)]
    [Button(SdfIconType.ArrowLeftRight, Name = "")]
    protected void Switch()
    {
        _useValue = !_useValue;
    }

    public T Value
    {
        get
        { 
            if (_variable == null || _useValue) return _constantValue;
            return _variable.Value;
        }
    }
}

[Serializable]
public class IntReference : Reference<int> { }

[Serializable]
public class FloatReference : Reference<float> { }

[Serializable]
public class BoolReference : Reference<bool> { }

[Serializable]
public class StringReference : Reference<string> { }

[Serializable]
public class Vector2Reference : Reference<Vector2> { }

[Serializable]
public class Vector3Reference : Reference<Vector3> { }

[Serializable]
public class ColorReference : Reference<Color> { }
