using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusic : MonoBehaviour
{
    [SerializeField]
    private MusicClip clipToPlay=0;
    void Start()
    {
        SetClipToPlay();
    }
    [ContextMenu(nameof(SetClipToPlay))]
    private void SetClipToPlay()
    {
        MusicManager.Instance.SetClipToPlay(clipToPlay);
    }
}
