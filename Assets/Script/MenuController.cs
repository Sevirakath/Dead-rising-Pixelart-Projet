/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels to Load")]
    public string _newGameLevel;
    private string leveltoLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            leveltoLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(leveltoLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void Exit Button()
    {
        Application.Quit();
    }
}
*/