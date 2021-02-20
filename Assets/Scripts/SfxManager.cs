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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetClipToPlay(0);
        }
    }

    public void SetClipToPlay(MusicClip m)
    {
        sfxSource.clip = clips[(int)m];
        sfxSource.Play();
    }
}
