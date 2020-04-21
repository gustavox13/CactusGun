using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class SetLocalToAtack : MonoBehaviourPun, IPunObservable
{
    private void Start()
    {
        if (photonView.IsMine)
        {
            //(PROVISORIO) diz que o player esta pronto para atacar
            PlayerPhotonVariables.PlayerCustomProperties["PlayerReadyToAtack"] = true;
            PhotonNetwork.SetPlayerCustomProperties(PlayerPhotonVariables.PlayerCustomProperties);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
