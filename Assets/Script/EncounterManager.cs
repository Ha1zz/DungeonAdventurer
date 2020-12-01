using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EncounterManager : MonoBehaviour
{
    public UnityEvent onEnterEncounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnterCounter()
    {
        onEnterEncounter.Invoke();
        SceneManager.LoadScene("RandomEncounter1");
    }


    public void ExitEncounter()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
