using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinDefeat : MonoBehaviour {

	public void MenuPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AgainPress()
    {
        SceneManager.LoadScene("SelectLevel");

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


 
   

  
}
