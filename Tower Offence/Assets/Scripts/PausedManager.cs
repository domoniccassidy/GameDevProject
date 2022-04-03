using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PausedManager : MonoBehaviour
{
    public GameObject Mains;
    public GameObject Options;
    public AudioMixer AM;
    public AudioMixer EM;
    public Slider MusicSlider;
    public Slider EffectsSlider;
    public List<GameObject> selectedButtons;
    public User user;

    void Start()
    {
        selectedButtons[0].GetComponent<Button>().Select();
        MusicSlider.value = GameObject.Find("SettingsHolder").GetComponent<SettingsManager>().slide;
        EffectsSlider.value = GameObject.Find("SettingsHolder").GetComponent<SettingsManager>().effectsSlide;

    }
    public void OnOptions()
    {
        Mains.SetActive(false);
        Options.SetActive(true);
        selectedButtons[1].GetComponent<Button>().Select();
    }
    public void OnBack()
    {
        Mains.SetActive(true);
        Options.SetActive(false);
        selectedButtons[0].GetComponent<Button>().Select();
    }
    public void SetLevel(float sliderValue)
    {
        AM.SetFloat("MusicControl", Mathf.Log10(sliderValue) * 20);
        GameObject.Find("SettingsHolder").GetComponent<SettingsManager>().slide = sliderValue;
    }
    public void SetEffectsLevel(float sliderValue)
    {
        EM.SetFloat("EffectsControl", Mathf.Log10(sliderValue) * 20);
        GameObject.Find("SettingsHolder").GetComponent<SettingsManager>().effectsSlide = sliderValue;
    }
    public void OnResume()
    {
        user.OnPause();
    }
    public void OnQuitMM()
    {
        SceneManager.LoadScene(0);
    }
    public void OnQuitTD()
    {
        Application.Quit();
        
    }
}
