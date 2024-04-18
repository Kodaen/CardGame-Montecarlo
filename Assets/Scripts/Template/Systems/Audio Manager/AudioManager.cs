using System;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField, HideInInspector]
    private AudioSource _audioSourcePreview;

    [SerializeField, HideInInspector]
    private ClipSettings _clipSettingsPreview;

    [SerializeField, InlineEditor(Expanded = true)]
    private SoundsData _soundsData;

    private void Reset()
    {
        _audioSourcePreview = GetComponent<AudioSource>();
        _audioSourcePreview.playOnAwake = false;
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        InitAudioSources();
    }

    private void InitAudioSources()
    {
        if (_soundsData == null) return;

        foreach (Sound sound in _soundsData.Sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.UpdateAudioMixerGroup(sound.Group);
        }
    }

    private void Start()
    {
        Play("Music1");
    }

    public void Play(string soundName)
    {
        Sound sound = Array.Find(_soundsData.Sounds, sound => sound.Name == soundName);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found !");
            return;
        }

        if (sound.ClipsSettings.Length == 0)
        {
            Debug.LogWarning("Sound: " + soundName + " has no Audio Clip !");
            return;
        }

        ClipSettings clipSettings = sound.ClipsSettings.GetRandom();
        AudioSource audioSource = sound.AudioSource;

        sound.CurrentClipSettings = clipSettings;
        audioSource.UpdateSettings(clipSettings);
        audioSource.UpdatePitch(clipSettings);
        audioSource.Play();
    }

    public void Stop(string soundName)
    {
        Sound sound = Array.Find(_soundsData.Sounds, sound => sound.Name == soundName);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found !");
            return;
        }

        sound.AudioSource.Stop();
    }

    #region Editor Methods

    public static void PreviewAudio(ClipSettings clipSettings)
    {
        if (Instance == null) Instance = FindObjectOfType<AudioManager>();
        if (Instance == null) return;

        AudioSource audioSourcePreview = Instance._audioSourcePreview;
        Instance._clipSettingsPreview = clipSettings;

        audioSourcePreview.UpdateSettings(clipSettings);
        audioSourcePreview.UpdatePitch(clipSettings);

        if (audioSourcePreview.isPlaying) audioSourcePreview.Stop();
        else audioSourcePreview.Play();
    }

    public static void OnSettingsChanged()
    {
        if (Instance == null) Instance = FindObjectOfType<AudioManager>();
        if (Instance == null) return;

        AudioSource audioSourcePreview = Instance._audioSourcePreview;
        ClipSettings clipSettings = Instance._clipSettingsPreview;

        if (clipSettings == null) return;
        audioSourcePreview.UpdateSettings(clipSettings);
    }

    #endregion
}