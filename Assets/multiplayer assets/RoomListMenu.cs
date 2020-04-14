using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;

    [SerializeField]
    private RomListing roomlisting;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
       foreach(RoomInfo info in roomList)
        {
            RomListing listing = (RomListing)Instantiate(roomlisting, content);
            if (listing != null)
                listing.SetRoomInfo(info);
        }
    }

}
