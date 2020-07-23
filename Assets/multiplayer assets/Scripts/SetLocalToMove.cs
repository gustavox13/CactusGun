using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class SetLocalToMove : MonoBehaviourPun, IPunObservable
{
    private string currentLocal = "A2";
    private string localToMove = null;

    [SerializeField]
    private GameObject A1Slot;
    [SerializeField]
    private GameObject A2Slot;
    [SerializeField]
    private GameObject A3Slot;
    [SerializeField]
    private GameObject PlayerBody;
    public bool playerReadyToMove = false;

    //controlar animacoes
    private Animator animPlayer;
    [SerializeField]
    private GameObject playerBodyAnim;


    private void Start()
    {
        if (photonView.IsMine)
        {
            //atualiza as informacoes do servidor
            PlayerInfoReady();

            //carregar animacao
            animPlayer = playerBodyAnim.GetComponentInChildren<Animator>();
        }
    }


    public void Update()
    {
        if (photonView.IsMine)
        {
            //se start turn (que define o inicio do duelo) for verdadeiro ele define o novo local e o player se move
            if (GamePlayInfo.StartTurn == true) 
            {
                currentLocal = localToMove;
                playerReadyToMove = false;
                PlayerInfoReady();

                StartCoroutine("MoveStepIn");
            }
            MovePlayer(PlayerBody.transform.position.y, PlayerBody.transform.position.z);
        }
    }

    //INICIA E DESATIVA ANIMACAO DE MOVIMENTO
    IEnumerator MoveStepIn()
    {
        animPlayer.SetBool("Desviando", true); //DESVIANDO FAZ O PERSONAGEM PULAR E ATIRAR
        
        //Pegar tempo animação Desviando
        Animator myAnimator = animPlayer;


        yield return new WaitForSeconds(0.8f); 

        animPlayer.SetBool("Desviando", false);



        //  //VAI PARA ANIMACAO DE DANO NO OUTRO SCRIPT
        GetComponent<HealthPlayerControler>().GoToTakeDamangeStep(); 
        

    }
   

    //quando o player seleciona um slot de movimento
    public void slotSelected(string local)
    {
        if (photonView.IsMine)
        {
            localToMove = local;
            //Debug.Log(local); //mostra o local que vc clicou
        }
    }

    // quando o player clica no botão duelo
    public void ReadyToMove()
    {
        if (photonView.IsMine)
        {
            playerReadyToMove = true;
            PlayerInfoReady(); 
        }
    }




    //informa que o player esta pronto para se movimentar
    private void PlayerInfoReady()
    {
        PlayerPhotonVariables.PlayerCustomProperties["PlayerCurrentLocal"] = localToMove;
        PlayerPhotonVariables.PlayerCustomProperties["PlayerReadyToMove"] = playerReadyToMove;       
        PhotonNetwork.SetPlayerCustomProperties(PlayerPhotonVariables.PlayerCustomProperties);

        CheckToReady();
    }

    //verifica se o player esta pronto para se mover e atacar, se sim o player esta pronto para o duelo
    private void CheckToReady()
    {
        if (photonView.IsMine)
        {
            if ((bool)PlayerPhotonVariables.PlayerCustomProperties["PlayerReadyToMove"] == true && (bool)PlayerPhotonVariables.PlayerCustomProperties["PlayerReadyToAtack"] == true)
            {
                PlayerPhotonVariables.PlayerCustomProperties["PlayerReady"] = true;
                PhotonNetwork.SetPlayerCustomProperties(PlayerPhotonVariables.PlayerCustomProperties);
            }
            else
            {
                PlayerPhotonVariables.PlayerCustomProperties["PlayerReady"] = false;
                PhotonNetwork.SetPlayerCustomProperties(PlayerPhotonVariables.PlayerCustomProperties);
            }
        }
    }

    //move o player
    private void MovePlayer(float y, float z)
    {
        if (photonView.IsMine)
        {
            Vector3 newPosition = new Vector3(0, y, z);

            //SELECIONA A POSICAO
            switch (currentLocal)
            {
                case "A1":
                    newPosition = new Vector3(A1Slot.transform.position.x, y, z);
                    break;

                case "A2":
                    newPosition = new Vector3(A2Slot.transform.position.x, y, z);
                    break;

                case "A3":
                    newPosition = new Vector3(A3Slot.transform.position.x, y, z);
                    break;
            }

            //MOVE O PLAYER
            PlayerBody.transform.position = Vector3.Lerp(PlayerBody.transform.position, newPosition, Time.deltaTime * 4);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
