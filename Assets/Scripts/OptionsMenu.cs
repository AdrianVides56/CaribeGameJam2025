using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetFullScreen(bool value)
    {
        Screen.fullScreen = value;
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void ChangeQuality(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
