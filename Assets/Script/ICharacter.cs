using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ICharacter : MonoBehaviour
{
    public int hp = 20;

    [SerializeField]
    public int hpMax = 20;

    [SerializeField]
    public Ability[] abilities = new Ability[4];

    public UnityEvent<ICharacter, Ability> onUseAbility;
    public UnityEvent<ICharacter, int> onTakeDamage;
    public UnityEvent<ICharacter> onTurnBegin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UseAbility(int id)
    {
        onUseAbility.Invoke(this, abilities[id]);
    }

    public virtual void TakeTurn()
    {

    }

    public void TakeDamage(int baseDamage)
    {

        int damageTaken = baseDamage;
        hp -= baseDamage;
        onTakeDamage.Invoke(this, baseDamage);
    }

}
