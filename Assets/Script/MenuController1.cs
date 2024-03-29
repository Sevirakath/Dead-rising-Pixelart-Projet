using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController1 : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;
    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Graphics Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;
    [SerializeField] private float defaultBrightness = 1;

    private int _qualityLevel;
    private bool _isFullScreen;
    private float _brightnessLevel;

    [Header("Levels to Load")]
    public string newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    [Header("Resolution Dropdowns")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private int selectedButtonIndex = 0;
    private bool controllerInUse = false;
    private bool isPopupOpen = false;

    public GameObject[] buttons;
    public Color selectedColor = Color.red;
    public Color defaultColor = Color.white;

    // D�claration d'un �v�nement pour la fen�tre contextuelle
    public event Action<bool> PopupStateChanged;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0.0");
    }

    public void SetFullScreen(bool isFullscreen)
    {
        _isFullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);
        // change your brightness with your post-processing

        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);

        PlayerPrefs.SetInt("masterFullscreen", (_isFullScreen ? 1 : 0));
        Screen.fullScreen = _isFullScreen;

        StartCoroutine(ConfirmationBox());
    }

    public void VolumeApply()
    {
        float volume = volumeSlider.value;
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
        PlayerPrefs.SetFloat("masterVolume", volume);
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string menuType)
    {
        if (menuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }

    private void Update()
    {
        // Check if a controller is connected
        if (Input.GetJoystickNames().Length > 0)
        {
            // Get controller input
            float verticalInput = Input.GetAxis("Vertical");

            if (!isPopupOpen && Mathf.Abs(verticalInput) > 0.1f && !controllerInUse)
            {
                // Change selected button based on controller input
                selectedButtonIndex -= (int)Mathf.Sign(verticalInput);
                selectedButtonIndex = Mathf.Clamp(selectedButtonIndex, 0, buttons.Length - 1);
                UpdateButtonColors();

                controllerInUse = true;
            }
            else if (Mathf.Abs(verticalInput) < 0.1f)
            {
                controllerInUse = false;
            }

            // Check for button press
            if (!isPopupOpen && Input.GetButtonDown("Submit"))
            {
                // Execute the action associated with the selected button
                buttons[selectedButtonIndex].GetComponent<Button>().onClick.Invoke();
            }
        }
    }

    private void UpdateButtonColors()
    {
        // Reset all buttons to default color
        foreach (GameObject button in buttons)
        {
            if (button != null)
                button.GetComponent<Image>().color = defaultColor;
        }

        // Set selected button color
        buttons[selectedButtonIndex].GetComponent<Image>().color = selectedColor;
    }

    // M�thode pour activer/d�sactiver la fen�tre contextuelle
    public void TogglePopup(bool isOpen)
    {
        isPopupOpen = isOpen;

        // D�clencher l'�v�nement pour notifier les autres objets
        PopupStateChanged?.Invoke(isOpen);
    }
}

