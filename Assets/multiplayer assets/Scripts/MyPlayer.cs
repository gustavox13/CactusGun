using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MyPlayer : MonoBehaviourPun, IPunObservable
{
    //photon setings
    public PhotonView pv;

    //character setings
    private float moveSpeed = 10;
    private Vector3 smoothMove;
    private Quaternion smootRotate;
    public GameObject playerCamera;

    //spawn setings
    private GameObject spawn1;
    private GameObject spawn2;




    private void Start()
    {
        spawn1 = GameObject.FindWithTag("SpawnPoint1");
        spawn2 = GameObject.FindWithTag("SpawnPoint2");

        if (photonView.IsMine)
         {
             playerCamera.SetActive(true);
         }

    

        if (photonView.IsMine)
        {
            if(pv.ViewID == 1001)
            {
                gameObject.transform.position = spawn1.transform.position;
                gameObject.transform.rotation = spawn1.transform.rotation;
            }
            else
            {
                gameObject.transform.position = spawn2.transform.position;
                gameObject.transform.rotation = spawn2.transform.rotation;
            }
        }
    }

    private void Update()
    {

        if (photonView.IsMine)
        {
            ProcessInputs();
        }
        else
        {
            SmoothMovement();
        }
    }

    private void SmoothMovement()
    {
        transform.position = Vector3.Lerp(transform.position, smoothMove, Time.deltaTime * 10);
        transform.rotation = Quaternion.Lerp(transform.rotation, smootRotate, Time.deltaTime * 10);
    }

    private void ProcessInputs()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

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
