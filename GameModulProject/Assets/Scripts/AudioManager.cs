using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource Source;


    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        Source = GetComponent<AudioSource>();


    }


    public void PlaySound(AudioClip audio)
    {
        Source.clip = audio;
        Source.Play();
    }




}
