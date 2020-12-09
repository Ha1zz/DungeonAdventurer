using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To use:
//Call: SoundManager.PlaySound(SoundManager.Sound.(Whatever the name of the sound is));
//Call it wherever you want the sound to be played.

public static class SoundManager 
{
    public enum Sound
        //For any new sounds, add them to this list
    { 
        playerMove,
        playerAttack,
        playerHit,
        playerDeath,
        enemyHit,
        enemyDeath,
    }

    private static Dictionary<Sound, float> soundTimerDictionary;

    public static void Initialize() //Needs to be called in the game manager function in order to work, could not find it.
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.playerMove] = 0f;
    }

    public static void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    //Made so that the player move sound is not played on top of each other multiple times
    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {

            default:
                return true;

            case Sound.playerMove:

                // PROBLEM HERE - JOHNNY
                //if (soundTimerDictionary.ContainsKey(sound))
                //{
                //    float lastTimePlayed = soundTimerDictionary[sound];
                //    float playerMoveTimerMax = .05f;

                //    if (lastTimePlayed + playerMoveTimerMax < Time.time)
                //    {
                //        soundTimerDictionary[sound] = Time.time;
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                //else
                //{
                //    return true;
                //}
                return false;
        }
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach(GameAssets.SoundAudioClip soundAudioClip in GameAssets.ga_Instance.soundAudioClipArray)
        {
            if(soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
