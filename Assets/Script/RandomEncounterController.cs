﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;
using UnityEditor.Events;

public class RandomEncounterController : MonoBehaviour
{
    public static bool isTriggered;

    public string randEnt1;
    public string randEnt2;
    public string randEnt3;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("EncounterCounter", 7);
        PlayerPrefs.SetInt("EncounterCounter", 15);
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterEncounter()
    {

    }

    public void ExitEncounter()
    {
        //onExitEncounter.Invoke();
        //Invoke("DelayedOverworld");
    }

    //void DelayedOverworld()
    //{
    //    transform.root.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(0.0f);
    //}


 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && PlayerPrefs.GetInt("EncounterCounter") <= 0)
        {
            isTriggered = true; //For fading inbetween scenes
            
            //PlayerWorldTraveller player = collision.gameObject.GetComponent<PlayerWorldTraveller>();
            //player.SpawnLocation = tag;
            //SceneManager.LoadScene(tag);
            Transform playerPosition = collision.gameObject.GetComponent<Transform>();
            PlayerPrefs.SetFloat("PlayerPositionX", playerPosition.position.x);
            PlayerPrefs.SetFloat("PlayerPositionY", playerPosition.position.y);
            PlayerPrefs.Save();
            //int seed = Random.Range(1, 2);

            isTriggered = false;
            int seed = 1;
            switch(seed)
            {
                case 1:
                    SceneManager.LoadScene(randEnt1);
                    break;
                case 2:
                    SceneManager.LoadScene(randEnt2);
                    break;
                case 3:
                    SceneManager.LoadScene(randEnt3);
                    break;
                default:
                    Debug.Log("NO");
                    break;
            }
        }
    }

}
