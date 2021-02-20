using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicClip {
    Null=-1, bracc_init, bracc_final
}
public class MusicManager : Singleton<MusicManager>
{
    private AudioSource musicSource;

    [SerializeField]
    private List<AudioClip> clips;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        musicSource = GetComponent<AudioSource>();
    }
    public void SetClipToPlay(MusicClip m)
    {
        musicSource.clip = clips[(int)m];
        musicSource.Play();
    }
}
