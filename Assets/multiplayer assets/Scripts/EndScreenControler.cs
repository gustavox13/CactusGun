using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenControler : MonoBehaviour
{
    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
