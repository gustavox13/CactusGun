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

    

    private void Awake ()
    {
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
       
            if (player.GetComponent<Health>().CurrentHealth <= 0 && enemy.GetComponent<Health>().CurrentHealth > 0)
            {
            StartCoroutine("DeathEnemyOrPlayer", false);
             
            }

            if (enemy.GetComponent<Health>().CurrentHealth <= 0 && player.GetComponent<Health>().CurrentHealth > 0)
            {
              StartCoroutine("DeathEnemyOrPlayer", true);
           
            }

            if (player.GetComponent<Health>().CurrentHealth <= 0 && enemy.GetComponent<Health>().CurrentHealth <= 0)
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
        Hud.SetActive(false);
        winScreen.SetActive(true);
        source.PlayOneShot(audios[1]);
        PlayerRank();

        //VErifica o inimigo para dar recompensa em dinheiro

        GetComponent<LevelUp>().AddDinheiro(50f);
        Debug.Log(GetComponent<LevelUp>().GetDinheiro());
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
            GetComponent<LevelUp>().AddMedalha(0);

        } else if (player.GetComponent<Health>().CurrentHealth < 100 && player.GetComponent<Health>().CurrentHealth > 74) //Prata
        {
            moneyP.SetActive(true);
            emblemP.SetActive(true);
            GetComponent<LevelUp>().AddMedalha(1);

        }
        else if (player.GetComponent<Health>().CurrentHealth < 75 && player.GetComponent<Health>().CurrentHealth > 0) //Bronze
        {
            moneyB.SetActive(true);
            emblemB.SetActive(true);
            GetComponent<LevelUp>().AddMedalha(2);

        }

    }

  
   

}
