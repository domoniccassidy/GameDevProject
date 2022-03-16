using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Buttons;
    public GameObject LevelButtons;
    public GameObject OptionButtons;
    public List<GameObject> selectedButtons;

    private void Start()
    {
        selectedButtons[0].GetComponent<Button>().Select();
    }
    public void OnLevelSelect()
    {
        
        Buttons.SetActive(false);
        LevelButtons.SetActive(true);
        selectedButtons[1].GetComponent<Button>().Select();
    }
    public void OnOptionsSelect()
    {
        Buttons.SetActive(false);
        OptionButtons.SetActive(true);
        selectedButtons[2].GetComponent<Button>().Select();
    }
    public void Back()
    {
        Buttons.SetActive(true);
        OptionButtons.SetActive(false);
        LevelButtons.SetActive(false);
        selectedButtons[0].GetComponent<Button>().Select();

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
