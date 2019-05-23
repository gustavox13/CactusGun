using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToLvl : MonoBehaviour
{
   
    private string nameScene;



    public void LevelPresses(string currentLvl)
    {
        nameScene = currentLvl;
       
    }


    public void GoPress()
    {
        SceneManager.LoadScene(nameScene);
    }

}
