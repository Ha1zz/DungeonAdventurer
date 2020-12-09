using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public CharacterPlayer character;
    public Transform healthBar;
    public Transform manaBar;

    // Start is called before the first frame update
    void Start()
    {
        //character = GetComponent<charactercharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.hp <= 0)
            character.hp = 0;
        if (character.hp >= character.hpMax)
            character.hp = character.hpMax;
        healthBar.transform.localScale = new Vector3((float)((double)character.hp / (double)character.hpMax), 1.0f, 1.0f);

        if (character.mana <= 0)
            character.mana = 0;
        if (character.mana >= character.manaMax)
            character.mana = character.manaMax;
        manaBar.transform.localScale = new Vector3((float)((double)character.mana / (double)character.manaMax), 1.0f, 1.0f);
    }
}
