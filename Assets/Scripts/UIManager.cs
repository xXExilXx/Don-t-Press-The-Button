using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button quitButton;
    public GameObject mainCanvas;
    public GameObject optionsCanvas;

    private void Start()
    {
        // Add listeners to the buttons
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(ShowOptions);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        // Change the scene to the main scene
        SceneManager.LoadScene("MainScene"); // Replace "MainScene" with your actual scene name
    }

    private void ShowOptions()
    {
        // Deactivate the main canvas and activate the options canvas
        mainCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    private void QuitGame()
    {
        // Quit the application (works in standalone builds)
        Application.Quit();
    }
}
