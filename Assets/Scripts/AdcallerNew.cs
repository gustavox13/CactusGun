using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdcallerNew : MonoBehaviour
{

    private string adid = "3388768";
    private string videoad = "video";


    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(adid, true);

        if(Monetization.IsReady(videoad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoad) as ShowAdPlacementContent;
            if(ad != null)
            {
                ad.Show();

            }
        }
    }

    


}
