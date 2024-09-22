using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioSource Music;
    [Header("Audio Clips")]
    [SerializeField] public AudioClip[] menuSFX; // buttons and such 
    [SerializeField] public AudioClip[] gameSFX; // ball hit sounds, and wooshes, see #1 comment below
    [SerializeField] AudioClip menuMusic;
    [SerializeField] public AudioClip gameMusic;
    //Instances the Audiomanager
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Music.clip = menuMusic;
        Music.Play();
    }
    public void PlayMusic(AudioClip clip)
    {
        if (Music.clip != clip)
        {
            Music.clip = clip;
            Music.Stop();
            Music.Play();
        }
    }
    public void PlaySFXArrayoneshot(AudioClip[] clip, int i)
    {
        SFX.PlayOneShot(clip[i]);
    }

    public void PlaySFXoneshot(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
