using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    bool isPlayedOnce = true;

    [Header("Player Stat")]
    public float hp = 20;
    public float mana = 10;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    int enCounter = 0;

    void Awake()
    {
        SoundManager.Initialize();
        
        if (PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY"))
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("PlayerPositionX"), PlayerPrefs.GetFloat("PlayerPositionY"));
            PlayerPrefs.DeleteKey("PlayerPositionX");
            PlayerPrefs.DeleteKey("PlayerPositionY");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Hp") && PlayerPrefs.HasKey("Mana"))
        {
            hp = PlayerPrefs.GetFloat("Hp");
            mana = PlayerPrefs.GetFloat("Mana");
        }
        else
        {
            hp = 20;
            mana = 10;
            PlayerPrefs.SetFloat("Hp", hp);
            PlayerPrefs.SetFloat("Mana", mana);
        }



        animator = GetComponent<Animator>();
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("Hp");
        PlayerPrefs.DeleteKey("Mana");
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionY");
        PlayerPrefs.DeleteKey("Ability1");
        PlayerPrefs.DeleteKey("Ability2");
    }

    // Update is called once per frame
    void Update()
    {
        //barDisplay = health;
        //PlayerPrefs.SetFloat("Hp", hp);
        //PlayerPrefs.SetFloat("Mana", mana);
        if (PlayerPrefs.HasKey("EncounterCounter"))
        {
            enCounter = PlayerPrefs.GetInt("EncounterCounter");
        }
        //Debug.Log("Count" + enCounter);
        if (enCounter > 0)
        {
            enCounter--;
            PlayerPrefs.SetInt("EncounterCounter",enCounter);
            PlayerPrefs.Save();
        }
        Move();
    }


    private void Move()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        

        movementVector *= speed;
        rigidBody.velocity = movementVector;

        bool isRunning = movementVector.magnitude > float.Epsilon;
        if (isRunning)
        {
            bool isMovingHorizontally = Mathf.Abs(movementVector.x) > Mathf.Abs(movementVector.y);
            if (isMovingHorizontally) //moving left/right more than up/down
            {
                if (movementVector.x < 0) //moving left/WEST
                {
                    //animator.Play("RunLeft");
                    animator.SetInteger("ChangeState", 2);
                }
                else //moving right/EAST
                {
                    //animator.Play("RunRight");
                    animator.SetInteger("ChangeState", 1);
                }
            }
            else // moving more vertically
            {
                if (movementVector.x == 0 && movementVector.y != 0) //moving down/SOUTH
                {
                    //animator.Play("RunRight");
                    animator.SetInteger("ChangeState", 1);
                }
                if (movementVector.x > 0 && movementVector.y < 0) //moving down/SOUTH
                {
                    //animator.Play("RunRight");
                    animator.SetInteger("ChangeState", 1);
                }
                if (movementVector.x > 0 && movementVector.y > 0)
                {
                    //animator.Play("RunRight");
                    animator.SetInteger("ChangeState", 1);
                }

            }

            //SoundManager.PlaySound(SoundManager.Sound.playerMove);
        }
        else
        {
            //animator.Play("Idle");
            rigidBody.velocity = Vector2.zero;
            animator.SetInteger("ChangeState", 0);
        }

        
    }

    private void FlipX()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }
}
