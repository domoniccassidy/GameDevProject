using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Buttons;
    public GameObject LevelButtons;
    public GameObject OptionButtons;
    public GameObject HighScores;
    public List<GameObject> selectedButtons;
    public AudioMixer AM;
    public AudioMixer EM;
    public Slider musicSlider;
    public Slider effectsSlider;
    
    public SettingsManager SM;


    private void Start()
    {
        
        selectedButtons[0].GetComponent<Button>().Select();
        SM = GameObject.Find("SettingsHolder").GetComponent<SettingsManager>();
        musicSlider.value = GameObject.Find("SettingsHolder").GetComponent<SettingsManager>().slide;
        effectsSlider.value = GameObject.Find("SettingsHolder").GetComponent<SettingsManager>().effectsSlide;

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
    public void OnHighScoreSelect()
    {
        Buttons.SetActive(false);
        HighScores.SetActive(true);
        selectedButtons[3].GetComponent<Button>().Select();
    }
    public void Back()
    {
        Buttons.SetActive(true);
        OptionButtons.SetActive(false);
        LevelButtons.SetActive(false);
        HighScores.SetActive(false);
        selectedButtons[0].GetComponent<Button>().Select();

    }
    public void SetLevel(float sliderValue)
    {
        AM.SetFloat("MusicControl", Mathf.Log10(sliderValue) * 20);
        SM.slide = sliderValue;
    }
    public void SetEffectsLevel(float sliderValue)
    {
        EM.SetFloat("EffectsControl", Mathf.Log10(sliderValue) * 20);
        GameObject.Find("SettingsHolder").GetComponent<SettingsManager>().effectsSlide = sliderValue;
    }

    public void OnFriendlyFlowers()
    {
        SceneManager.LoadScene(1);
    }
    public void OnViciousVolcano()
    {
        SceneManager.LoadScene(2);
    }
    public void OnQuit()
    {
        Application.Quit();

    }

    
}
