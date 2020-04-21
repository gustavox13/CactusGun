using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class GamePlayInfo : MonoBehaviour
{
    public static bool StartTurn = false;


    private void Update()
    {
        //DEFINE SE OS DOIS JOGADORES ESTAO PRONTOS PARA O DUELO
        if ((bool)PhotonNetwork.PlayerList[0].CustomProperties["PlayerReady"] == true && (bool)PhotonNetwork.PlayerList[1].CustomProperties["PlayerReady"] == true)
        {
            StartTurn = true;
        }
        else
        {
            StartTurn = false;
        }
    }


}
