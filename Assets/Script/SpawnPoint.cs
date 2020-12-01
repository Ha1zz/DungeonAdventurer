using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    public static PlayerController player = null;

    void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                player = Instantiate(playerPrefab, transform.position, transform.rotation).GetComponentInChildren<PlayerController>();
            }
        }
    }
}
