using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using CloudOnce;

public class Adcaller : MonoBehaviour
{


    private string adid = "3388768";
    private string videoad = "video";
    private int count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        count = PlayerPrefs.GetInt("Count");
    }

    public void Adshower()
    {
        if (Advertisement.IsReady(videoad) && count % 2 == 0 && CloudVariables.Ads == 0)
        {
            
            count++;
            

            
            var options = new ShowOptions { resultCallback = HandleShowResult};
            Advertisement.Show(videoad, options);

        }else
        {
            count++;
            SceneManager.LoadScene(PlayerStats.LvlStats.CurrentMap);
        }

        PlayerPrefs.SetInt("Count", count);
        


    }


    public void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                SceneManager.LoadScene(PlayerStats.LvlStats.CurrentMap);
              
                break;

            case ShowResult.Skipped:
                SceneManager.LoadScene(PlayerStats.LvlStats.CurrentMap);

                break;


        }
    }




}
