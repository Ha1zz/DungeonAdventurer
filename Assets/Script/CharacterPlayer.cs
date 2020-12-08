using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class CharacterPlayer : ICharacter
{
    public Animator animator;
    public CharacterPlayer player;

    [Header("Particle System")]
    public ParticleSystem attack1Particle;
    public ParticleSystem attack2Particle;
    public ParticleSystem struggleParticle;
    public ParticleSystem healParticle;

    [Header("Sound System")]
    public GameObject musicController;
    public AudioClip attack1Clip;
    public AudioClip attack2Clip;
    public AudioClip attack3Clip;
    public AudioClip escapeClip;
    public AudioClip healClip;
    public bool canPlay = true;

    //public Animation amin;

    //[SerializeField]
    //List<AnimationClip> clips;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        musicController = GameObject.Find("MusicController");
        attack1Clip = (AudioClip)Resources.Load("BattleSounds/attack1");
        attack2Clip = (AudioClip)Resources.Load("BattleSounds/attack2");
        attack3Clip = (AudioClip)Resources.Load("BattleSounds/attack3");
        escapeClip = (AudioClip)Resources.Load("BattleSounds/escape");
        healClip = (AudioClip)Resources.Load("BattleSounds/heal");
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

    // Play sound
    void PlaySound(AudioClip aClip)
    {
        musicController.GetComponent<MusicController>().PlayAudio(aClip);
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
        PlaySound(attack1Clip);
        attack1Particle.Play();
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public override void AttackHeavy()
    {
        animator.Play("Attack3");
        PlaySound(attack3Clip);
        struggleParticle.Play();
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public override void AttackMedium()
    {
        animator.Play("Attack2");
        PlaySound(attack2Clip);
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

    public override void Struggle()
    {

    }

    public override void HealAnimation()
    {
        animator.Play("Heal");
        struggleParticle.Play();
        PlaySound(healClip);
        StartCoroutine(ChangeAnimation(0.5f));
    }

    public override void Heal(int healAmount)
    {
        //animator.Play("GetHit");
        //int damageTaken = healAmount;
        hp += healAmount;
        mana -= healAmount;
        //onHeal.Invoke(this, healAmount);
        //(ChangeAnimation());
    }

    public override void Escape()
    {
        PlaySound(escapeClip);
        SceneManager.LoadScene("PlayScene");
    }

    IEnumerator ChangeAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        animator.Play("Idle");
        attack1Particle.Stop();
        attack2Particle.Stop();
        healParticle.Stop();
    }

}
