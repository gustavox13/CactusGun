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

    public static bool Player0Win = false;
    public static bool Player1Win = false;
    public static bool Empate = false;

    private void Update()
    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {

            //DEFINE SE OS DOIS JOGADORES ESTAO PRONTOS PARA O DUELO
            if ((bool)PhotonNetwork.PlayerList[0].CustomProperties["PlayerReady"] == true && (bool)PhotonNetwork.PlayerList[1].CustomProperties["PlayerReady"] == true)
            {

                //Debug.Log("o player 0 esta em: " + PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocal"]);
                //Debug.Log("o player 0 vai atacar em: " + PhotonNetwork.PlayerList[0].CustomProperties["PlayerCurrentLocalToAtk"]);
                StartTurn = true;

                SearchDamangeArea();
            }
            else
            {
                StartTurn = false;

            }


            if ((int)PhotonNetwork.PlayerList[1].CustomProperties["HP"] <= 0 && (int)PhotonNetwork.PlayerList[0].CustomProperties["HP"] <= 0)
            {
                Debug.Log("empate");
                Empate = true;
                Player1Win = false;
                Player0Win = false;
            }

            if ((int)PhotonNetwork.PlayerList[0].CustomProperties["HP"] <= 0 && (int)PhotonNetwork.PlayerList[1].CustomProperties["HP"] > 0)
            {
                Debug.Log("player 1 ganhou");
                Player1Win = true;
            }
            if ((int)PhotonNetwork.PlayerList[1].CustomProperties["HP"] <= 0 && (int)PhotonNetwork.PlayerList[0].CustomProperties["HP"] > 0)
            {
                Debug.Log("player 0 ganhou");
                Player0Win = true;
            }


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
            //Debug.Log("jogador 1 NAO tomou dano");

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
            //Debug.Log("jogador 0 NAO tomou dano");
        }



    }
}
