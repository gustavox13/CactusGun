using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuControler : MonoBehaviour
{
    //MENU SCREEN
    [SerializeField]
    private Animator duelButton;
    [SerializeField]
    private Animator shopButton;


    //MAP SCREEN
    [SerializeField]
    private Animator mapScreen;



    public void StoreButton()
    {
        SceneManager.LoadScene("store");
    }

    public void multiplayer()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void MapButton()
    {

        duelButton.SetBool("ButtonFade", false);
        shopButton.SetBool("ButtonFade", false);

        mapScreen.SetBool("ScreenMapFade", true);


        StartCoroutine(ChangeToMap());

       
    }
    private IEnumerator ChangeToMap()
    {
        yield return new WaitForSeconds(1.8f);
        SceneManager.LoadScene("SelectLevel");
    }

}
