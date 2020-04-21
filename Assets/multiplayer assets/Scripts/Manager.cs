using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn1;
    [SerializeField]
    private GameObject spawn2;


    //tentando diferentes chars
    public GameObject char1prefab;
    public GameObject char2prefab;
    public GameObject char3prefab;

    private GameObject player1;

    //public static bool StartTurn = false;

    private void Start()
    {

        switch (SelectChar.CurrentChar)
        {
            case SelectChar.CHAR1:
                Spawn(char1prefab.name); 
                break;

            case SelectChar.CHAR2:
                Spawn(char2prefab.name);
                break;

            case SelectChar.CHAR3:
                Spawn(char3prefab.name);
                break;


        }

    }

        //SPAWN PLAYERS
    void Spawn(string prefabName)
    {
        GameObject spawnLocal = (UIhandler.myID == 0) ? spawn1 : spawn2; 

        PhotonNetwork.Instantiate(prefabName, spawnLocal.transform.position, spawnLocal.transform.rotation); 

       
    }



}
