using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlotSelected : MonoBehaviour
{

    private bool positionSelected;
    private Animator animSelect;


    private void Awake()
    {
        positionSelected = false;
        animSelect = gameObject.GetComponent<Animator>();

    }

    public void IsSelected()
    {
        positionSelected = true;
    }

    public void IsNOTSelected()
    {
        positionSelected = false;
    }

    private void Update()
    {
        SetAnim();
    }


    private void SetAnim()
    {
        if (positionSelected == true)
        {
            animSelect.SetBool("SlotSelect", true);


        }
        else
        {
            animSelect.SetBool("SlotSelect", false);
        }
    }
}
