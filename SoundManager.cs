using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource Sound;
    [SerializeField] private AudioSource Music;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip shootSound1;
    [SerializeField] private AudioClip shootSound2;
    [SerializeField] private AudioClip boomSound;
    [SerializeField] private AudioClip reloadSound4;
    [SerializeField] private AudioClip[] soundArray;   
    private int i = 0;
    public bool playSound = true;
    public static SoundManager instance;

    private void Awake()
    {
        i = Random.Range(0, soundArray.Length);
        instance = this;
        PlaySound();
    }
    private void Update()
    {
        if (playSound)
        {
            if (!Music.isPlaying)
            {
                ChangeSound();
            }
        }       
    }
    public void playReloadSound()
    {
        instance.PlayReloadSound();
    }
    public void playShoot1Sound()
    {
        instance.PlayShoot1Sound();
    }
    public void playShoot2Sound()
    {
        instance.PlayShoot2Sound();
    }
    public void PlayReloadSound()
    {
        Sound.clip = reloadSound;
        Sound.Play();
    }
    public void PlayShoot1Sound()
    {
        Sound.clip = shootSound1;
        Sound.Play();
    }
    public void PlayShoot2Sound()
    {
        Sound.clip = shootSound2;
        Sound.Play();
    }
    public void PlaySound()
    {
        Music.clip = soundArray[i];
        Music.Play();
    }
    public void ChangeSound()
    {
        Music.Stop();
        if (i != (soundArray.Length - 1))
        {
            i++;
        }
        else
        {
            i = 0;
        }
        Music.clip = soundArray[i];
        Music.Play(); 
    }
}
