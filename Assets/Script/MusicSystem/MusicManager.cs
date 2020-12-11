using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.Audio; 

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioSource musicSource;

    [SerializeField]
    AudioClip[] musicTracks;

    [SerializeField]
    AudioMixer masterMixer;

    [SerializeField]
    float volumeMax = 0.0f;
    [SerializeField]
    float volumeMin = -80.0f;

    public enum Track
    {
        Overworld,
        Battle
    }


    // Start is called before the first frame update
    void Start()
    {
        //SpawnPoint.player.GetComponent<EncounterController>().onEnterEncounter.AddListener(EnterEncounterHandler);
    }

    



    public void EnterEncounterHandler()
    {
        Debug.Log("ME");
        PlayTrack(Track.Battle);
    }

    public void PlayTrack(Track trackID)
    {
        musicSource.clip = musicTracks[(int)trackID];
        musicSource.Play();
        Debug.Log("CHCK");
    }

    public void SetMusicVolume(float normalizedVolume)
    {
        float dbVal = Mathf.Lerp(volumeMin, volumeMax, normalizedVolume);

        masterMixer.SetFloat("MusicVolume",dbVal);
    }
}
