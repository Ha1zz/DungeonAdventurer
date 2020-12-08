using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CharacterAI : ICharacter
{
    public Animator animator;
    public CharacterAI AI;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void TakeTurn()
    {
        Debug.Log("AI");
        //AI.UseAbility(2);


    }

    void Update()
    {
        if (hp <= 0)
        {
            Death();
        }
    }

    //public override void PlayAnimation(AnimationClip animo)
    //{
    //    anim.clip = amino;
    //    amin.Play();
    //}

    //public override void UseAbility(int id)
    //{
    //    Debug.Log("AI");
    //    onUseAbility.Invoke(this, abilities[id]);
    //}

    public override void AttackLight()
    {
        animator.Play("Attack1");
        StartCoroutine(ChangeAnimation(1.0f));
    }

    public override void AttackHeavy()
    {
        animator.Play("Attack3");
        StartCoroutine(ChangeAnimation(1.0f));
    }

    public override void AttackMedium()
    {
        animator.Play("Attack2");
        StartCoroutine(ChangeAnimation(2.0f));
    }

    public override void GetHit()
    {
        animator.Play("GetHit");
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public override void TakeDamage(int baseDamage)
    {
        //animator.Play("GetHit");
        int damageTaken = baseDamage;
        hp -= baseDamage;
        onTakeDamage.Invoke(this, baseDamage);
    }

    public override void HealAnimation()
    {
        animator.Play("Heal");
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public override void Heal(int healAmount)
    {
        //animator.Play("GetHit");
        //int damageTaken = healAmount;
        hp += healAmount;
        //onHeal.Invoke(this, healAmount);
        //(ChangeAnimation());
    }
    public void Death()
    {
        animator.Play("Death");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator ChangeAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        animator.Play("Idle");
    }
}
