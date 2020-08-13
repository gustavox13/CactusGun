﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerPhotonVariables : MonoBehaviour
{
    public static Hashtable PlayerCustomProperties = new Hashtable(); // criar hashtable

    private void Start()
    {
        //cria as variaveis do player
        PlayerCustomProperties.Add("PlayerReadyToMove", false);
        PlayerCustomProperties.Add("PlayerReadyToAtack", false);
        PlayerCustomProperties.Add("PlayerReady", false);
        PlayerCustomProperties.Add("PlayerCurrentLocal", "A2");
        PlayerCustomProperties.Add("PlayerCurrentLocalToAtk", "B2");
        PlayerCustomProperties.Add("HP", 100);
        PlayerCustomProperties.Add("TypeSkill", 1);
    }
    
    
}
