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
    [Header("Struggle Chance 0 - 100")]
    public int struggleChance;
    [Header("Escape Chance 0 - 100")]
    public int escapeChance;


    private bool isStruggleSuccess;
    private bool isEscapeSuccess;

    // Start is called before the first frame update
    void Start()
    {
        isStruggleSuccess = false;
        isEscapeSuccess = false;
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

        StartCoroutine(DelaySwapTurns(3));
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
        if (isStruggleSuccess == false)
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
    }

    IEnumerator DelaySwapTurns(float time)
    {
        yield return new WaitForSeconds(time);
        canvas.HideFail();
        canvas.HideSuccess();
        AdvanceTurn();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("Hp");
        PlayerPrefs.DeleteKey("Mana");
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionY");
        PlayerPrefs.DeleteKey("Ability1");
        PlayerPrefs.DeleteKey("Ability2");
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
        if (escapeChance > 100)
            escapeChance = 100;
        int seed = Random.Range(0, 100);
        if (seed <= escapeChance)
        {
            canvas.ShowSuccess();
            StartCoroutine(Wait(5.0f));
            combatants[(int)BattlePhase.Player].Escape();
            PlayerPrefs.SetFloat("Hp", combatants[(int)BattlePhase.Player].hp);
            PlayerPrefs.SetFloat("Mana", combatants[(int)BattlePhase.Player].mana);
            SceneManager.LoadScene("PlayScene");
        }
        else
        {
            canvas.ShowFail();
            StartCoroutine(Wait(5.0f));
        }
    }

    public void Struggle()
    {
        if (struggleChance > 100)
            struggleChance = 100;
        int seed = Random.Range(0,100);
        if (seed <= struggleChance)
        {
            PlayerPrefs.SetFloat("Hp", combatants[(int)BattlePhase.Player].hp);
            PlayerPrefs.SetFloat("Mana", combatants[(int)BattlePhase.Player].mana);
            canvas.ShowSuccess();
            StartCoroutine(Wait(5.0f));
            combatants[(int)BattlePhase.Player].AttackHeavy();
            combatants[(int)BattlePhase.Enemy].TakeDamage(21);
            combatants[(int)BattlePhase.Enemy].GetHit();
        }
        else
        {
            canvas.ShowFail();
            StartCoroutine(Wait(5.0f));
        }     
    }

    public void ChangeScene(string sceneName = "PlayScene")
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadSave()
    {
        ChangeScene("PlayScene");
    }

    //void NextTurn()
    //{
    //    currentPhase = (Phase)(((int)currentPhase + 1) % 2);
    //    character[(int)currentPhase].OnTurnBegins();
    //}

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}

