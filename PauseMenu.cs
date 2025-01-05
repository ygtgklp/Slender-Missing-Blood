using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseCanvas;
    public static bool Paused = false;

    [Header("GameLevel")]
    public string MainMenu;

    [Header("Volume Setting")]
    [SerializeField] private Text volumeTextValue = null;
    [SerializeField] private Slider SoundSlider = null;

    [Header("Graphic Setting")]
    private bool _isFullscreen;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

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

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerInput.ActionEvent actionEvent = null;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(MainMenu);
        Paused = false;
        AudioListener.pause = false;
    }

    public void ExitClick()
    {
        Application.Quit();
    }
}
