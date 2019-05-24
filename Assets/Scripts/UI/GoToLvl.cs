using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToLvl : MonoBehaviour
{
   
    private string nameScene;

    //TEXTOS INDICAÇÃO DE FASE
    [SerializeField]
    private Text minaAbandonada;
    [SerializeField]
    private Text montanhasDoSul;
    [SerializeField]
    private Text cidadela;
    [SerializeField]
    private Text florestaNoturna;
    [SerializeField]
    private Text pantanoDosMortos;
    [SerializeField]
    private Text desertoSilencioso;
    [SerializeField]
    private Text vilarejoFantasma;
    [SerializeField]
    private Text valeDoDesespero;


    //CARTAZ CHEFE
    [SerializeField]
    private GameObject Coiote;
    [SerializeField]
    private GameObject BicoDeAco;
    [SerializeField]
    private GameObject Zilda;
    [SerializeField]
    private GameObject Urubu;
    [SerializeField]
    private GameObject ManyMorcego;
    [SerializeField]
    private GameObject PorcoEspinho;
    [SerializeField]
    private GameObject Escorpiao;

    //CARTAZ CAPANGAS
    [SerializeField]
    private GameObject Cacto;
    [SerializeField]
    private GameObject Espantalho;
    [SerializeField]
    private GameObject EsqueletoNvl1;
    [SerializeField]
    private GameObject EsqueletoNvl2;



    public void LoadLvlStats()
    {
     minaAbandonada.text = PlayerStats.LvlStats.MinaAbandonada + "/" + (PlayerStats.LvlStats.MaxLvlRepeat).ToString();
     montanhasDoSul.text = PlayerStats.LvlStats.MontanhasDoSul + "/" + (PlayerStats.LvlStats.MaxLvlRepeat).ToString();
     cidadela.text = PlayerStats.LvlStats.Cidadela + "/" + (PlayerStats.LvlStats.MaxLvlRepeat).ToString();
     florestaNoturna.text = PlayerStats.LvlStats.FlorestaNoturna + "/" + (PlayerStats.LvlStats.MaxLvlRepeat).ToString();
     pantanoDosMortos.text = PlayerStats.LvlStats.PantanoDosMortos + "/" + (PlayerStats.LvlStats.MaxLvlRepeat).ToString();
     desertoSilencioso.text = PlayerStats.LvlStats.DesertoSilencioso + "/" + (PlayerStats.LvlStats.MaxLvlRepeat).ToString();
     vilarejoFantasma.text = PlayerStats.LvlStats.VilarejoFantasma + "/" + (PlayerStats.LvlStats.MaxLvlRepeat).ToString();
     valeDoDesespero.text = PlayerStats.LvlStats.ValeDoDesespero + "/" + (PlayerStats.LvlStats.MaxLvlRepeat).ToString();


     Coiote.SetActive(false);
     BicoDeAco.SetActive(false);
     Zilda.SetActive(false);
     Urubu.SetActive(false);
     ManyMorcego.SetActive(false);
     PorcoEspinho.SetActive(false);
     Escorpiao.SetActive(false);

     Cacto.SetActive(false);
     Espantalho.SetActive(false);
     EsqueletoNvl1.SetActive(false);
     EsqueletoNvl2.SetActive(false);
    }


    public void LevelPresses(string currentLvl)
    {
        nameScene = currentLvl;
        SetCurrentEnemy();
        PlayerStats.LvlStats.CurrentMap = nameScene;
    }

    public void GoPress()
    {
        SceneManager.LoadScene(nameScene);

    }

  

    private void SetCurrentEnemy()
    {
        switch (nameScene)
        {
            case "cidadela":
                if (PlayerStats.LvlStats.Cidadela < PlayerStats.LvlStats.MaxLvlRepeat - 1)
                {
                    PlayerStats.LvlStats.TimeToBoss = false;
                    Cacto.SetActive(true);
                }
                else
                {
                    PlayerStats.LvlStats.TimeToBoss = true;
                    Urubu.SetActive(true);
                }
                break;

            case "deserto silencioso":
                if (PlayerStats.LvlStats.DesertoSilencioso < PlayerStats.LvlStats.MaxLvlRepeat -1 )
                {
                    PlayerStats.LvlStats.TimeToBoss = false;
                    EsqueletoNvl2.SetActive(true);
                }
                else
                {
                    PlayerStats.LvlStats.TimeToBoss = true;
                    Escorpiao.SetActive(true);
                }
                break;


            case "floresta noturna":
                if (PlayerStats.LvlStats.FlorestaNoturna < PlayerStats.LvlStats.MaxLvlRepeat -1 )
                {
                    PlayerStats.LvlStats.TimeToBoss = false;
                    EsqueletoNvl1.SetActive(true);
                }
                else
                {
                    PlayerStats.LvlStats.TimeToBoss = true;
                    ManyMorcego.SetActive(true);
                }
                break;

            case "mina abandonada":
                if (PlayerStats.LvlStats.MinaAbandonada < PlayerStats.LvlStats.MaxLvlRepeat -1 )
                {
                    PlayerStats.LvlStats.TimeToBoss = false;
                    Espantalho.SetActive(true);
                }
                else
                {
                    PlayerStats.LvlStats.TimeToBoss = true;
                    Coiote.SetActive(true);
                }
                break;

            case "montanhas do sul":
                if (PlayerStats.LvlStats.MontanhasDoSul < PlayerStats.LvlStats.MaxLvlRepeat -1)
                {
                    PlayerStats.LvlStats.TimeToBoss = false;
                    EsqueletoNvl2.SetActive(true);
                }
                else
                {
                    PlayerStats.LvlStats.TimeToBoss = true;
                    PorcoEspinho.SetActive(true);
                }
                break;

            case "pantano dos mortos":
                if (PlayerStats.LvlStats.PantanoDosMortos < PlayerStats.LvlStats.MaxLvlRepeat -1)
                {
                    PlayerStats.LvlStats.TimeToBoss = false;
                    Espantalho.SetActive(true);
                }
                else
                {
                    PlayerStats.LvlStats.TimeToBoss = true;
                    Zilda.SetActive(true);
                }
                break;

            case "vale do desespero":
                if (PlayerStats.LvlStats.ValeDoDesespero < PlayerStats.LvlStats.MaxLvlRepeat -1)
                {
                    PlayerStats.LvlStats.TimeToBoss = false;
                    EsqueletoNvl1.SetActive(true);
                }
                else
                {
                    PlayerStats.LvlStats.TimeToBoss = true;
                    BicoDeAco.SetActive(true);
                }
                break;

            case "vilarejo fantasma":
                if (PlayerStats.LvlStats.VilarejoFantasma < PlayerStats.LvlStats.MaxLvlRepeat -1)
                {
                    PlayerStats.LvlStats.TimeToBoss = false;
                    Cacto.SetActive(true);
                }
                else
                {
                    PlayerStats.LvlStats.TimeToBoss = true;
                    Coiote.SetActive(true);
                }
                break;

        }
    }
}
