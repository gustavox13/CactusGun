using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SetLocalToMove : MonoBehaviourPun, IPunObservable
{
    private string currentLocal = "A2";
    private string localToMove = null;

    [SerializeField]
    private GameObject A1Slot;
    [SerializeField]
    private GameObject A2Slot;
    [SerializeField]
    private GameObject A3Slot;

    [SerializeField]
    private GameObject PlayerBody;


    //SELECIONA O SLOT
    public void slotSelected(string local)
    {
        if (photonView.IsMine)
        {
            localToMove = local;
            Debug.Log(local);
        }
    }



    public void Update()
    {
        if (photonView.IsMine)
        {
            MovePlayer(PlayerBody.transform.position.y, PlayerBody.transform.position.z);
        }
    }

    public void ReadyToMove()
    {
        if (photonView.IsMine)
        {
            currentLocal = localToMove;
        }
    }


    private void MovePlayer(float y, float z)
    {
        if (photonView.IsMine)
        {
            Vector3 newPosition = new Vector3(0, y, z);

            //SELECIONA A POSICAO
            switch (currentLocal)
            {
                case "A1":
                    newPosition = new Vector3(A1Slot.transform.position.x, y, z);
                    break;

                case "A2":
                    newPosition = new Vector3(A2Slot.transform.position.x, y, z);
                    break;

                case "A3":
                    newPosition = new Vector3(A3Slot.transform.position.x, y, z);
                    break;
            }

            //MOVE O PLAYER
            PlayerBody.transform.position = Vector3.Lerp(PlayerBody.transform.position, newPosition, Time.deltaTime * 4);
        }
    }





    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
