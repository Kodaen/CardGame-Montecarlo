using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

// You can uncomment this line if you accidentally destroy the SoundsData SO and need to create another one.
// [CreateAssetMenu(menuName = "SoundsData")]
public class SoundsData : ScriptableObject
{
    [ListDrawerSettings(ShowFoldout = false, ShowItemCount = false)]
    public Sound[] Sounds;
}

[System.Serializable]
public class Sound
{
    [HorizontalGroup("Horizontal"), HideLabel]
    [GUIColor(nameof(GetDisplayColor))]
    public string Name;

    [HorizontalGroup("Horizontal", 70), HideLabel]
    [OnValueChanged(nameof(OnSoundTypeChanged))]
    public AudioGroup Group;

    [LabelText("Audio Clips")]
    [OnValueChanged(nameof(OnSettingsChanged), IncludeChildren = true)]
    public ClipSettings[] ClipsSettings;

    [HideInInspector]
    public AudioSource AudioSource;

    [HideInInspector]
    public ClipSettings CurrentClipSettings;

    private Color GetDisplayColor()
    {
        return (Group == AudioGroup.Sound) ? new(0, 0.7f, 1) : new(1, 0.7f, 0);
    }

    private void OnSoundTypeChanged()
    {
        if (AudioSource == null) return;
        AudioSource.UpdateAudioMixerGroup(Group);
    }

    private void OnSettingsChanged()
    {
        AudioManager.OnSettingsChanged();
        if (AudioSource == null) return;
        if (CurrentClipSettings == null) return;
        AudioSource.UpdateSettings(CurrentClipSettings);
    }

    public enum AudioGroup
    {
        Sound,
        Music
    }
}
