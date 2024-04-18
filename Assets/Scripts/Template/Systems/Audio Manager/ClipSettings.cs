using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class ClipSettings
{
    [HideLabel]
    [InlineButton(nameof(PlayPreview), Icon = SdfIconType.PlayFill, Label = "")]
    public AudioClip Clip;

    [FoldoutGroup("Settings")]
    [LabelWidth(80)]
    [Range(0f, 1f)]
    public float Volume = 1;

    [FoldoutGroup("Settings")]
    [LabelWidth(80)]
    [Range(.1f, 3f)]
    public float Pitch = 1;

    [FoldoutGroup("Settings")]
    [LabelWidth(80)]
    [HorizontalGroup("Settings/Bool")]
    public bool Loop;

    [FoldoutGroup("Settings")]
    [LabelWidth(100)]
    [HorizontalGroup("Settings/Bool")]
    public bool RandomPitch;

    [FoldoutGroup("Settings")]
    [LabelWidth(80)]
    [ShowIf(nameof(RandomPitch))]
    [Range(.1f, 3f)]
    public float MinPitch = 1;

    [FoldoutGroup("Settings")]
    [LabelWidth(80)]
    [ShowIf(nameof(RandomPitch))]
    [Range(.1f, 3f)]
    public float MaxPitch = 1;

    private void PlayPreview()
    {
        AudioManager.PreviewAudio(this);
    }
}