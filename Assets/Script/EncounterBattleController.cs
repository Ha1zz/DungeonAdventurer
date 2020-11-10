using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EncounterBattleController : MonoBehaviour
{
    public string overWorld;

    public GameObject playerPrefab;
    private GameObject player;
    private Animator animator;
    CharacterController playerControl;

    public int struggleChance;
    public int escapeChance;
    public int raiseDefenseChance;
    public int raiseAttackChance;

    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerPrefab, transform.position, transform.rotation);
        player.transform.position = new Vector3(-7.0f,-1.0f,0.0f);
        player.transform.localScale = new Vector3(8.0f, 8.0f, 1.0f);
        animator = player.GetComponent<Animator>();
        //playerControl = playerPrefab.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpAttack()
    {
        PlayerController playerScript = player.GetComponent<PlayerController>();
        float tempAttack = playerScript.health;
        animator.Play("UpAttack");
    }

    public void UpDefense()
    {
        animator.Play("UpDefense");
    }

    public void Struggle()
    {
        animator.Play("Struggle");
    }

    public void Escape()
    {
        animator.Play("Escape");
        SceneManager.LoadScene(overWorld);
    }
}
