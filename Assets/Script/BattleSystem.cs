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

public static class Global
{
    public static int changeSkillID = 0;  
}

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    public ICharacter[] combatants; //{ get; private set; }

    [SerializeField]
    BattlePhase phase;

    [Header("All Abilities")]
    [SerializeField]
    public Ability[] abilities = new Ability[4];

    public UnityEvent<ICharacter> onCharacterTurnBegin;

    [Header("Canvas System")]
    public CanvasSystem canvas;

    ///[SerializeField]
    //public static int changeSkillID;

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

        //if ((int)phase == 0)
        //{
        //    canvas.HideBattle();
        //}
        //if ((int)phase != 0)
        //{
        //    canvas.ShowBattle();
        //}

        StartCoroutine(DelaySwapTurns(4));
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
        if (IsEnemyDead() == false && IsPlayerDead() == false)
        {
            if ((int)phase != 0)
            {
                canvas.ShowBattle();
            }
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
        else
        {
            if (IsPlayerDead())
            {
                combatants[(int)BattlePhase.Player].Death();
                canvas.ShowLose();

            }
            if (IsEnemyDead())
            {
                combatants[(int)BattlePhase.Enemy].Death();
                canvas.ShowWin();
            }
        }

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

    bool IsPlayerDead()
    {
        if (combatants[(int)BattlePhase.Player].hp <= 0)
        {
            return true;
        }
        return false;
    }

    bool IsEnemyDead()
    {
        if (combatants[(int)BattlePhase.Enemy].hp <= 0)
        {
            return true;
        }
        return false;
    }

    public void OnTurnBegins()
    {

    }

    public void Escape()
    {
        //animator.Play("Escape");
        SceneManager.LoadScene("PlayScene");
        //AdvanceTurn();
    }

    public void ChangeScene(string sceneName = "PlayScene")
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadSave()
    {

    }

    //void NextTurn()
    //{
    //    currentPhase = (Phase)(((int)currentPhase + 1) % 2);
    //    character[(int)currentPhase].OnTurnBegins();
    //}

}

