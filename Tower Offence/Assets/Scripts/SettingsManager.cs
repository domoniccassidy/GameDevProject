using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public float musicVolume;
    public float effectsVolume;
    public AudioMixer AM;
    public float slide;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        slide = 1;

    }

    public void SetLevel(float sliderValue)
    {
        AM.SetFloat("MusicControl", Mathf.Log10(sliderValue) * 20);
        slide = sliderValue;
    }
}
