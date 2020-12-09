using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class AbilityButtonScriptEnemy : MonoBehaviour
{

    [SerializeField]
    int abilityID = 0;

    [SerializeField]
    BattleSystem battle;

    [SerializeField]
    TMPro.TextMeshProUGUI abilityNameText;
    [SerializeField]
    UnityEngine.UI.Button theButton;

    private Ability thisAbility;

    public Canvas enemySkillCanvas;
    public Canvas playerSkillCanvas;

    // Start is called before the first frame update
    void Start()
    {
        enemySkillCanvas = GameObject.Find("EnemyCanvas").GetComponent<Canvas>();
        playerSkillCanvas = GameObject.Find("PlayerCanvas").GetComponent<Canvas>();

        if (battle == null)
        {
            battle = FindObjectOfType<BattleSystem>();
        }

        thisAbility = battle.combatants[(int)BattlePhase.Enemy].abilities[abilityID];

        if (thisAbility != null)
        {
            abilityNameText.text = thisAbility.name;
        }
        else
        {
            abilityNameText.text = "";
            theButton.interactable = false;
        }

        playerSkillCanvas.enabled = false;
        theButton.onClick.AddListener(ChangeSkill);
    }

    void Update()
    {
        thisAbility = battle.combatants[(int)BattlePhase.Enemy].abilities[abilityID];

        if (thisAbility != null)
        {
            abilityNameText.text = thisAbility.name;
        }
        else
        {
            abilityNameText.text = "";
            theButton.interactable = false;
        }
    }

    public void ChangeSkill()
    {
        Global.changeSkillID = abilityID;
        playerSkillCanvas.enabled = true;
        enemySkillCanvas.enabled = false;
    }


    //public void Activate()
    //{
    //    battle.combatants[(int)BattlePhase.Enemy].UseAbility(abilityID);
    //}
}
