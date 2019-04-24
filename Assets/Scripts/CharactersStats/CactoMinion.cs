using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactoMinion : MonoBehaviour
{
    public int BasicAtk
    {
        get { return basicAtk; }
        set { basicAtk = value; }
    }
    [SerializeField]
    private int basicAtk;

}
