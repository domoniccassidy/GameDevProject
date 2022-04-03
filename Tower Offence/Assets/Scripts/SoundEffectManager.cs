using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<AudioSource> sources;
    public User user;
    Dictionary<int, string> clipNames = new Dictionary<int, string>()
    {
        {0,"" },
        {1,"" }
    };
    void Update()
    {
        if(!sources[0].isPlaying && clipNames[0] != "")
        {
            clipNames[0] = "";
        }
        if (!sources[1].isPlaying && clipNames[1] != "")
        {
            clipNames[1] = "";
        }
        if (user.isGameOver)
        {
            sources[0].volume = 0;
            sources[1].volume = 0;
        }
    }

    // Update is called once per frame
    public void RequestPlayEffect(AudioClip clip)
    {
       
        if (!sources[0].isPlaying && clipNames[1] != clip.name)
        {
            clipNames[0] = clip.name;
            sources[0].PlayOneShot(clip);
            
        }
        else if (!sources[1].isPlaying && clipNames[0] != clip.name)
        {
            clipNames[1] = clip.name;
            sources[1].PlayOneShot(clip);
        }


    }
}
