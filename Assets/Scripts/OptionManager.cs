using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Slider volumeSlider;

    private Resolution[] resolutions;

    private void Start()
    {
        PopulateQualityDropdown();
        PopulateResolutionDropdown();
        InitializeSettings();

        qualityDropdown.onValueChanged.AddListener(ChangeQualityLevel);
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscreen);
        resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
        volumeSlider.onValueChanged.AddListener(ChangeMasterVolume);
    }

    private void PopulateQualityDropdown()
    {
        qualityDropdown.ClearOptions();
        string[] qualityNames = QualitySettings.names;
        qualityDropdown.AddOptions(new System.Collections.Generic.List<string>(qualityNames));
    }

    private void PopulateResolutionDropdown()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        foreach (Resolution res in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData($"{res.width}x{res.height}@{res.refreshRate}Hz"));
        }
    }

    private void InitializeSettings()
    {
        int savedQualityLevel = PlayerPrefs.GetInt("QualityLevel", QualitySettings.GetQualityLevel());
        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", GetMaxResolutionIndex());
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);

        qualityDropdown.value = savedQualityLevel;
        resolutionDropdown.value = savedResolutionIndex;
        fullscreenToggle.isOn = savedFullscreen;
        volumeSlider.value = savedVolume;

        ApplySettings();
    }

    private void ApplySettings()
    {
        ChangeQualityLevel(qualityDropdown.value);
        ChangeResolution(resolutionDropdown.value);
        ToggleFullscreen(fullscreenToggle.isOn);
        ChangeMasterVolume(volumeSlider.value);
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetInt("QualityLevel", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("MasterVolume", volumeSlider.value);

        PlayerPrefs.Save();
    }

    public void ChangeQualityLevel(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        SaveSettings();
    }

    public void ChangeResolution(int resolutionIndex)
    {
        if (resolutionIndex >= 0 && resolutionIndex < resolutions.Length)
        {
            Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
            SaveSettings();
        }
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        SaveSettings();
    }

    public void ChangeMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        SaveSettings();
    }

    private int GetMaxResolutionIndex()
    {
        int maxIndex = 0;
        int maxWidth = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width > maxWidth)
            {
                maxWidth = resolutions[i].width;
                maxIndex = i;
            }
        }
        return maxIndex;
    }
}
