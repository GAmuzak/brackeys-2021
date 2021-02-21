using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SfxManager : Singleton<SfxManager>
{
    private AudioSource sfxSource;

    [SerializeField]
    private List<AudioClip> clips;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        sfxSource = GetComponent<AudioSource>();
    }

    

    public void SetClipToPlay( int m)
    {
        sfxSource.clip = clips[m];
        sfxSource.Play();
    }
}
