using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] sounds;

    public AudioSource vulcan;
    public AudioSource kolesa;
    public AudioSource click;
    public AudioSource music;
    void Start()
    {
        sounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }
}
