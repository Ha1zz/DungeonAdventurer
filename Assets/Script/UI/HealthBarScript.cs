using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public CharacterPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<CharacterPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hp <= 0)
            player.hp = 0;
        transform.localScale = new Vector3((float)((double)player.hp / (double)player.hpMax), 1.0f, 1.0f);

    }
}
