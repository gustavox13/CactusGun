using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControler : MonoBehaviour
{

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


    
    private AudioSource source;
    [SerializeField]
    private AudioClip[] audios = new AudioClip[3];
   // private bool fimPardida;
    private bool somVitoria;
    

    private void Awake ()
    {
        //fimPardida = false;
        somVitoria = false;
        source = GetComponent<AudioSource>();
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
            if (player.GetComponent<Health>().CurrentHealth <= 0 && enemy.GetComponent<Health>().CurrentHealth > 0 /*&& !fimPardida*/)
            {
            StartCoroutine("DeathEnemyOrPlayer", false);
             
            }
            //vitoria
            if (enemy.GetComponent<Health>().CurrentHealth <= 0 && player.GetComponent<Health>().CurrentHealth > 0 /*&& !fimPardida*/)
        {
              StartCoroutine("DeathEnemyOrPlayer", true);
           
            }
            //derrota empate
            if (player.GetComponent<Health>().CurrentHealth <= 0 && enemy.GetComponent<Health>().CurrentHealth <= 0 /*&& !fimPardida*/)
        {
             StartCoroutine("DeathEnemyOrPlayer", false);
            
            }
        
    }

    IEnumerator DeathEnemyOrPlayer(bool value)
    {
        if(value == true /*&& !fimPardida*/)
        {
            if(!somVitoria)
            source.PlayOneShot(audios[3]);
            {
                somVitoria = true;
            }
            player.GetComponentInChildren<Animator>().SetBool("Vitoria", true);

        }
        else /*if(!fimPardida)*/
            enemy.GetComponentInChildren<Animator>().SetBool("Vitoria", true);

        yield return new WaitForSeconds(5.0f);  //4

        if(value == true /*&& !fimPardida*/)
        {
           
            Victory();
          //  fimPardida = true;
        } else /*if(!fimPardida)*/
        {
           
          //  fimPardida = true;
            Defeat();
        }

    }


    private void Victory()
    {
       // fimPardida = true;
        Hud.SetActive(false);
        winScreen.SetActive(true);
        source.PlayOneShot(audios[1]);

       
        PlayerRank();

       // GetComponent<LevelUp>().AddDinheiro(50f);
       // GetComponent<LevelUp>().AddExp(10);
        
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


            // GetComponent<LevelUp>().AddMedalha(0);
            // ac.GetComponent<AcountController>().SetScore(20);
            //  float score = ac.GetComponent<AcountController>().GetScore();
            //  if (score > PlayServices.GetPlayerScore(CactusGunServices.leaderboard_ranking))
            //  {
            //  PlayServices.PostScore((long)score, CactusGunServices.leaderboard_ranking);
            //  }


        } else if (player.GetComponent<Health>().CurrentHealth < 99 && player.GetComponent<Health>().CurrentHealth >= 50) //PRATA TIER
        {
            moneyP.SetActive(true);
            emblemP.SetActive(true);
         
            // GetComponent<LevelUp>().AddMedalha(1);
            // ac.GetComponent<AcountController>().SetScore(10);
            // float score = ac.GetComponent<AcountController>().GetScore();
            //  if (score > PlayServices.GetPlayerScore(CactusGunServices.leaderboard_ranking))
            //  {
            // PlayServices.PostScore((long)score, CactusGunServices.leaderboard_ranking);
            //  }

        }
        else if (player.GetComponent<Health>().CurrentHealth < 50 && player.GetComponent<Health>().CurrentHealth > 0) //BRONZE TIER
        {
            moneyB.SetActive(true);
            emblemB.SetActive(true);


            // GetComponent<LevelUp>().AddMedalha(2);
            // ac.GetComponent<AcountController>().SetScore(5);
            // float score = ac.GetComponent<AcountController>().GetScore();
            // if (score > PlayServices.GetPlayerScore(CactusGunServices.leaderboard_ranking))
            // {
            // PlayServices.PostScore((long)score, CactusGunServices.leaderboard_ranking);
            // }

        }

    }

  
   

}
