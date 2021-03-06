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
        PlayerPrefs.SetInt("EncounterCounter", 50);
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && PlayerPrefs.GetInt("EncounterCounter") <= 0)
        {
            int seed = Random.Range(0, 100);
            if (seed <= 30)
            {
                isTriggered = true; //For fading inbetween scenes    
                Transform playerPosition = collision.gameObject.GetComponent<Transform>();
                PlayerPrefs.SetFloat("PlayerPositionX", playerPosition.position.x);
                PlayerPrefs.SetFloat("PlayerPositionY", playerPosition.position.y);
                PlayerPrefs.Save();
                //int seed = Random.Range(1, 2);

                isTriggered = false;
                int rSeed = 1;
                switch (rSeed)
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

}
