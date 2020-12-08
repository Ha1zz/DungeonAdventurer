using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CharacterPlayer : ICharacter
{
    public Animator animator;
    public CharacterPlayer player;

    [Header("Particle System")]
    public ParticleSystem attack1Particle;
    public ParticleSystem attack2Particle;
    public ParticleSystem struggleParticle;

    //public Animation amin;

    //[SerializeField]
    //List<AnimationClip> clips;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //amin = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Death();
        }
    }

    //public override void TakeTurn()
    //{
    //    Debug.Log("PLAYER");
    //}

    //public override void UseAbility(int id)
    //{
    //    Debug.Log("PLAYER");
    //    onUseAbility.Invoke(this, abilities[id]);
    //}

    //public override void PlayAnimation(AnimationClip animo)
    //{
    //    anim.clip = amino;
    //    amin.Play();
    //}

    public override void TakeDamage(int baseDamage)
    {
        int damageTaken = baseDamage;
        hp -= baseDamage;
        onTakeDamage.Invoke(this, baseDamage);

    }

    //public override void PlayAnimation(AnimationClip clip)
    //{
    //    animation.clip = clip;
    //    animation.Play();
    //}






    public override void AttackLight()
    {
        animator.Play("Attack1");
        attack1Particle.Play();
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public override void AttackHeavy()
    {
        animator.Play("Attack3");
        struggleParticle.Play();
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public override void AttackMedium()
    {
        animator.Play("Attack2");
        attack2Particle.Play();
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public override void GetHit()
    {
        animator.Play("GetHit");
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public void Death()
    {
        animator.Play("Death");
    }

    IEnumerator ChangeAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        animator.Play("Idle");
        attack1Particle.Stop();
        attack2Particle.Stop();
        struggleParticle.Stop();
    }

}
