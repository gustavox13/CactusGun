using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MapControl : MonoBehaviour
{
    [SerializeField]
    private Button[] Levelbuttons;
    [SerializeField]
    private Image[] Enemys;
    [SerializeField]
    private Image Enemy;
    [SerializeField]
    private GameObject cartaz;

    [SerializeField]
    private Animator animatorButtonRankHiden;
    int levelPassed;
    // Use this for initialization

    [SerializeField]
    private TextMeshProUGUI[] textLevels;
    [SerializeField]
    private TextMeshProUGUI textGolden;
    [SerializeField]
    private TextMeshProUGUI textRuby;
    private Variables variables;
    private int fase = 0;

    //Controlar 
   

    void Start ()
    {
        variables = GetComponent<Variables>();
        variables.LoadSave();
        //levelPassed = PlayerPrefs.GetInt("LevelPassed");
        Enemy = GetComponent<Image>();

        levelPassed = 1;

        switch (levelPassed) //liberar fase
        {
            case 1:
                Levelbuttons[levelPassed -1].interactable = true;
                break;
            case 2:
                Levelbuttons[levelPassed -1].interactable = true;
                break;
            case 3:
                Levelbuttons[levelPassed-1].interactable = true;
                break;
            case 4:
                Levelbuttons[levelPassed-1].interactable = true;
                break;
            case 5:
                Levelbuttons[levelPassed-1].interactable = true;
                break;
            case 6:
                Levelbuttons[levelPassed-1].interactable = true;
                break;
            case 7:
                Levelbuttons[levelPassed-1].interactable = true;
                break;
        }

       
    }


    public void Update()
    {
        UpdateText();//Atualiza o texto do level atual 
    }


    public void levelToLoad(int level)
    {

        fase = level;  // fase == 3
       variables.currentLevel = fase;
        Wanted(fase); //+2
    }

    public void Wanted(int level)
    {
        Desactive();
        
        cartaz.gameObject.SetActive(true);
        Enemys[level-1].gameObject.SetActive(true);
        animatorButtonRankHiden.SetBool("SelectEnemy", true);
       
    }

    public void CloseWanted()
    {
        animatorButtonRankHiden.SetBool("SelectEnemy", false);
        // animatorButtonRankHiden.SetBool("SelectEnemy", false);
    }

    public void Desactive()
    {
        Enemys[0].gameObject.SetActive(false);
        Enemys[1].gameObject.SetActive(false);
        Enemys[2].gameObject.SetActive(false);
        Enemys[3].gameObject.SetActive(false);
        Enemys[4].gameObject.SetActive(false);
        Enemys[5].gameObject.SetActive(false);
        Enemys[6].gameObject.SetActive(false);
        Enemys[7].gameObject.SetActive(false);
        
    }

    public void UpdateText()
    {
        textLevels[0].text = variables.level[0].ToString() + " /10"; //Level 1
        textLevels[1].text = variables.level[1].ToString() + " /10";//Level 2
        textLevels[2].text = variables.level[2].ToString() + " /10";//Level 3
        textLevels[3].text = variables.level[3].ToString() + " /1";//Level 4
        textLevels[4].text = variables.level[4].ToString() + " /1";//Level 5
        textLevels[5].text = variables.level[5].ToString() + " /10";//Level 6
        textLevels[6].text = variables.level[6].ToString() + " /10";//Level 7
        textLevels[7].text = variables.level[7].ToString() + " /20";//Level1 8

       

        textGolden.text = variables.golden.ToString();
        textRuby.text = variables.ruby.ToString();

    }

    public void LoadLevel(int level)
    {
        variables.currentLevel = fase;
        variables.SaveVariables();
        SceneManager.LoadScene(fase + 2);

        
       
    }



}
