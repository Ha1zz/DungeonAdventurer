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
    public PlayerController character;
    public Canvas saveCanvas;
    public Canvas loadCanvas;

    void Start()
    {
        character = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        saveCanvas = GameObject.Find("SaveCanvas").GetComponent<Canvas>();
        loadCanvas = GameObject.Find("LoadCanvas").GetComponent<Canvas>();
        if (saveCanvas != null)
            saveCanvas.enabled = false;
        if (loadCanvas != null)
            loadCanvas.enabled = false;
    }

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

    public void Load()
    {
        loadCanvas.enabled = true;
        OnLoad.Invoke();
        character.transform.position = new Vector2(PlayerPrefs.GetFloat("CurrentPositionX"), PlayerPrefs.GetFloat("CurrentPositionY"));
        character.hp = PlayerPrefs.GetFloat("Hp");
        character.mana = PlayerPrefs.GetFloat("Mana");
        StartCoroutine(Wait(1.0f));
    }



    public void Save()
    {
        saveCanvas.enabled = true;
        OnSave.Invoke();
        PlayerPrefs.SetFloat("CurrentPositionX", character.transform.position.x);
        PlayerPrefs.SetFloat("CurrentPositionY", character.transform.position.y);
        PlayerPrefs.SetFloat("Hp", character.hp);
        PlayerPrefs.SetFloat("Mana", character.mana);
        PlayerPrefs.Save();
        StartCoroutine(Wait(1.0f));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        if (saveCanvas != null)
            saveCanvas.enabled = false;
        if (loadCanvas != null)
            loadCanvas.enabled = false;
    }
}
