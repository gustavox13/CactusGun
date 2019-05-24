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
     minaAbandonada.text = PlayerStats.LvlStats.MinaAbandonada + "/10";
     montanhasDoSul.text = PlayerStats.LvlStats.MontanhasDoSul + "/10";
     cidadela.text = PlayerStats.LvlStats.Cidadela + "/10";
     florestaNoturna.text = PlayerStats.LvlStats.FlorestaNoturna + "/10";
     pantanoDosMortos.text = PlayerStats.LvlStats.PantanoDosMortos + "/10";
     desertoSilencioso.text = PlayerStats.LvlStats.DesertoSilencioso + "/10";
     vilarejoFantasma.text = PlayerStats.LvlStats.VilarejoFantasma + "/10";
     valeDoDesespero.text = PlayerStats.LvlStats.ValeDoDesespero + "/10";


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
        switch (nameScene)
        {
            case "cidadela":
                if (PlayerStats.LvlStats.Cidadela < 10)
                {
                    Cacto.SetActive(true);
                }
                else
                {
                    Urubu.SetActive(true);
                }
                break;

            case "deserto silencioso":
                if (PlayerStats.LvlStats.DesertoSilencioso < 10)
                {
                    EsqueletoNvl2.SetActive(true);
                }
                else
                {
                    Escorpiao.SetActive(true);
                }
                break;


            case "floresta noturna":
                if (PlayerStats.LvlStats.FlorestaNoturna < 10)
                {
                    EsqueletoNvl1.SetActive(true);
                }
                else
                {
                    ManyMorcego.SetActive(true);
                }
                break;

            case "mina abandonada":
                if(PlayerStats.LvlStats.MinaAbandonada < 10)
                {
                    Espantalho.SetActive(true);
                }
                else
                {
                    Coiote.SetActive(true);
                }
                break;

            case "montanhas do sul":
                if (PlayerStats.LvlStats.MontanhasDoSul < 10)
                {
                    EsqueletoNvl2.SetActive(true);
                }
                else
                {
                    PorcoEspinho.SetActive(true);
                }
                break;

            case "pantano dos mortos":
                if (PlayerStats.LvlStats.PantanoDosMortos < 10)
                {
                    Espantalho.SetActive(true);
                }
                else
                {
                    Zilda.SetActive(true);
                }
                break;

            case "vale do desespero":
                if (PlayerStats.LvlStats.ValeDoDesespero < 10)
                {
                    EsqueletoNvl1.SetActive(true);
                }
                else
                {
                    BicoDeAco.SetActive(true);
                }
                break;

            case "vilarejo fantasma":
                if (PlayerStats.LvlStats.VilarejoFantasma < 10)
                {
                    Cacto.SetActive(true);
                }
                else
                {
                    Coiote.SetActive(true);
                }
                break;

        }

    }

    public void GoPress()
    {
        SceneManager.LoadScene(nameScene);
    }

}
