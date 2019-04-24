using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkStats : MonoBehaviour
{
    public int BasicAtk
    {
        get { return basicAtk; }
        set { basicAtk = value; }
    }
    [SerializeField]
    private int basicAtk;

    public int TNTAtk
    {
        get { return tntAtk; }
        set { tntAtk = value; }
    }
    [SerializeField]
    private int tntAtk;

    public int TrapAtk
    {
        get { return trapAtk; }
        set { trapAtk = value; }
    }
    [SerializeField]
    private int trapAtk;
}
