using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class HealthPlayerControler : MonoBehaviourPun, IPunObservable
{
    //controlar animacoes
    private Animator animPlayer;
    [SerializeField]
    private GameObject playerBodyAnim;
    private int currentHP = 100;

    [SerializeField]
    private GameObject endScreen;
    [SerializeField]
    private GameObject loseCanvas;
    [SerializeField]
    private GameObject winCanvas;

    [SerializeField]
    private GameObject blockHUD;

    private bool Arrested;

    private void Start()
    {
        if (photonView.IsMine)
        {
            animPlayer = playerBodyAnim.GetComponentInChildren<Animator>();

            PlayerPhotonVariables.PlayerCustomProperties["HP"] = currentHP;
            PhotonNetwork.SetPlayerCustomProperties(PlayerPhotonVariables.PlayerCustomProperties);
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
          
        }


    }

    public void GoToTakeDamangeStep()
    {
        if (photonView.IsMine)
        {
            StartCoroutine("TakeDamangeStep");
        }
    }



    IEnumerator TakeDamangeStep()
    {
        if (UIhandler.myID == 0 && GamePlayInfo.Player0TakeDamange == true)  // --------------------------------------------- PLAYER 0 TOMA DANO
        {
            animPlayer.SetBool("Dano", true);
            Debug.Log("eu, jogador 0 tomei dano e takedamange eh true");
            GamePlayInfo.Player0TakeDamange = false;



            if (GamePlayInfo.Player1Skill == 1)
            {
                currentHP -= 25;
                Arrested = false;
            } else if (GamePlayInfo.Player1Skill == 2)
            {
                currentHP -= 50;
                Arrested = false;
            } else if (GamePlayInfo.Player1Skill == 3)
            {
                currentHP -= 10;
                Arrested = true;
            }



            PlayerPhotonVariables.PlayerCustomProperties["HP"] = currentHP;
            PhotonNetwork.SetPlayerCustomProperties(PlayerPhotonVariables.PlayerCustomProperties);

            // Debug.Log("meu hp eh: " + PlayerPhotonVariables.PlayerCustomProperties["HP"]);
        }
       /* else
        {
            Arrested = false;
            DebuffStatus();
        }*/


        if (UIhandler.myID == 1 && GamePlayInfo.Player1TakeDamange == true) // --------------------------------------------- PLAYER 1 TOMA DANO
        {
            animPlayer.SetBool("Dano", true);
            Debug.Log("eu, jogador 1 tomei dano e takedamange eh true");
            GamePlayInfo.Player1TakeDamange = false;

            if (GamePlayInfo.Player0Skill == 1)
            {
                currentHP -= 25;
                Arrested = false;
            }
            else if (GamePlayInfo.Player0Skill == 2)
            {
                currentHP -= 50;
                Arrested = false;
            }
            else if (GamePlayInfo.Player0Skill == 3)
            {
                currentHP -= 10;
                Arrested = true;
            }

            PlayerPhotonVariables.PlayerCustomProperties["HP"] = currentHP;
            PhotonNetwork.SetPlayerCustomProperties(PlayerPhotonVariables.PlayerCustomProperties);

            //Debug.Log("meu hp eh: " + PlayerPhotonVariables.PlayerCustomProperties["HP"]);
        }
       /* else
        {
            Arrested = false;
            DebuffStatus();
        }*/



        yield return new WaitForSeconds(0.8f); // espera e desativa animacao

        Debug.Log("HP do player 0 eh: " + PhotonNetwork.PlayerList[0].CustomProperties["HP"]);
        Debug.Log("HP do player 1 eh: " + PhotonNetwork.PlayerList[1].CustomProperties["HP"]);

        animPlayer.SetBool("Dano", false);

        StartCoroutine("VictoryOrDefeat");

    }

    IEnumerator VictoryOrDefeat()
    {
        yield return new WaitForSeconds(1.0f); // espera atualizar os dados

        VerifyVictory();
    }


    private void VerifyVictory()
    {

        if(GamePlayInfo.Player0Win == true || GamePlayInfo.Player1Win == true || GamePlayInfo.Empate == true)
        {
            Debug.Log("alguem ganhou");

            if (GamePlayInfo.Player0Win == true && UIhandler.myID == 0)
            {
                endScreen.SetActive(true);
                winCanvas.SetActive(true);
            }
            if (GamePlayInfo.Player1Win == true && UIhandler.myID == 1)
            {
                endScreen.SetActive(true);
                winCanvas.SetActive(true);
            }
            if(GamePlayInfo.Empate == true)
            {
                endScreen.SetActive(true);
                loseCanvas.SetActive(true);
            }

            if (GamePlayInfo.Player0Win == true && UIhandler.myID == 1)
            {
                endScreen.SetActive(true);
                loseCanvas.SetActive(true);
            }
            if (GamePlayInfo.Player1Win == true && UIhandler.myID == 0)
            {
                endScreen.SetActive(true);
                loseCanvas.SetActive(true);
            }

        }
        else
        {
            DebuffStatus();
        }
    }

    private void DebuffStatus()
    {
        if (photonView.IsMine)
        {
            Debug.Log("ele entrou no debuffstatus e arrested = " + Arrested);
            if(Arrested == true)
            {
                blockHUD.SetActive(true);
            }
            else
            {
                blockHUD.SetActive(false);
            }
        }
    }

    public void isNotArrested()
    {
        Arrested = false;
        blockHUD.SetActive(false);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
