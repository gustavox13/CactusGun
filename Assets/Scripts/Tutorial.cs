using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Button btnClose;
    [SerializeField]
    private Canvas canvTuto;
    [SerializeField]
    private Image finger;
    private int tutorial = 0;


    void Start()
    {

     

        tutorial = PlayerPrefs.GetInt("Tutorial");
        if (tutorial != 0)
        {
            
            canvTuto.GetComponent<Canvas>().enabled = false;
            btnClose.GetComponent<Image>().enabled = false;
            finger.GetComponent<Image>().enabled = false;
        }
       
       
    }

    public void CloseTutorial()
  {
        tutorial = 1;
        
        PlayerPrefs.SetInt("Tutorial", tutorial);

        GetComponent<Image>().enabled = false;
        btnClose.GetComponent<Image>().enabled = false;
        finger.GetComponent<Image>().enabled = false;

    }
}
