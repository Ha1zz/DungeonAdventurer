using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : ICharacter
{
    // Start is called before the first frame update
    void Start()
    {
        //HealthBarHandler.SetHealthBarValue(hp);
    }

    public override void TakeTurn()
    {
        Debug.Log("This is my turn");
    }

}
