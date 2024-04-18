using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExcludeScriptNameSO), true)]
public class ExcludeScriptNameSOEditor : Editor
{
    private readonly string _scriptName = "m_Script";

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawPropertiesExcluding(serializedObject, _scriptName);
        serializedObject.ApplyModifiedProperties();
    }
}
