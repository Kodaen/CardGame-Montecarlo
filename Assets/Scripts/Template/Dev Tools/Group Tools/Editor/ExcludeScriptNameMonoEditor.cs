using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExcludeScriptNameMono), true)]
public class ExcludeScriptNameMonoEditor : Editor
{
    private readonly string _scriptName = "m_Script";

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawPropertiesExcluding(serializedObject, _scriptName);
        serializedObject.ApplyModifiedProperties();
    }
}
