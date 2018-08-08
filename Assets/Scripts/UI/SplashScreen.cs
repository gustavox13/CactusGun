using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    [SerializeField]
    private float secondsToChange = 2f;

    private int gameStats;

    private void Awake()
    {
        PlayServices.LogIn(); //logar
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        
        StartCoroutine("Countdown");
    }


    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(secondsToChange);
        VerifyIntro();
    }



    private void VerifyIntro()
    {
        if (PlayerPrefs.HasKey("HasOpened"))
        {
            gameStats = PlayerPrefs.GetInt("HasOpened");
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            gameStats = 1;
            PlayerPrefs.SetInt("HasOpened", gameStats);
            SceneManager.LoadScene("AnimationScene");
        }


    }


   
}
