using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class destroyTNT : MonoBehaviourPun, IPunObservable
{
    void Start()
    {
        if (photonView.IsMine)
        {
            StartCoroutine(Tempo());
        }
    }


    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(3.5f);
        PhotonNetwork.Destroy(this.gameObject);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
