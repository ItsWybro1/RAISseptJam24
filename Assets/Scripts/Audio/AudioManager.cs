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
    [SerializeField] public AudioClip[] gameMusic;
    private int s;
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
    public void PlayMusic(AudioClip[] clip, int i)
    {
        if (Music.clip != clip[i])
        {
            Music.Stop(); 
            Music.clip = clip[i];
            Music.Play();
            s = Random.Range(0, gameMusic.Length);
            double length = (double)clip[i].samples / clip[i].frequency;
            Invoke(nameof(ChangeSong), (float)length);
        }
        
        //StartCoroutine(); to call playmusic with reandom int
    }
    public void PlaySFXArrayoneshot(AudioClip[] clip, int i)
    {
        SFX.PlayOneShot(clip[i]);
    }

    public void PlaySFXoneshot(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
    public void ChangeSong()
    {
        Debug.Log("changeSong");
        Music.Stop();
        Music.clip = gameMusic[s];
        Music.Play();
        s = Random.Range(0, gameMusic.Length);
        double length = (double)Music.clip.samples / Music.clip.frequency;
        Invoke(nameof(ChangeSong), (float)length);
    }
}
