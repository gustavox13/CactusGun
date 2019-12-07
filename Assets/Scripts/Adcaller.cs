using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Adcaller : MonoBehaviour
{


    private string adid = "3388768";
    private string videoad = "video";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Adshower()
    {
        if (Advertisement.IsReady(videoad))
        {
            Advertisement.Show(videoad);

        }

        
    
    }
}
