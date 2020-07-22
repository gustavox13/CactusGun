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














    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
