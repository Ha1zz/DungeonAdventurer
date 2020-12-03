using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made to handle instances of audio clips.

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets ga_Instance
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
                return _i;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

}
