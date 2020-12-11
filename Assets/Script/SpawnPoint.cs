using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    //SoundManager.Initialize();
    public static PlayerController player = null;

    void Awake()
    {
        SoundManager.Initialize();
        if (player == null && SceneManager.GetActiveScene().name == "PlayScene")
        {
            player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                player = Instantiate(playerPrefab, transform.position, transform.rotation).GetComponentInChildren<PlayerController>();
            }
        }
    }
}
