using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {


    public int PlayerAtk
    {
        get { return playerAtk; }
        set { playerAtk = value; }
    }
    private int playerAtk = 1;

    public int PlayerPosition
    {
        get { return playerPosition; }
        set { playerPosition = value; }
    }
    private int playerPosition = 1;

    private void Awake()
    {
        PlayerPosition = -5;
        playerAtk = -5;
    }



    public void SetLocalToJump(int var)
    {
        playerPosition = var;    
    }

    public void SetLocalToAtk(int var)
    {
        playerAtk = var; 
    }
}
