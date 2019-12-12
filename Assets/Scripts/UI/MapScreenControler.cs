using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;
using UnityEngine.SceneManagement;

public class MapScreenControler : MonoBehaviour
{


    //WANTED SCREEN
    [SerializeField]
    private Animator wantedScreen;
    [SerializeField]
    private Animator goButton;


    [SerializeField]
    private Button minaAbandonada;
    [SerializeField]
    private Button montanhasDoSul;
    [SerializeField]
    private Button cidadela;
    [SerializeField]
    private Button florestaNoturna;
    [SerializeField]
    private Button pantanoDosMortos;
    [SerializeField]
    private Button desertoSilencioso;
    [SerializeField]
    private Button vilarejoFantasma;
    [SerializeField]
    private Button valeDoDesespero;

    private void Awake()
    {

        LoadValues();

        CheckAndUnlockLvls();


    }

    //--------------------- Resgatar valores salvos ------------------------
    private void LoadValues()
    {
        Cloud.Storage.Load();

        gameObject.GetComponent<SaveFunctions>().LoadLevel();
    }




    private void CheckAndUnlockLvls()
    {

        if (PlayerStats.LvlStats.VilarejoFantasma < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            valeDoDesespero.interactable = false;

        }
        if (PlayerStats.LvlStats.ValeDoDesespero < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            pantanoDosMortos.interactable = false;

        }
        if (PlayerStats.LvlStats.PantanoDosMortos < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            minaAbandonada.interactable = false;

        }
        if (PlayerStats.LvlStats.MinaAbandonada < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            cidadela.interactable = false;

        }
        if (PlayerStats.LvlStats.Cidadela < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            florestaNoturna.interactable = false;

        }
        if (PlayerStats.LvlStats.FlorestaNoturna < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            montanhasDoSul.interactable = false;

        }
        if (PlayerStats.LvlStats.MontanhasDoSul < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            desertoSilencioso.interactable = false;
        }

    }

    public void LevelSelectAnim()
    {
      

        //MOVE A TELA WANTED
        StartCoroutine(TimeLevelSelectAnim());
    }


    private IEnumerator TimeLevelSelectAnim()
    {
        //selecione em quanto tempo a animacao de wanted deve vir 
        yield return new WaitForSeconds(0.3f);
       
        
        wantedScreen.SetBool("WantedMapFade", true);
        goButton.SetBool("ButtonFade", true);

    }


    public void BackMapButton()
    {
        SceneManager.LoadScene("MainMenu");

    }


    public void BackWantedButton()
    {
        //WANTED SCREEN ACTIONS
        wantedScreen.SetBool("WantedMapFade", false);
        goButton.SetBool("ButtonFade", false);

    }

}
