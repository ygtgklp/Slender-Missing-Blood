using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("GameLevel")]
    public string GameLevel;

    [Header("Volume Setting")]
    [SerializeField] private Text volumeTextValue = null;
    [SerializeField] private Slider SoundSlider = null;

    [Header("Graphic Setting")]
    private bool _isFullscreen;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    void Start()
    {
        AudioListener.volume = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayClick()
    {
        SceneManager.LoadScene(GameLevel);
    }

    public void ExitClick()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void SetFullScreen(bool isFullScreen)
    {
        _isFullscreen = isFullScreen;
    }

    public void GraphicApply()
    {
        PlayerPrefs.SetInt("MasterFullscreen", (_isFullscreen ? 1 : 0));
        Screen.fullScreen = _isFullscreen;

        StartCoroutine(ConfirmationBox());
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
