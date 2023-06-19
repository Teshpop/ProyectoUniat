using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerMVideo : MonoBehaviour
{
    public TextMeshProUGUI resolutionText;
    public TextMeshProUGUI fullscreenButtonText;

    private int currentResolutionIndex = 0;
    private bool isFullScreen = true;

    private void Start()
    {
        // Recuperar la resolución guardada (si existe) o usar la resolución actual por defecto
        if (PlayerPrefs.HasKey("ResolutionWidth") && PlayerPrefs.HasKey("ResolutionHeight"))
        {
            int width = PlayerPrefs.GetInt("ResolutionWidth");
            int height = PlayerPrefs.GetInt("ResolutionHeight");
            Screen.SetResolution(width, height, Screen.fullScreen);
        }
        else
        {
            Screen.fullScreen = true;
        }

        Resolution resolution = Screen.currentResolution;
        resolutionText.text = resolution.width + "x" + resolution.height;

        UpdateFullScreenButtonText();
    }

    public void ChangeResolution(int direction)
    {
        currentResolutionIndex += direction;
        currentResolutionIndex = Mathf.Clamp(currentResolutionIndex, 0, Screen.resolutions.Length - 1);
        Resolution resolution = Screen.resolutions[currentResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        resolutionText.text = resolution.width + "x" + resolution.height;
    }

    public void ToggleFullScreen()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
        UpdateFullScreenButtonText();
    }

    public void UpdateFullScreenButtonText()
    {
        fullscreenButtonText.text = isFullScreen ? "Windowed" : "Fullscreen";
    }

    public void OnAcceptButtonClicked()
    {
        Resolution resolution = Screen.resolutions[currentResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);

        // Guardar la resolución actual en PlayerPrefs
        PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
        // Guardar el modo de pantalla completa en PlayerPrefs
        PlayerPrefs.SetInt("IsFullscreen", isFullScreen ? 1 : 0);
        // Guardar los cambios realizados en PlayerPrefs
        PlayerPrefs.Save();

        Debug.Log("Resolution changed to: " + resolution.width + "x" + resolution.height);
        Debug.Log("Fullscreen mode: " + (isFullScreen ? "Enabled" : "Disabled"));
    }
}
