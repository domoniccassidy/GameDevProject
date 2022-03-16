using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class PausedManager : MonoBehaviour
{
    public GameObject Mains;
    public GameObject Options;
    public AudioMixer AM;
    void Start()
    {
        
    }
    public void OnOptions()
    {
        Mains.SetActive(false);
        Options.SetActive(true);
    }
    public void OnBack()
    {
        Mains.SetActive(true);
        Options.SetActive(false);
    }
    public void SetLevel(float sliderValue)
    {
        AM.SetFloat("MusicControl", Mathf.Log10(sliderValue) * 20);
    }
    public void OnQuitMM()
    {
        SceneManager.LoadScene(0);
    }
    public void OnQuitTD()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
