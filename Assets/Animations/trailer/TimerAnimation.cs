using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerAnimation : MonoBehaviour {

    private float currentTime;
    private GameObject currentTrack;

    [SerializeField]
    private GameObject Track1;
    [SerializeField]
    private float timeTrack1;

    [SerializeField]
    private GameObject Track2;
    [SerializeField]
    private float timeTrack2;

    [SerializeField]
    private GameObject Track3;
    [SerializeField]
    private float timeTrack3;

    [SerializeField]
    private GameObject Track4;
    [SerializeField]
    private float timeTrack4;

    [SerializeField]
    private GameObject Track5;
    [SerializeField]
    private float timeTrack5;


    [SerializeField]
    private Animator transition;

    [SerializeField]
    private Animator shotTransition;

    private void Awake()
    {
        DesactiveAllTracks();
        ConvertTimerTracks();
    }

    private void FixedUpdate () {
        Timer();
        ShowTracks();
	}

    private void ShowTracks()
    {
        if (currentTime < timeTrack1)
        {
            ActiveTrack(Track1);
        }
        else if (currentTime > timeTrack1 && currentTime < timeTrack2)
        {
            ActiveTrack(Track2);
        }
        else if (currentTime > timeTrack2 && currentTime < timeTrack3)
        {
            ActiveTrack(Track3);
        }
        else if (currentTime > timeTrack3 && currentTime < timeTrack4)
        {
           
            ActiveTrack(Track4);
        }
        else if (currentTime > timeTrack4 && currentTime < timeTrack5)
        {
           
            ActiveTrack(Track5);
        }
        else if (currentTime > timeTrack5)
        {
            SceneManager.LoadScene("MainMenu");
          
            
        }
    }

    private void ConvertTimerTracks()
    {
        timeTrack2 = timeTrack2 + timeTrack1;
        timeTrack3 = timeTrack3 + timeTrack2;
        timeTrack4 = timeTrack4 + timeTrack3;
        timeTrack5 = timeTrack5 + timeTrack4;
    }

    private void ActiveTrack( GameObject currentTrack)
    {
        currentTrack.SetActive(true);
    }

    private void DesactiveAllTracks()
    {
        Track1.SetActive(false);
        Track2.SetActive(false);
        Track3.SetActive(false);
        Track4.SetActive(false);
        Track5.SetActive(false);
    }

    private void Timer()
    {
        currentTime += Time.deltaTime;
    }

    public void SkipBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
