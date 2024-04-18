using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using Sirenix.OdinInspector;

public class SettingsScript : MonoBehaviour
{
    [Title("UI Elements")]
    [SerializeField] private Toggle _fullScreenToggle;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    [Title("Audio Settings")]
    [SerializeField, AssetsOnly]
    private AudioMixer _audioMixer;

    private void Awake()
    {
        InitResolution();
        InitVolume();
    }

    private void InitResolution()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            _fullScreenToggle.interactable = false;
            _resolutionDropdown.interactable = false;
            return;
        }

        _fullScreenToggle.isOn = Screen.fullScreen;

        List<string> options = Screen.resolutions.Select(r => r.width + "x" + r.height).ToList();
        _resolutionDropdown.AddOptions(options);

        string currentOption = Screen.currentResolution.width + "x" + Screen.currentResolution.height;
        _resolutionDropdown.value = options.FindIndex(o => o == currentOption);
        _resolutionDropdown.RefreshShownValue();
    }

    private void InitVolume()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            _soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, _fullScreenToggle.isOn);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSoundVolume(float volume)
    {
        _audioMixer.SetFloat("SoundVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }
}
