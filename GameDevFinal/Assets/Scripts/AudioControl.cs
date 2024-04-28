using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource Audiosource;


    private float musicVolume = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        Audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        Audiosource.volume = musicVolume;

    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
