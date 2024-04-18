using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GroupTool), true)]
public class GroupToolEditor : ExcludeScriptNameMonoEditor
{
    public override void OnInspectorGUI()
    {
        GroupTool tool = (GroupTool)target;
        if (GUILayout.Button("Load Data")) tool.LoadData();
        base.OnInspectorGUI();
    }
}
