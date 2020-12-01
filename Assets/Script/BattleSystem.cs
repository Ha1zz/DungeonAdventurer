using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.Events;

enum BattlePhase
{
    Player = 0,
    Enemy,
    Count
}


public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    public ICharacter[] combatants; //{ get; private set; }

    [SerializeField]
    BattlePhase phase;

    public UnityEvent<ICharacter> onCharacterTurnBegin;

    public string overWorld;

    public GameObject playerPrefab;
    private GameObject player;
    private GameObject enemy;
    private Animator animator;
    CharacterController playerControl;

    public int struggleChance;
    public int escapeChance;
    public int raiseDefenseChance;
    public int raiseAttackChance;

    // Start is called before the first frame update
    void Start()
    {
        //player = Instantiate(playerPrefab, transform.position, transform.rotation);
        //player.transform.position = new Vector3(-7.0f, -1.0f, 0.0f);
        //player.transform.localScale = new Vector3(8.0f, 8.0f, 1.0f);
        //animator = player.GetComponent<Animator>();
        ////playerControl = playerPrefab.GetComponent<CharacterController>();

        //enemy = Instantiate(playerPrefab, transform.position, transform.rotation);
        //enemy.transform.position = new Vector3(-7.0f, -1.0f, 0.0f);
        ////enemy.transform.localScale = new Vector3(8.0f, 8.0f, 1.0f);


        for (int i = 0; i < combatants.Length; i++)
        {
            combatants[i].onUseAbility.AddListener(CharacterUseAbility);
        }
        AdvanceTurn();
    }

    public void CharacterUseAbility(ICharacter caster, Ability ability)
    {
        ICharacter target = null;
        for (int i = 0; i < combatants.Length; i++)
        {
            if (caster != combatants[i])
            {
                target = combatants[i];
            }
        }

        ability.ApplyEffects(caster, target);

        StartCoroutine(DelaySwapTurns(3));
    }

    public void AdvanceTurn()
    {
        phase++;
        if (phase >= BattlePhase.Count)
        {
            phase = 0;
        }

        ICharacter whoseTurnItIs = combatants[(int)phase];
        //Debug.Log("It is " + whoseTurnItIs.name + "'s turn.");
        whoseTurnItIs.TakeTurn();
        onCharacterTurnBegin.Invoke(whoseTurnItIs);
    }

    IEnumerator DelaySwapTurns(float time)
    {
        yield return new WaitForSeconds(time);
        AdvanceTurn();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void OnTurnBegins()
    {

    }

    public void UpAttack()
    {
        PlayerController playerScript = player.GetComponent<PlayerController>();
        float tempAttack = playerScript.health;
        animator.Play("UpAttack");
    }

    public void UpDefense()
    {
        animator.Play("UpDefense");
    }

    public void Struggle()
    {
        animator.Play("Struggle");
    }

    public void Escape()
    {
        //animator.Play("Escape");
        //SceneManager.LoadScene(overWorld);
        AdvanceTurn();
    }

    //void NextTurn()
    //{
    //    currentPhase = (Phase)(((int)currentPhase + 1) % 2);
    //    character[(int)currentPhase].OnTurnBegins();
    //}

}

