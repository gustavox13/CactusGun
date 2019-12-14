using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdcallerNew : MonoBehaviour
{

    private string adid = "3388768";
    private string videoad = "video";
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("Count");
        Monetization.Initialize(adid, true);

        ShowVideo();
       
    }

    
    void ShowVideo()
    {
        if (Monetization.IsReady(videoad) && count % 2 == 0)
        {
            count++;
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoad) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();

            }
        }
        else
        {
            count++;
        }

        PlayerPrefs.SetInt("Count", count);
    }



}
