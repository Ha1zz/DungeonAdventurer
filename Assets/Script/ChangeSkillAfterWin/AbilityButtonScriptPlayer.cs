using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButtonScriptPlayer : MonoBehaviour
{

    [SerializeField]
    int abilityID = 0;

    [SerializeField]
    BattleSystem battle;
    CharacterPlayer player;

    [SerializeField]
    TMPro.TextMeshProUGUI abilityNameText;
    [SerializeField]
    UnityEngine.UI.Button theButton;

    private Ability thisAbility;
    // Start is called before the first frame update
    void Start()
    {
        if (battle == null)
        {
            battle = FindObjectOfType<BattleSystem>();
        }
        if (player == null)
        {
            player = FindObjectOfType<CharacterPlayer>();
        }


        thisAbility = battle.combatants[(int)BattlePhase.Player].abilities[abilityID];

        theButton.onClick.AddListener(GetSkill);
    }

    void Update()
    {

        thisAbility = battle.combatants[(int)BattlePhase.Player].abilities[abilityID];

        if (thisAbility != null)
        {
            abilityNameText.text = thisAbility.name;
        }
        else
        {
            abilityNameText.text = "";
            theButton.interactable = false;
        }

        //Debug.Log("A1: " + PlayerPrefs.GetInt("Ability1"));
        //Debug.Log("A2: " + PlayerPrefs.GetInt("Ability2"));
        //Debug.Log("S1: " + player.skillList[0]);
        //Debug.Log("S2: " + player.skillList[1]);
    }

    public void GetSkill()
    {
        battle.combatants[(int)BattlePhase.Player].abilities[abilityID] = battle.abilities[Global.changeSkillID];
        switch(abilityID)
        {
            case 0:
                {
                    player.skillList[0] = Global.changeSkillID;
                    PlayerPrefs.SetInt("Ability1", player.skillList[0]);
                    return;
                }
            case 1:
                {
                    player.skillList[1] = Global.changeSkillID;
                    PlayerPrefs.SetInt("Ability2", player.skillList[1]);
                    return;
                }
            default:
                return;
        }

        //PlayerPrefs.SetInt("Ability1", player.skillList[0]);
        //PlayerPrefs.SetInt("Ability2", player.skillList[1]);
        StartCoroutine(WaitAndLoad());
    }
    

    IEnumerator WaitAndLoad(float time = 1.0f)
    {
        yield return new WaitForSeconds(time);
        battle.ChangeScene();
    }
}
