using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{

    private GameObject AC;
	// Use this for initialization
	void Start ()
    {

        //Time.timeScale = 0;
        Ads();//Verifica se é a primeira vez

        
       
    }

    public void Ads()
    {
        if (Advertisement.IsReady())
        {
           // if(GetComponent<AcountController>().RemoveADS == 0)
              Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult});
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                Time.timeScale = 1;
                break;
        }
    }
	
	
}
