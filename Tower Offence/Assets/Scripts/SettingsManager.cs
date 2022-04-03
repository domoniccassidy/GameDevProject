using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{
    private static SettingsManager instance;
    public float musicVolume;
    public float effectsVolume;
    public AudioMixer AM;
    public Slider musicSlider; 
    public float slide = 1;
    public float effectsSlide = 1;
    public GameObject test;
    private void Start()
    {
        
        DontDestroyOnLoad(gameObject);
       
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
        
    
    }

   
}
