using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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

    void Spawn(string prefabName)
    {
        GameObject spawnLocal = (UIhandler.myID == 0) ? spawn1 : spawn2; //isso aqui é um IF/switch, se chama operador ternário, se o ID for 0 vc vai nascer no spawn 1, se id for outra coisa diferente de 0, nasce no spawn 2

        PhotonNetwork.Instantiate(prefabName, spawnLocal.transform.position, spawnLocal.transform.rotation); // spawna o player selecionado no local indicado acima 
    }



}
