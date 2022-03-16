using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Buttons;
    public GameObject LevelButtons;
    public GameObject OptionButtons;

    public void OnLevelSelect()
    {
        Buttons.SetActive(false);
        LevelButtons.SetActive(true);
    }
    public void OnOptionsSelect()
    {
        Buttons.SetActive(false);
        OptionButtons.SetActive(true);
    }
    public void Back()
    {
        Buttons.SetActive(true);
        OptionButtons.SetActive(false);
        LevelButtons.SetActive(false);
    }
    public void OnFriendlyFlowers()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
