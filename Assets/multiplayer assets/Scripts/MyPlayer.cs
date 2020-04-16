using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MyPlayer : MonoBehaviourPun, IPunObservable
{
    //CONFIGURACOES DO PHOTON
    public PhotonView pv;

    //CONFIGURACOES DO PERSONAGEM
    private Vector3 smoothMove;
    private Quaternion smootRotate;
    public GameObject playerCamera;


    //OBJETOS DO PLAYER
    [SerializeField]
    private GameObject revolver;
    [SerializeField]
    private GameObject slotsToMove;
    [SerializeField]
    private GameObject HUDcanvas;

    private void Start()
    {
        if (photonView.IsMine)
        {
            playerCamera.SetActive(true);
            revolver.SetActive(true);
           
            slotsToMove.SetActive(true); 
            HUDcanvas.SetActive(true);
        }
    }

    private void Update()
    {

        if (!photonView.IsMine)
        {
           // SmoothMovement();
        }
    }

  /*  private void SmoothMovement()
    {
        transform.position = Vector3.Lerp(transform.position, smoothMove, Time.deltaTime * 10);
        transform.rotation = Quaternion.Lerp(transform.rotation, smootRotate, Time.deltaTime * 10);
    }
  */

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        if (stream.IsReading)
        {
            smoothMove = (Vector3)stream.ReceiveNext();
            smootRotate = (Quaternion)stream.ReceiveNext();
        }
    }
}
