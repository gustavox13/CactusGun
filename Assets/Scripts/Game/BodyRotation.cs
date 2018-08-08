using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BodyRotation : MonoBehaviour {

    [SerializeField]
    private GameObject gameControler;

    [SerializeField]
    private Transform[] plataforms = new Transform[3];

    [SerializeField]
    private string tagObject;


    private void Update()
    {
        if (tagObject == "player")
        {

            transform.LookAt(plataforms[gameControler.GetComponent<ActionGame>().PlayerLocalToAtk]);

        }
        else
        {
            transform.LookAt(plataforms[gameControler.GetComponent<ActionGame>().EnemyLocalToAtk]);
        }
    }





}
