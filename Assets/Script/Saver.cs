using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.Events;
using System.Security.Cryptography;

public class Saver : MonoBehaviour
{

    public static UnityEvent OnSave = new UnityEvent();
    public static UnityEvent OnLoad = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private void Load()
    {
        OnLoad.Invoke();
        transform.position = new Vector2(PlayerPrefs.GetFloat("CurrentPositionX"), PlayerPrefs.GetFloat("CurrentPositionY"));
    }



    private void Save()
    {
        OnSave.Invoke();
        PlayerPrefs.SetFloat("CurrentPositionX", transform.position.x);
        PlayerPrefs.SetFloat("CurrentPositionY", transform.position.y);
        PlayerPrefs.Save();
    }
}
