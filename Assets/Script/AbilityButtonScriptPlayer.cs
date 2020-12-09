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
    }

    public void GetSkill()
    {
        battle.combatants[(int)BattlePhase.Player].abilities[abilityID] = battle.abilities[Global.changeSkillID];
        StartCoroutine(WaitAndLoad());
    }
    

    IEnumerator WaitAndLoad(float time = 1.0f)
    {
        yield return new WaitForSeconds(time);
        battle.ChangeScene();
    }
}
