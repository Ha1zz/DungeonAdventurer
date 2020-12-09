using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public enum BattleState
{

}

public class CharacterAI : ICharacter
{
    public Animator animator;
    public CharacterAI AI;
    public CharacterPlayer player;

    [Header("Particle System")]
    public ParticleSystem attack1Particle;
    public ParticleSystem attack2Particle;
    public ParticleSystem attack3Particle;
    public ParticleSystem healParticle;

    [Header("Sound System")]
    public GameObject musicController;
    public AudioClip attack1Clip;
    public AudioClip attack2Clip;
    public AudioClip attack3Clip;
    public AudioClip healClip;
    public bool canPlay = true;

    private int scared = 0;
    private int aggressive = 0;
    private int passive = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterPlayer>();
        animator = GetComponent<Animator>();
        musicController = GameObject.Find("MusicController");
        attack1Clip = (AudioClip)Resources.Load("BattleSounds/attack1");
        attack2Clip = (AudioClip)Resources.Load("BattleSounds/attack2");
        attack3Clip = (AudioClip)Resources.Load("BattleSounds/attack3");
        healClip = (AudioClip)Resources.Load("BattleSounds/heal");
    }

    // Play sound
    void PlaySound(AudioClip aClip)
    {
        musicController.GetComponent<MusicController>().PlayAudio(aClip);
    }

    public override void TakeTurn()
    {
        //if (mana >= manaMax)
        //{
        //    UseAbility(0);
        //}
        //else
        //{
        //    UseAbility(0);

        //}
        UseAbility(0);

    }

    void Update()
    {
        //if (hp <= 0)
        //{
        //    Death();
        //}
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
        PlaySound(attack1Clip);
        attack1Particle.Play();
        StartCoroutine(ChangeAnimation(1.0f));
    }

    public override void AttackHeavy()
    {
        animator.Play("Attack3");
        PlaySound(attack3Clip);
        attack3Particle.Play();
        StartCoroutine(ChangeAnimation(2.0f));
    }

    public override void AttackMedium()
    {
        animator.Play("Attack2");
        PlaySound(attack2Clip);
        attack2Particle.Play();
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
        healParticle.Play();
        PlaySound(healClip);
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public override void Heal(int healAmount)
    {
        if (mana >= healAmount)
        {
            hp += healAmount;
            mana -= healAmount;
        }
    }
    public override void Death()
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
        attack1Particle.Stop();
        attack2Particle.Stop();
        attack3Particle.Stop();
        healParticle.Stop();
    }
}
