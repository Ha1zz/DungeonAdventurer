using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

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

    //public string overWorld;

    //CharacterController playerControl;

    public int struggleChance;
    public int escapeChance;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < combatants.Length; i++)
        {
            combatants[i].onUseAbility.AddListener(CharacterUseAbility);
        }
        //combatants[0].onUseAbility.AddListener(CharacterUseAbility);
        //combatants[1].AIonUseAbility.AddListener(AICharacterUseAbility);

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



        //ability.ApplyEffects(target, caster);

        ability.ApplyEffects(caster, target);

        StartCoroutine(DelaySwapTurns(6));
    }

    //public void AICharacterUseAbility(ICharacter caster, Ability ability)
    //{
    //    ICharacter target = combatants[1];
    //    caster = combatants[0];

    //    //ability.ApplyEffects(caster, target);

    //    ability.ApplyEffects(target, caster);

    //    StartCoroutine(DelaySwapTurns(3));
    //}

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

