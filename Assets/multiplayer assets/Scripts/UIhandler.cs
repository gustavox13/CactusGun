using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class UIhandler : MonoBehaviourPunCallbacks {

    //NUMERAR JOGADOR
    public static int myID;

    public InputField createRoomTF;
    public InputField joinRoomTF;

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomTF.text, null);
    }
    public void OnClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomTF.text, new RoomOptions { MaxPlayers = 2 }, null); // 2 players por sala

    }

    public override void OnJoinedRoom()
    {
        print("Room Joined Sucess");
        PhotonNetwork.LoadLevel(1);
        
        myID = PhotonNetwork.CountOfPlayersInRooms; // se vc entrar na sala primeiro Ganha 0, se for o segundo, ganha 1
       
        Debug.Log(myID);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("RoomFailed "+returnCode+" Message "+message);

    }
}
