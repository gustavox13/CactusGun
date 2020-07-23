using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class HealthPlayerControler : MonoBehaviourPun, IPunObservable
{
    //controlar animacoes
    private Animator animPlayer;
    [SerializeField]
    private GameObject playerBodyAnim;


    private void Start()
    {
        if (photonView.IsMine)
        {
            animPlayer = playerBodyAnim.GetComponentInChildren<Animator>();
        }
    }

    public void GoToTakeDamangeStep()
    {
        if (photonView.IsMine)
        {
            StartCoroutine("TakeDamangeStep");
        }
    }



    IEnumerator TakeDamangeStep()
    {
        if (UIhandler.myID == 0 && GamePlayInfo.Player0TakeDamange == true)
        {
            animPlayer.SetBool("Dano", true);
            Debug.Log("eu, jogador 0 tomei dano e takedamange eh true");
            GamePlayInfo.Player0TakeDamange = false;
        }


        if (UIhandler.myID == 1 && GamePlayInfo.Player1TakeDamange == true)
        {
            animPlayer.SetBool("Dano", true);
            Debug.Log("eu, jogador 1 tomei dano e takedamange eh true");
            GamePlayInfo.Player1TakeDamange = false;
        }

        yield return new WaitForSeconds(0.3f); // espera e desativa animacao


        animPlayer.SetBool("Dano", false);

    }








    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
