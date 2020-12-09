using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeSkillPanel : MonoBehaviour
{
    private Canvas changeSkillCanvas;
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        changeSkillCanvas = GameObject.Find("ChangeSkillCanvas").GetComponent<Canvas>();
        changeSkillCanvas.enabled = false;
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCanvas();
        }
    }

    void ToggleCanvas()
    {
        if (isOn)
        {
            changeSkillCanvas.enabled = false;
            isOn = false;
        }
        else
        {
            changeSkillCanvas.enabled = true;
            isOn = true;
        }
    }
}
