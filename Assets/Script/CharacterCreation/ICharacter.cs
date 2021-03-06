﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

public class ICharacter : MonoBehaviour
{
    public float hp = 20;

    [SerializeField]
    public float hpMax = 20;

    public float mana = 10;

    [SerializeField]
    public float manaMax = 10;

    [SerializeField]
    //public Animator animator;
    public Animator anim;

    [SerializeField]
    public Ability[] abilities = new Ability[4];

    public UnityEvent<ICharacter, Ability> onUseAbility;
    public UnityEvent<ICharacter, int> onTakeDamage;
    public UnityEvent<ICharacter, Ability> AIonUseAbility;
    public UnityEvent<ICharacter> onTurnBegin;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    void Update()
    {

    }

    //public void UseAbility(int id)
    //{
    //    onUseAbility.Invoke(this, abilities[id]);
    //}

    public void UseAbility(int id)
    {
        //Debug.Log("BASE");
        onUseAbility.Invoke(this, abilities[id]);
    }

    //public virtual void UseAbility(int id)
    //{
    //    Debug.Log("BASE");
    //}

    public virtual void PlayAnimation(string name)
    {

    }

    public virtual void TakeTurn()
    {

    }

    //public void TakeDamage(int baseDamage)
    //{
    //    int damageTaken = baseDamage;
    //    hp -= baseDamage;
    //    onTakeDamage.Invoke(this, baseDamage);
    //}

    public virtual void Heal(int hit)
    {

    }

    public virtual void TakeDamage(int hit)
    {

    }

    public virtual void AttackLight()
    {

    }

    public virtual void AttackMedium()
    {

    }

    public virtual void AttackHeavy()
    {

    }

    public virtual void GetHit()
    {

    }

    public virtual void HealAnimation()
    {

    }

    public virtual void Escape()
    {

    }

    public virtual void Struggle()
    {

    }

    public virtual void Death()
    {

    }

    public virtual void PlayAnimation(AnimationClip anim)
    {
        //SoundManager.PlaySound(SoundManager.Sound.playerHit);

    }
}
