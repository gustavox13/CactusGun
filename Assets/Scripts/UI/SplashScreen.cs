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
       // logar na play games
    }

    private void Start()
    {
    
        StartCoroutine("Countdown");
    }


    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(secondsToChange);
        GoToAnimation();
    }



    private void GoToAnimation()
    {
            SceneManager.LoadScene("AnimationScene");
    
    }


   
}
