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
    private bool fimPardida;
    private bool somVitoria;

    [SerializeField]
    private GameObject ac;

    [SerializeField]
    private Variables variables;
 



    

    private void Awake ()
    {

        variables.LoadSave();
        fimPardida = false;
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
     
       
            if (player.GetComponent<Health>().CurrentHealth <= 0 && enemy.GetComponent<Health>().CurrentHealth > 0 && !fimPardida)
            {
            StartCoroutine("DeathEnemyOrPlayer", false);
             
            }

            if (enemy.GetComponent<Health>().CurrentHealth <= 0 && player.GetComponent<Health>().CurrentHealth > 0 && !fimPardida)
            {
              StartCoroutine("DeathEnemyOrPlayer", true);
           
            }

            if (player.GetComponent<Health>().CurrentHealth <= 0 && enemy.GetComponent<Health>().CurrentHealth <= 0 && !fimPardida)
            {
             StartCoroutine("DeathEnemyOrPlayer", false);
            
            }
        
    }

    IEnumerator DeathEnemyOrPlayer(bool value)
    {
        if(value == true && !fimPardida)
        {
            if(!somVitoria)
            source.PlayOneShot(audios[3]);
            {
                somVitoria = true;
            }
            player.GetComponentInChildren<Animator>().SetBool("Vitoria", true);

        }
        else if(!fimPardida)
            enemy.GetComponentInChildren<Animator>().SetBool("Vitoria", true);

        yield return new WaitForSeconds(5.0f);  //4

        if(value == true && !fimPardida)
        {
           
            Victory();
            fimPardida = true;
        } else if(!fimPardida)
        {
           
            fimPardida = true;
            Defeat();
        }

    }


    private void Victory()
    {
        fimPardida = true;
        Hud.SetActive(false);
        winScreen.SetActive(true);
        source.PlayOneShot(audios[1]);
       // if(!fimPardida)
       
        PlayerRank();
       //variables.AddLevel(); //Venceu, acrescentar +1 no level atual, depois limitar até 10/10
       //variables.SaveVariables(); //Salva


        //VErifica o inimigo para dar recompensa em dinheiro

       // GetComponent<LevelUp>().AddDinheiro(50f);
      //  Debug.Log(GetComponent<LevelUp>().GetDinheiro());
      //  GetComponent<LevelUp>().AddExp(10);
        
    }

    private void Defeat()
    {
        source.PlayOneShot(audios[2]);
        Hud.SetActive(false);
        defeatScreen.SetActive(true);
        
    }


    private void PlayerRank()
    {
        if (player.GetComponent<Health>().CurrentHealth == 100) //Ouro
        {
            moneyG.SetActive(true);
            emblemG.SetActive(true);
            // GetComponent<LevelUp>().AddMedalha(0);
            //ac.GetComponent<AcountController>().SetScore(20);
            variables.AddGolden(20);
            variables.AddLevel(1);
            variables.SaveVariables();
            
            

            //  float score = ac.GetComponent<AcountController>().GetScore();
            //  Debug.Log("Score: " + score);

            //  if (score > PlayServices.GetPlayerScore(CactusGunServices.leaderboard_ranking))
            //  {
            //  PlayServices.PostScore((long)score, CactusGunServices.leaderboard_ranking);
            //  }


        } else if (player.GetComponent<Health>().CurrentHealth < 100 && player.GetComponent<Health>().CurrentHealth > 74) //Prata
        {
            moneyP.SetActive(true);
            emblemP.SetActive(true);
           // GetComponent<LevelUp>().AddMedalha(1);

            //ac.GetComponent<AcountController>().SetScore(10);
            variables.AddGolden(10);
            variables.AddLevel(1);
            variables.SaveVariables();
            
            

            // float score = ac.GetComponent<AcountController>().GetScore();
            // Debug.Log("Score: " + score);
            //  if (score > PlayServices.GetPlayerScore(CactusGunServices.leaderboard_ranking))
            //  {
            // PlayServices.PostScore((long)score, CactusGunServices.leaderboard_ranking);
            //  }

        }
        else if (player.GetComponent<Health>().CurrentHealth < 75 && player.GetComponent<Health>().CurrentHealth > 0) //Bronze
        {
            moneyB.SetActive(true);
            emblemB.SetActive(true);
           // GetComponent<LevelUp>().AddMedalha(2);
            // ac.GetComponent<AcountController>().SetScore(5);
            variables.AddGolden(5);
            variables.AddLevel(1);
            variables.SaveVariables();
            

            //float score = ac.GetComponent<AcountController>().GetScore();
            //Debug.Log("Score: " + score);
            // if (score > PlayServices.GetPlayerScore(CactusGunServices.leaderboard_ranking))
            // {
            // PlayServices.PostScore((long)score, CactusGunServices.leaderboard_ranking);
            // }

        }

    }

  
   

}
