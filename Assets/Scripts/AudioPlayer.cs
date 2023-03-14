using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] AudioClip defaultMusic;

    [SerializeField] AudioClip battleMusic;

    [Header("Sound Effects")]
    [SerializeField] AudioClip startSFX;
    [SerializeField] [Range(0f, 1f)] float startSFXVolume = 1f;

    [SerializeField] AudioClip explosionSFX;
    [SerializeField] [Range(0f, 1f)] float explosionSFXVolume = 1f;

    [SerializeField] AudioClip engineRampUpSFX;
    [SerializeField] [Range(0f, 1f)] float engineRampUpSFXVolume = 1f;

    [SerializeField] AudioClip clickSFX;
    [SerializeField] [Range(0f, 1f)] float clickSFXVolume = 1f;

    [SerializeField] AudioSource audioSource;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
        audioSource = FindObjectOfType<AudioSource>();
    }

    void Start()
    {
        PlayDefaultMusic();
    }

    void ManageSingleton()
    {

        if(instance != null && instance != this)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayDefaultMusic()
    {
        PlayAudio(defaultMusic);
    }

    public void PlayBattleMusic()
    {
        PlayAudio(battleMusic);
    }

    void PlayAudio(AudioClip clip)
    {
        if(clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }    

    public void PlayStartSFX()
    {
        PlaySFX(startSFX, startSFXVolume);
    }

    public void PlayExplosionSFX()
    {
        PlaySFX(explosionSFX, explosionSFXVolume);
    }

    public void PlayEngineRampUpSFX()
    {
        PlaySFX(engineRampUpSFX, engineRampUpSFXVolume);
    }

    public void PlayClickSFX()
    {
        PlaySFX(clickSFX, clickSFXVolume);
    }

    void PlaySFX(AudioClip clip, float vol)
    {
        if(clip != null)
        {
            Vector3 audioPos = audioSource.transform.position;
            AudioSource.PlayClipAtPoint(clip, audioPos, vol);
        }
    }
}
