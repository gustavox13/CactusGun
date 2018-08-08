using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLock : MonoBehaviour {

    [SerializeField]
    private Button[] buttons = new Button[7];

    public void EnableDisableButtons()
    {

        for(int i = 0; i < 7; i++)
        {
            buttons[i].interactable = !buttons[i].interactable;
        }

        if (!buttons[1].interactable)
        {
            StartCoroutine("EnableButtons");
        }

    }


    IEnumerator EnableButtons()
    {
        yield return new WaitForSeconds(3.0f);
        EnableDisableButtons();
    }

	
}
