using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class SetLocalToAtack : MonoBehaviourPun, IPunObservable
{
    private string currentLocalToAtk = "B2";
    private string localToAtk = null;


    private void Start()
    {

    }


    //quando o player seleciona um slot de movimento
    public void slotAtkSelected(string local)
    {
        if (photonView.IsMine)
        {
            localToAtk = local;
            currentLocalToAtk = localToAtk;

            PlayerSetLocalToAtk();
        }
    }


    private void PlayerSetLocalToAtk()
    {
        if (photonView.IsMine)
        {
            PlayerPhotonVariables.PlayerCustomProperties["PlayerCurrentLocalToAtk"] = currentLocalToAtk;
            //diz que o player esta pronto para atacar
            PlayerPhotonVariables.PlayerCustomProperties["PlayerReadyToAtack"] = true;
            PhotonNetwork.SetPlayerCustomProperties(PlayerPhotonVariables.PlayerCustomProperties);
        }
    }


    //funcao para TESTE apenas, depois pode apagar
    public void CheckPosition()
    {
        if (photonView.IsMine)
        {
            Debug.Log("o player vai atacar em: " + currentLocalToAtk);
        }

    }












    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
