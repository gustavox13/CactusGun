using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationsButtonMenu : MonoBehaviour {

    //MENU SCREEN
    [SerializeField]
    private Animator duelButton;
    [SerializeField]
    private Animator shopButton;
    [SerializeField]
    private GameObject mapButtons;


    //MAP SCREEN
    [SerializeField]
    private Animator mapScreen;
    [SerializeField]
    private Animator map;

    [SerializeField]
    private Animator backButton;

    //WANTED SCREEN
    [SerializeField]
    private Animator wantedScreen;
    [SerializeField]
    private Animator goButton;

    //STORE SCREEN
    [SerializeField]
    private GameObject storeScreen;


    private void Awake()
    {
        storeScreen.SetActive(false);
        mapButtons.SetActive(false);
    }

    public void DuelPress()
    {
        //MENU ACTIONS
        duelButton.SetBool("ButtonFade", false);
        shopButton.SetBool("ButtonFade", false);


        //MAP SCREEN ACTIONS
        mapScreen.SetBool("ScreenMapFade", true);
        map.SetBool("OpenMap", true);
        backButton.SetBool("ButtonFade", true);
        StartCoroutine(ShowMapButtons());
    }

    private IEnumerator ShowMapButtons()
    {
        yield return new WaitForSeconds(1.5f);
        mapButtons.SetActive(true);
    }


    public void LevelSelectAnim()
    {
        mapButtons.SetActive(false);
        map.SetBool("OpenMap", false);
        wantedScreen.SetBool("WantedMapFade", true);
        goButton.SetBool("ButtonFade", true);
    }

    public void BackButton()
    {
        //WANTED SCREEN ACTIONS
        wantedScreen.SetBool("WantedMapFade", false);
        goButton.SetBool("ButtonFade", false);

        //MAP SCREEN ACTIONS
        mapButtons.SetActive(false);
        mapScreen.SetBool("ScreenMapFade", false);
        map.SetBool("OpenMap", false);
        backButton.SetBool("ButtonFade", false);

        //MENU SCREEN ACTIONS
        duelButton.SetBool("ButtonFade", true);
        shopButton.SetBool("ButtonFade", true);
    }

    public void StoreButton()
    {
        storeScreen.SetActive(true);
    }

    public void StoreBackButton()
    {
        storeScreen.SetActive(false);
    }
   

}
