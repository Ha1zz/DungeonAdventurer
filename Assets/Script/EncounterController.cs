using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EncounterController : MonoBehaviour
{
    public UnityEvent onEnterEncounter;

    public void EnterCounter()
    {
        StartCoroutine(EnterEncounterCoroutine());
    }

    IEnumerator EnterEncounterCoroutine()
    {
        onEnterEncounter.Invoke();
        yield return new WaitForSeconds(2.0f);
        transform.root.gameObject.SetActive(false);

        SceneManager.LoadScene("RandomEncounter1");
    }

    public void ExitEncounter()
    {

        SceneManager.LoadScene("PlayScene");
        transform.root.gameObject.SetActive(true);
    }
}
