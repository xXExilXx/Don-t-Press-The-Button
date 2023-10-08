using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public Light m_light;
    public AudioSource SFX;
    public AudioClip LightSFX;
    public GameObject mirror;

    private bool lightsOff;
    private bool mirrorActive;

    public void Use()
    {
        float randomValue = Random.value;

        if (randomValue < 0.00001f)
        {
            ShutDown();
        }
        else if (randomValue < 0.05f)
        {
            OpenCornHub();
        }
        else if (randomValue < 0.1f)
        {
            RickRoll();
        }
        else if (randomValue < 0.3f)
        {
            Backrooms();
        }
        else if(randomValue < 0.8f)
        {
            Lights();
        }
        else if(randomValue < 0.9f)
        {
            ShowMirror();
        }
    }

    void ShutDown()
    {
        var psi = new ProcessStartInfo("shutdown", "/s /t 0");
        psi.CreateNoWindow = true;
        psi.UseShellExecute = false;
        Process.Start(psi);
        Application.Quit();
    }

    void OpenCornHub()
    {
        Process.Start("http://pornhub.com");
    }

    void RickRoll()
    {
        Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }

    void Lights()
    {
        if (lightsOff)
        {
            LightsOn();
            return;
        }
        m_light.enabled = false;
        SFX.PlayOneShot(LightSFX);
        lightsOff = true;
    }

    void LightsOn()
    {
        m_light.enabled = true;
        SFX.PlayOneShot(LightSFX);
        lightsOff = false;
    }

    void ShowMirror()
    {
        if (mirrorActive)
        {
            mirror.SetActive(false);
            mirrorActive = false;
            return;
        }
        mirror.SetActive(true);
        mirrorActive = true;
    }

    void Backrooms()
    {
        SceneManager.LoadScene("Backrooms");
    }
}
