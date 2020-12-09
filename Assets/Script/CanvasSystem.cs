using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;

public class CanvasSystem : MonoBehaviour
{
    private Canvas changeSkillCanvas;
    public Canvas battleCanvas;
    private Canvas winCanvas;
    private Canvas loseCanvas;
    private Canvas successCanvas;
    private Canvas failCanvas;

    private bool isChangeOn;
    private bool isBattleOn;

    //[SerializeField]
    //BattleSystem battle;

    // Start is called before the first frame update
    void Start()
    {
        //if (battle == null)
        //{
        //    battle = FindObjectOfType<BattleSystem>();
        //}
        changeSkillCanvas = GameObject.Find("ChangeSkillCanvas").GetComponent<Canvas>();
        changeSkillCanvas.enabled = false;
        isChangeOn = false;
        isBattleOn = true;
        battleCanvas = GameObject.Find("BattleCanvas").GetComponent<Canvas>();
        battleCanvas.enabled = true;
        winCanvas = GameObject.Find("WinCanvas").GetComponent<Canvas>();
        winCanvas.enabled = false;
        loseCanvas = GameObject.Find("LoseCanvas").GetComponent<Canvas>();
        loseCanvas.enabled = false;
        successCanvas = GameObject.Find("SuccessCanvas").GetComponent<Canvas>();
        successCanvas.enabled = false;
        failCanvas = GameObject.Find("FailCanvas").GetComponent<Canvas>();
        failCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleSkillCanvas();
        }
    }

    void LateUpdate()
    {

    }

    public void ShowLose()
    {
        //if (battle.combatants[(int)BattlePhase.Player].hp <= 0)
        //{
        //    loseCanvas.enabled = true;
        //}
        loseCanvas.enabled = true;
        battleCanvas.enabled = false;
    }

    public void ShowWin()
    {
        //if (battle.combatants[(int)BattlePhase.Enemy].hp <= 0)
        //{
        //    winCanvas.enabled = true;
        //    battleCanvas.enabled = false;
        //}
        winCanvas.enabled = true;
        changeSkillCanvas.enabled = true;
        battleCanvas.enabled = false;
    }

    public void ShowBattle()
    {
        battleCanvas.enabled = true;
    }

    public void HideBattle()
    {
        battleCanvas.enabled = false;
    }

    public void ShowSuccess()
    {
        successCanvas.enabled = true;
    }

    public void HideSuccess()
    {
        successCanvas.enabled = false;
    }

    public void ShowFail()
    {
        failCanvas.enabled = true;
    }

    public void HideFail()
    {
        failCanvas.enabled = false;
    }



    public void ToggleBattle()
    {
        if (isBattleOn)
        {
            battleCanvas.enabled = false;
            isBattleOn = false;
        }
        else
        {
            battleCanvas.enabled = true;
            isBattleOn = true;
        }
    }


    void ToggleSkillCanvas()
    {
        if (isChangeOn)
        {
            changeSkillCanvas.enabled = false;
            isChangeOn = false;
        }
        else
        {
            changeSkillCanvas.enabled = true;
            isChangeOn = true;
        }
    }
}
