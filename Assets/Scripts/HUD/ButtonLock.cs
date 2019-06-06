using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLock : MonoBehaviour {

    [SerializeField]
    private Button[] buttons = new Button[7];

    [SerializeField]
    private GameObject playerActions;


    private void Awake()
    {
        buttons[6].interactable = false;
    }

   
       
    


    private void Update()
    {
        if (playerActions.GetComponent<PlayerActions>().PlayerAtk != -5 && playerActions.GetComponent<PlayerActions>().PlayerPosition != -5 && buttons[0].interactable == true && playerActions.GetComponent<TamborRotate>().HaveItens == true)
        {
            buttons[6].interactable = true;
        }
        else
        {
            buttons[6].interactable = false;
        }
 
    }



    public void EnableDisableButtons()
    {
        //desativa tudo
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
