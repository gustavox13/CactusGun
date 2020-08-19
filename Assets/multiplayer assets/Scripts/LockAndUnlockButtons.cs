using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class LockAndUnlockButtons : MonoBehaviourPun, IPunObservable
{
    [SerializeField]
    private Button[] moveButtons = new Button[3];

    [SerializeField]
    private Button[] atackButtons = new Button[3];

    [SerializeField]
    private Button startTurn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {

            if (GamePlayInfo.StartTurn == true)
            {
                StartCoroutine("EnableButtons");
            }
        }
    }


    IEnumerator EnableButtons()
    {
        yield return new WaitForSeconds(5.0f);

        startTurn.interactable = true;

        for (int i = 0; i < 3; i++) //ATIVA BOTOES DE ATK
        {
            atackButtons[i].interactable = true;
        }

        
        for (int i = 0; i < 3; i++) //ATIVA BOTOES DE MOVIMENTO
        {
            moveButtons[i].interactable = true;
        }
    }

    public void DisableButtons()
    {
        if (photonView.IsMine)
        {
            startTurn.interactable = false;

            for (int i = 0; i < 3; i++) //DESATIVA BOTOES DE ATK
            {
                atackButtons[i].interactable = false;
            }
            for (int i = 0; i < 3; i++) //DESATIVA BOTOES DE MOVIMENTO
            {
                moveButtons[i].interactable = false;
            }

        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
