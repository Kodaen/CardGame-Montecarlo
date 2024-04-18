using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedSpriteGroup : GroupTool
{
    [SerializeField] private Vector2 _size;
    private SpriteRenderer[] _spriteRenderers;

    public override void LoadData()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public override void UpdateData()
    {
        if (_spriteRenderers != null) StartCoroutine(SetSize());
    }

    // Unity doesn't like to set size during OnValidate, so I delay it from one frame.
    private IEnumerator SetSize()
    {
        yield return new WaitForEndOfFrame();
        foreach (SpriteRenderer sr in _spriteRenderers) sr.size = _size;
    }
}
