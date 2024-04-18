using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class GroupTool : MonoBehaviour
{
    public abstract void LoadData();
    public abstract void UpdateData();

    private void OnValidate()
    {
        UpdateData();
    }
}
