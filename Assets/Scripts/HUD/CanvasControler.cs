using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControler : MonoBehaviour
{
    [SerializeField]
    private int moneyGold;
    [SerializeField]
    private int moneySilver;
    [SerializeField]
    private int moneyBronze;



    [SerializeField]
    private Text goldText;
    [SerializeField]
    private Text silverText;
    [SerializeField]
    private Text bronzeText;


    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject defeatScreen;
    [SerializeField]
    private GameObject Hud;
    private GameObject player;
    private GameObject enemy;

    [SerializeField]
    private GameObject moneyB;
    [SerializeField]
    private GameObject moneyP;
    [SerializeField]
    private GameObject moneyG;

    [SerializeField]
    private GameObject emblemB;
    [SerializeField]
    private GameObject emblemP;
    [SerializeField]
    private GameObject emblemG;

    private bool addVictoryPoint;
    
    private AudioSource source;
    [SerializeField]
    private AudioClip[] audios = new AudioClip[3];
  
    private bool somVitoria;

    private bool endLvl = false;

    private void Awake ()
    {
        addVictoryPoint = false;
        
        somVitoria = false;
        source = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        moneyB.SetActive(false);
        moneyP.SetActive(false);
        moneyG.SetActive(false);

        emblemB.SetActive(false);
        emblemP.SetActive(false);
        emblemG.SetActive(false);

        winScreen.SetActive(false);
        defeatScreen.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

    }


    private void Update()
    {
     
            //derrota
            if (player.GetComponent<Health>().CurrentHealth <= 0 && enemy.GetComponent<Health>().CurrentHealth > 0 )
            {
            StartCoroutine("DeathEnemyOrPlayer", false);
             
            }
            //vitoria
            if (enemy.GetComponent<Health>().CurrentHealth <= 0 && player.GetComponent<Health>().CurrentHealth > 0 )
        {
              StartCoroutine("DeathEnemyOrPlayer", true);
           
            }
            //derrota empate
            if (player.GetComponent<Health>().CurrentHealth <= 0 && enemy.GetComponent<Health>().CurrentHealth <= 0)
        {
             StartCoroutine("DeathEnemyOrPlayer", false);
            
            }
        
    }

    IEnumerator DeathEnemyOrPlayer(bool value)
    {
        if(value == true )
        {
            if(!somVitoria)
            source.PlayOneShot(audios[3]);
            {
                somVitoria = true;
            }
            player.GetComponentInChildren<Animator>().SetBool("Vitoria", true);

        }
        else 
            enemy.GetComponentInChildren<Animator>().SetBool("Vitoria", true);

        yield return new WaitForSeconds(5.0f);  

        if(value == true )
        {
           
            Victory();
         
        } else 
        {
           
          
            Defeat();
        }

    }


    private void Victory()
    {
       
        Hud.SetActive(false);
        winScreen.SetActive(true);
        source.PlayOneShot(audios[1]);

        PlayerRank();
        if (addVictoryPoint == false)
        {
            SetLvlSave();
        }

        
        Debug.Log(PlayerStats.PlayerItens.Coins);
     
        
    }

    private void Defeat()
    {
        source.PlayOneShot(audios[2]);
        Hud.SetActive(false);
        defeatScreen.SetActive(true);
        
    }


    private void PlayerRank()
    {
        if (player.GetComponent<Health>().CurrentHealth == 100) //GOLD TIER
        {
            moneyG.SetActive(true);
            emblemG.SetActive(true);

            if (endLvl == false)
            {
                if (PlayerStats.LvlStats.TimeToBoss == true)
                {
                    PlayerStats.PlayerItens.Coins += (moneyGold * 2);
                    goldText.text = (moneyGold * 2).ToString();
                }
                else
                {
                    PlayerStats.PlayerItens.Coins += moneyGold;
                    goldText.text = moneyGold.ToString();
                }
                endLvl = true;
            }
            


        } else if (player.GetComponent<Health>().CurrentHealth < 99 && player.GetComponent<Health>().CurrentHealth >= 50) //PRATA TIER
        {
            moneyP.SetActive(true);
            emblemP.SetActive(true);

            if (endLvl == false)
            {
                if (PlayerStats.LvlStats.TimeToBoss == true)
            {
                PlayerStats.PlayerItens.Coins += (moneySilver * 2);
                silverText.text = (moneySilver * 2).ToString();
            }
            else
            {
                PlayerStats.PlayerItens.Coins += moneySilver;
                silverText.text = moneySilver.ToString();
            }
                endLvl = true;
            }
            

        }
        else if (player.GetComponent<Health>().CurrentHealth < 50 && player.GetComponent<Health>().CurrentHealth > 0) //BRONZE TIER
        {
            moneyB.SetActive(true);
            emblemB.SetActive(true);

            if (endLvl == false)
            {
                if (PlayerStats.LvlStats.TimeToBoss == true)
            {
                PlayerStats.PlayerItens.Coins += (moneyBronze * 2);
                bronzeText.text = (moneyBronze * 2).ToString();
            }
            else
            {
                PlayerStats.PlayerItens.Coins += moneyBronze;
                bronzeText.text = moneyBronze.ToString();
            }
                endLvl = true;
            }
           

        }
    }

  

    private void SetLvlSave()
    {

        switch (PlayerStats.LvlStats.CurrentMap)
        {
            case "cidadela":
                if (PlayerStats.LvlStats.Cidadela < PlayerStats.LvlStats.MaxLvlRepeat)
                {
                    PlayerStats.LvlStats.Cidadela += 1;
                }

                break;

            case "deserto silencioso":
                if (PlayerStats.LvlStats.DesertoSilencioso < PlayerStats.LvlStats.MaxLvlRepeat)
                {
                    PlayerStats.LvlStats.DesertoSilencioso += 1;
                }

                break;


            case "floresta noturna":
                if (PlayerStats.LvlStats.FlorestaNoturna < PlayerStats.LvlStats.MaxLvlRepeat)
                {
                    PlayerStats.LvlStats.FlorestaNoturna += 1;
                }

                break;

            case "mina abandonada":
                if (PlayerStats.LvlStats.MinaAbandonada < PlayerStats.LvlStats.MaxLvlRepeat)
                {
                    PlayerStats.LvlStats.MinaAbandonada += 1;
                }

                break;

            case "montanhas do sul":
                if (PlayerStats.LvlStats.MontanhasDoSul < PlayerStats.LvlStats.MaxLvlRepeat)
                {
                    PlayerStats.LvlStats.MontanhasDoSul += 1;
                }

                break;

            case "pantano dos mortos":
                if (PlayerStats.LvlStats.PantanoDosMortos < PlayerStats.LvlStats.MaxLvlRepeat)
                {
                    PlayerStats.LvlStats.PantanoDosMortos += 1;
                }

                break;

            case "vale do desespero":
                if (PlayerStats.LvlStats.ValeDoDesespero < PlayerStats.LvlStats.MaxLvlRepeat)
                {
                    PlayerStats.LvlStats.ValeDoDesespero += 1;
                }

                break;

            case "vilarejo fantasma":
                if (PlayerStats.LvlStats.VilarejoFantasma < PlayerStats.LvlStats.MaxLvlRepeat)
                {
                    PlayerStats.LvlStats.VilarejoFantasma += 1;
                }
                break;

        }

        SaveLevel();

        addVictoryPoint = true;

    }

    //---------------- Salvar fase e recompensa aqui ------------------
    private void SaveLevel()
    {
        gameObject.GetComponent<SaveFunctions>().SaveInventory();
        gameObject.GetComponent<SaveFunctions>().SaveLevel();
        /*
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.COINS, PlayerStats.PlayerItens.Coins);

        //levels
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.CIDADELA, PlayerStats.LvlStats.Cidadela);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.DESERTO_SILENCIOSO, PlayerStats.LvlStats.DesertoSilencioso);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.FLORESTA_NOTURNA, PlayerStats.LvlStats.FlorestaNoturna);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.MINA_ABANDONADA, PlayerStats.LvlStats.MinaAbandonada);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.MONTANHAS_DO_SUL, PlayerStats.LvlStats.MontanhasDoSul);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.PANTANO_DOS_MORTOS, PlayerStats.LvlStats.PantanoDosMortos);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.VALE_DO_DESESPERO, PlayerStats.LvlStats.ValeDoDesespero);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.VILAREJO_FANTASMA, PlayerStats.LvlStats.VilarejoFantasma);
        */
    }

}
