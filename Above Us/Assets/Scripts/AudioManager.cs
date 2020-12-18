using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource music;
    private AudioSource sound;


    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    private float pauseTimer = 0f;


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

        


    }

    private void Start()
    {
        AudioSource[] sources =  GetComponents<AudioSource>();
        music = sources[0];
        sound = sources[1];

    }


    private void Update()
    {
        if(pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;
            music.Pause();
        }
        else
        {
            pauseTimer = 0f;
            music.UnPause();
        }
    }


    public void PlaySound(AudioClip audio)
    {
        sound.clip = audio;
        sound.Play();
    }

    public void PlaySoundAndPauseMusic(AudioClip audio)
    {
        pauseTimer = audio.length;
    }





}
