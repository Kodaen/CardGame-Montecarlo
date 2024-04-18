using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGroup : GroupTool
{
    [SerializeField] private Color _color;
    private SpriteRenderer[] _spriteRenderers;

    private void Awake() => LoadData();

    public override void LoadData()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public override void UpdateData()
    {
        if (_spriteRenderers != null) SetColor(_color);
    }

    public void SetColor(Color color)
    {
        _color = color;
        foreach (SpriteRenderer sr in _spriteRenderers) sr.color = color;
    }
}
