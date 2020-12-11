using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class CharacterPlayer : ICharacter
{
    public Animator animator;
    //public CharacterPlayer player;
    public BattleSystem battleSystem;

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

    public Dictionary<int, int> skillList = new Dictionary<int,int>(); // Player Ability List - Battle All Ability List

    //public Animation amin;

    //[SerializeField]
    //List<AnimationClip> clips;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Ability1") == false)
        {
            skillList.Add(0, 0);
            PlayerPrefs.SetInt("Ability1", skillList[0]);
        }
        if (PlayerPrefs.HasKey("Ability2") == false)
        {
            skillList.Add(1, 1);
            PlayerPrefs.SetInt("Ability2", skillList[1]);
        }
        if (PlayerPrefs.HasKey("Ability1"))
        {
            skillList[0] = PlayerPrefs.GetInt("Ability1");
        }
        if (PlayerPrefs.HasKey("Ability2"))
        {
            skillList[1] = PlayerPrefs.GetInt("Ability2");
        }
        abilities[0] = battleSystem.abilities[skillList[0]];
        abilities[1] = battleSystem.abilities[skillList[1]];
    }

    // Start is called before the first frame update
    void Start()
    {

        hp = PlayerPrefs.GetFloat("Hp");
        mana = PlayerPrefs.GetFloat("Mana");
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

    }

    // Play sound
    void PlaySound(AudioClip aClip)
    {
        musicController.GetComponent<MusicController>().PlayAudio(aClip);
    }

    public override void TakeDamage(int baseDamage)
    {
        int damageTaken = baseDamage;
        hp -= baseDamage;
        onTakeDamage.Invoke(this, baseDamage);

    }

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

    public override void Death()
    {
        animator.Play("Death");
    }

    public override void Struggle()
    {
        
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

    public override void Escape()
    {
        PlaySound(escapeClip);
        //SceneManager.LoadScene("PlayScene");
    }

    IEnumerator ChangeAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        animator.Play("Idle");
        attack1Particle.Stop();
        attack2Particle.Stop();
        healParticle.Stop();
        struggleParticle.Stop();
    }

}
