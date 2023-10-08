using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject OptionsPanel;
    public Button returnButton;
    public Button exitButton;
    public Button OptionsButton;
    public Button backButton;
    private bool isPaused = false;
    private Movement mvmt;

    private void Start()
    {
        returnButton.onClick.AddListener(ReturnToGame);
        exitButton.onClick.AddListener(ExitToMainMenu);
        OptionsButton.onClick.AddListener(OpenOptions);
        backButton.onClick.AddListener(ReturnToPauseMenu);
        mvmt = FindObjectOfType<Movement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                if (OptionsPanel.activeInHierarchy)
                {
                    OptionsPanel.SetActive(false);
                }
            }
            else
            {
                PauseGame();
            }
        }
    }

    void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PausePanel.SetActive(false);
        GetAllAudioSources(true);
        Time.timeScale = 1f;
        mvmt.enabled = true;
        isPaused = false;
    }

    void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PausePanel.SetActive(true);
        GetAllAudioSources(false);
        Time.timeScale = 0f;
        mvmt.enabled = false;
        isPaused = true;
    }

    void ReturnToGame()
    {
        ResumeGame();
        if (OptionsPanel.activeInHierarchy)
        {
            OptionsPanel.SetActive(false);
        }
    }

    void ExitToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    void GetAllAudioSources(bool value)
    {
        AudioSource[] sources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

        foreach (var s in sources)
        {
            s.enabled = value;
        }
    }

    void OpenOptions()
    {
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    void ReturnToPauseMenu()
    {
        OptionsPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
}
