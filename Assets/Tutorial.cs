using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    [SerializeField]
    private Image imageTutorial;
    [SerializeField]
    private Image imageFinger;

    private int tutorial = 0;



    // Start is called before the first frame update
    void Start()
    {
        tutorial = PlayerPrefs.GetInt("Tutorial");
    }

   

    public void CloseButton()
    {
        tutorial = 1;
        PlayerPrefs.SetInt("Tutorial", tutorial);

        imageTutorial.enabled = false;
        imageFinger.enabled = false;
        GetComponent<Canvas>().enabled = false;
    }
}
