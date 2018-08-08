using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeField : MonoBehaviour {

    public bool InField
    {
        get { return inField; }
        set { inField = value; }
    }
    [SerializeField]
    private bool inField;


    private void OnMouseOver()
    {
        inField = true;
    }

    private void OnMouseExit()
    {
        inField = false;
    }

}
