using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health = 10;

    public float attack = 1;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    Rigidbody2D rigidBody;

    int enCounter = 0;

    float barDisplay = 0.0f;
    Vector2 pos = new Vector2(200,20);
    Vector2 size = new Vector2(200,40);
    Texture2D progressBarEmpty;
    Texture2D progressBarFull;

    void Awake()
    {
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

    }

    // Update is called once per frame
    void Update()
    {
        barDisplay = health;
        PlayerPrefs.SetFloat("Health", health);
        PlayerPrefs.SetFloat("Attack", attack);
        if (PlayerPrefs.HasKey("EncounterCounter"))
        {
            enCounter = PlayerPrefs.GetInt("EncounterCounter");
        }
        //Debug.Log("Count" + enCounter);
        if (enCounter > 0)
        {
            enCounter--;
            PlayerPrefs.SetInt("EncounterCounter",enCounter);
            //PlayerPrefs.Save();
        }
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementVector *= speed;
        rigidBody.velocity = movementVector;
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        // draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);
        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.EndGroup();
        GUI.EndGroup();
    }
}
