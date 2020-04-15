using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;


    //tentando diferentes chars
    public GameObject char1prefab;
    public GameObject char2prefab;
    public GameObject char3prefab;


    private void Awake()
    {
        //SpawnPlayer();

        switch (SelectChar.CurrentChar)
        {
            case SelectChar.CHAR1:
                SpawnChar1();
                break;

            case SelectChar.CHAR2:
                SpawnChar2();
                break;

            case SelectChar.CHAR3:
                SpawnChar3();
                break;


        }


    }

    void SpawnChar1()
    {
        PhotonNetwork.Instantiate(char1prefab.name, playerPrefab.transform.position, playerPrefab.transform.rotation);
    }
    void SpawnChar2()
    {
        PhotonNetwork.Instantiate(char2prefab.name, playerPrefab.transform.position, playerPrefab.transform.rotation);
    }
    void SpawnChar3()
    {
        PhotonNetwork.Instantiate(char3prefab.name, playerPrefab.transform.position, playerPrefab.transform.rotation);
    }


    /*
    void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, playerPrefab.transform.rotation);
    }*/

}
