using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class GamePlayInfo : MonoBehaviour
{
    public static bool StartTurn = false;
    public static bool Player0TakeDamange = false;
    public static bool Player1TakeDamange = false;



    private void Update()
    {
        //DEFINE SE OS DOIS JOGADORES ESTAO PRONTOS PARA O DUELO
        if ((bool)PhotonNetwork.PlayerList[0].CustomProperties["PlayerReady"] == true && (bool)PhotonNetwork.PlayerList[1].CustomProperties["PlayerReady"] == true)
        {

            Debug.Log("o player 0 esta em: " + PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocal"]);
            Debug.Log("o player 0 vai atacar em: " + PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocalToAtk"]);
            StartTurn = true;

            SearchDamangeArea();
        }
        else
        {
            StartTurn = false;

        }
    }

    private void SearchDamangeArea()
    {
        //jogador 1 toma dano se: 
        if (((string)PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocalToAtk"] == "B1" && (string)PhotonNetwork.PlayerList[1].CustomProperties["PlayerCurrentLocal"] == "A1") ||
            ((string)PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocalToAtk"] == "B2" && (string)PhotonNetwork.PlayerList[1].CustomProperties["PlayerCurrentLocal"] == "A2") ||
            ((string)PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocalToAtk"] == "B3" && (string)PhotonNetwork.PlayerList[1].CustomProperties["PlayerCurrentLocal"] == "A3"))
        {
            Debug.Log("jogador 1 tomou dano");
            Player1TakeDamange = true;
            
        }
        else {
            Debug.Log("jogador 1 NAO tomou dano");

        }


        //jogador 0 toma dano se: 
        if (((string)PhotonNetwork.PlayerList[1].CustomProperties["PlayerCurrentLocalToAtk"] == "B1" && (string)PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocal"] == "A1") ||
            ((string)PhotonNetwork.PlayerList[1].CustomProperties["PlayerCurrentLocalToAtk"] == "B2" && (string)PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocal"] == "A2") ||
            ((string)PhotonNetwork.PlayerList[1].CustomProperties["PlayerCurrentLocalToAtk"] == "B3" && (string)PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocal"] == "A3"))
        {
            Debug.Log("jogador 0 tomou dano");
            Player0TakeDamange = true;
            
        }
        else
        {
            Debug.Log("jogador 0 NAO tomou dano");
        }

    }
}
