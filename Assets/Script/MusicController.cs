using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private bool canPlay;
    public AudioSource audioSource;

    public void PlayAudio(AudioClip clip)
    {

        if (canPlay)
            canPlay = false;
        GetComponent<AudioSource>().PlayOneShot(clip);

        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(.2f);
        canPlay = true;
    }
}
