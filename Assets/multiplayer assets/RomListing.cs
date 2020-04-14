using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RomListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _text.text = roomInfo.Name;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
