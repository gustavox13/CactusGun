using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class SetLocalToAtack : MonoBehaviourPun, IPunObservable
{
    private string currentLocalToAtk = "B2";
    private string localToAtk = null;

    [SerializeField]
    private GameObject HUDGame;
    private int typeAtk;


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

    //QUANDO DA 'GO' ELE PEGA O TIPO DE ATK E MANDA PARA O SERVER
    public void ReadyToUseSkill()
    {
        if (photonView.IsMine)
        {

            typeAtk = HUDGame.GetComponent<RevolverHUD>().CurrentSkill;

            PlayerPhotonVariables.PlayerCustomProperties["TypeSkill"] = typeAtk; //skill 1 = atk basico - skill 2 = tnt - skill 3 = trap
            PhotonNetwork.SetPlayerCustomProperties(PlayerPhotonVariables.PlayerCustomProperties);
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
