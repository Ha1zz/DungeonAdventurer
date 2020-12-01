using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButtonScript : MonoBehaviour
{

    [SerializeField]
    int abilityID = 0;

    [SerializeField]
    BattleSystem battle;

    [SerializeField]
    TMPro.TextMeshProUGUI abilityNameText;
    [SerializeField]
    UnityEngine.UI.Button theButton;

    // Start is called before the first frame update
    void Start()
    {
        if (battle == null)
        {
            battle = FindObjectOfType<BattleSystem>();
        }

        Ability thisAbility = battle.combatants[(int)BattlePhase.Player].abilities[abilityID];

        if (thisAbility != null)
        {
            abilityNameText.text = thisAbility.name;
        }
        else
        {
            abilityNameText.text = "";
            theButton.interactable = false;
        }

        theButton.onClick.AddListener(Activate);
    }

    public void Activate()
    {
        battle.combatants[(int)BattlePhase.Player].UseAbility(abilityID);
    }
}
