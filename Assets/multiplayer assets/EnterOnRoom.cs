using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class EnterOnRoom : MonoBehaviour
{
    [SerializeField]
    private Text nameRoom;


    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(nameRoom.text, null);
    }
}
