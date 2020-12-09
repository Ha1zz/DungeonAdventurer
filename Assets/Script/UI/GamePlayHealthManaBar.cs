using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayHealthManaBar : MonoBehaviour
{
    public PlayerController character;
    public Transform healthBar;
    public Transform manaBar;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.hp <= 0)
            character.hp = 0;
        if (character.hp >= 20)
            character.hp = 20;
        healthBar.transform.localScale = new Vector3((float)((double)character.hp / (double)20), 1.0f, 1.0f);

        if (character.mana <= 0)
            character.mana = 0;
        if (character.mana >= 10)
            character.mana = 10;
        manaBar.transform.localScale = new Vector3((float)((double)character.mana / (double)10), 1.0f, 1.0f);
    }
}
