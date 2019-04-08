using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour {

    private int lastPosition;
    private int randomPosition;
    private int randomAtk;


    public int SetLocalToJump()
    {
        randomPosition = Random.Range(0, 3);
        if (lastPosition == randomPosition)
        {
            return SetLocalToJump();
        }
        lastPosition = randomPosition;

        return randomPosition;
    }

    public int SetLocalToAtk()
    {
        randomAtk = Random.Range(0, 3);
        return randomAtk;
    }


}
