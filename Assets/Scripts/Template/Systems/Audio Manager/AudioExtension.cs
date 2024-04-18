using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class AudioExtension
{
    private static readonly string AudioMixerPath = "AudioMixer";

    public static void UpdateSettings(this AudioSource audioSource, ClipSettings clipSettings)
    {
        audioSource.clip = clipSettings.Clip;
        audioSource.volume = clipSettings.Volume;
        audioSource.loop = clipSettings.Loop;
        if (!clipSettings.RandomPitch)
        {
            audioSource.pitch = clipSettings.Pitch;
        }
    }

    public static void UpdatePitch(this AudioSource audioSource, ClipSettings clipSettings)
    {
        if (clipSettings.RandomPitch)
        {
            audioSource.pitch = Random.Range(clipSettings.MinPitch, clipSettings.MaxPitch);
        }
    }

    public static void UpdateAudioMixerGroup(this AudioSource audioSource, Sound.AudioGroup soundGroup)
    {
        AudioMixer audioMixer = Resources.Load<AudioMixer>(AudioMixerPath);
        string groupPath = soundGroup.ToString();
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups(groupPath)[0];
    }
}
