using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGame : MonoBehaviour
{

    //PLAYER ATRIBUTES
    private int playerLocalToJump = 1;
    public int PlayerLocalToAtk
    {
        get { return playerLocalToAtk; }
        set { playerLocalToAtk = value; }
    }
    private int playerLocalToAtk;
    private int playerSkill;
    private Animator animPlayer;

    

    //ENEMY ATRIBUTES
    private int enemyLocalToJump = 1;
    public int EnemyLocalToAtk
    {
        get { return enemyLocalToAtk; }
        set { enemyLocalToAtk = value; }
    }
    private int enemyLocalToAtk;

    private GameObject player;
    private GameObject enemy;
    private Animator animEnemy;


    private bool runEndTurn;
    public float myTime;
    public float tempoTiro;
    

    private bool enemyIsArrested;

    //Weapons Animations
    [SerializeField]
    private GameObject[] animWeapons;
    [SerializeField]
    private GameObject Explosion;

    [SerializeField]
    private Transform[] plataforms = new Transform[3];



    private void Start()
    {
        // PlayServices.UnlockAnchivement(CactusGunServices.achievement_novo_aventureiro);
        
        LoadResources();
    }

    private void LoadResources()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
  
        animPlayer = player.GetComponentInChildren<Animator>(); 
        animEnemy = enemy.GetComponentInChildren<Animator>();

        getTimeAnimationClip();
    }

    public void Action()
    {
        GetAllConfig();
        //MOVIMENTACAO DO PLAYER AQUI     IMPORTANTE ---------------> O TEMPO DA ANIMACAO DE MOVIMENTO ESTA ADAPTADO PARA 2 SEGUNDO CASO QUEIRA AUMENTAR OU DIMINUIR ALTERAR NO IENUMERATOR
        StartCoroutine("ShotStepIn");
    }

    IEnumerator ShotStepIn()
    {
        animPlayer.SetBool("Desviando", true);
        animEnemy.SetBool("Desviando", true);
        //Pegar tempo animação Desviando
        Animator myAnimator = animPlayer;

        
        yield return new WaitForSeconds(myTime); // <--------- TEMPO DA ANIMACAO DE MOVIMENTO 0.8

        animPlayer.SetBool("Desviando", false);
        animEnemy.SetBool("Desviando", false);


       // StartCoroutine(TempoTiro());
        Shot();
    }


    private void Update()
    {
            MoveCharacters();
    }

    private void GetAllConfig()
    {
        
        playerLocalToJump = gameObject.GetComponent<PlayerActions>().PlayerPosition;
        playerLocalToAtk = gameObject.GetComponent<PlayerActions>().PlayerAtk;
        playerSkill = gameObject.GetComponent<TamborRotate>().CurrentAtk;
        enemyLocalToAtk = gameObject.GetComponent<AIEnemy>().SetLocalToAtk();

        if (!enemyIsArrested)
        {
            enemyLocalToJump = gameObject.GetComponent<AIEnemy>().SetLocalToJump();
        }
       
    }

    private void MoveCharacters()
    {
        MovePlayer(player.transform.position.y, player.transform.position.z);
        MoveEnemy(enemy.transform.position.y, enemy.transform.position.z);    
    }

    private void MoveEnemy(float y, float z)
    {
        Vector3 newPosition = new Vector3(0, y, z);

        if (enemyLocalToJump == 0)
        {
            newPosition = new Vector3(-1, y, z);
        }
        else if (enemyLocalToJump == 1)
        {
            newPosition = new Vector3(0, y, z);
        }
        else if (enemyLocalToJump == 2)
        {
            newPosition = new Vector3(1, y, z);
        }

        enemy.transform.position = Vector3.Lerp(enemy.transform.position, newPosition, Time.deltaTime * 4);
    }

    private void MovePlayer(float y, float z)
    {
        Vector3 newPosition = new Vector3(0, y, z);

        if (playerLocalToJump == 0)
        {
             newPosition = new Vector3(-1, y, z);
        } else if (playerLocalToJump == 1)
        {
             newPosition = new Vector3(0, y, z);
        }
        else if (playerLocalToJump == 2)
        {
             newPosition = new Vector3(1, y, z);
        } 

        player.transform.position = Vector3.Lerp(player.transform.position, newPosition, Time.deltaTime * 4); 

    }

    private void Shot()
    {
        enemyIsArrested = false;

        StartCoroutine(TempoTiroInimigo());

        if (enemyLocalToAtk == playerLocalToJump)
        {
           // StartCoroutine(TempoTiroInimigo());
           // player.GetComponent<Health>().TakeDamange(25);
           
          
        }

             if (playerSkill == 0)
             {
                //ANIMACAO DA BOMBA STARTA AQUI
                StartCoroutine(TempoTNT());
            // enemy.GetComponent<Health>().TakeDamange(50);
          
             }
             if (playerSkill == 1)
             {
        
                //ANIMACAO DO ATK BASICO STARTA AQUI
                StartCoroutine(TempoTiro());
               //  enemy.GetComponent<Health>().TakeDamange(25);
                // animEnemy.SetBool("Dano", true);
                // StartCoroutine(Timer());
               

            }
             if (playerSkill == 2)
             {
            //ANIMACAO DA ARMADILHA STARTA  AQUI
                    StartCoroutine(TempoTrap());
                 //enemy.GetComponent<Health>().TakeDamange(10);
              //  enemyIsArrested = true;
             }
        
    }

    IEnumerator Timer(float tempo)
    {

        yield return new WaitForSeconds(tempo);
        
        animEnemy.SetBool("Dano", false);
        animPlayer.SetBool("Dano", false);

    }

    //DANO ATK BASICO PLAYER
    IEnumerator TempoTiro()
    {

        //
         StartCoroutine(Timer(1f));
        
        yield return new WaitForSeconds(0.5f); //TempoTiro 0.5f
        //enemy.GetComponent<Bullet>().Atirar();
        player.GetComponent<Bullet>().Atirar();
        if (playerLocalToAtk == enemyLocalToJump)
        {
            enemy.GetComponent<Health>().TakeDamange(player.GetComponent<PlayerAtkStats>().BasicAtk);
            animEnemy.SetBool("Dano", true);
        }
       
    }

    //DANO ATK BASICO INIMIGO
    IEnumerator TempoTiroInimigo()
    {
        StartCoroutine(Timer(1f));

        
        yield return new WaitForSeconds(0.5f); //0.5
       // enemyIsArrested = true;
        enemy.GetComponent<Bullet>().Atirar();
        if (enemyLocalToAtk == playerLocalToJump)
        {
            animPlayer.SetBool("Dano", true);
            player.GetComponent<Health>().TakeDamange(enemy.GetComponent<EnemyAtkDamange>().BasicAtk);
        }

    }

    //DANO TNT
    IEnumerator TempoTNT()
    {
        //tempo da animação da BOMBA
        StartCoroutine(Timer(2.5f));
        GameObject cloneTNT = Instantiate(animWeapons[0], new Vector3(0,0,0), transform.rotation);
        cloneTNT.transform.localPosition = new Vector3(plataforms[PlayerLocalToAtk].transform.position.x, 7.02f, 3.11f);
        cloneTNT.transform.Rotate(new Vector3(180f, 36.066f, -1.52f));
        yield return new WaitForSeconds(2f);
         Instantiate(Explosion, new Vector3(plataforms[PlayerLocalToAtk].transform.position.x, 1.0f, 1.7f), Quaternion.identity); //falta destruir
        if (playerLocalToAtk == enemyLocalToJump)
        {
            animEnemy.SetBool("Dano", true);
            enemy.GetComponent<Health>().TakeDamange(player.GetComponent<PlayerAtkStats>().TNTAtk);
        }
        Destroy(cloneTNT);
    }


    //DANO TRAP
    IEnumerator TempoTrap()
    {

        //Pegar tempo armadilha
        StartCoroutine(Timer(1.6f));
        GameObject cloneTrap = Instantiate(animWeapons[1], new Vector3(0, 0, 0), transform.rotation);
        cloneTrap.transform.position = new Vector3(plataforms[PlayerLocalToAtk].transform.position.x, plataforms[PlayerLocalToAtk].transform.position.y, plataforms[PlayerLocalToAtk].transform.position.z);
        cloneTrap.transform.Rotate(new Vector3(0, 41.22f, 0));
        yield return new WaitForSeconds(1f);

        if (playerLocalToAtk == enemyLocalToJump)
        {
            animEnemy.SetBool("Dano", true);
            enemy.GetComponent<Health>().TakeDamange(player.GetComponent<PlayerAtkStats>().TrapAtk);
            enemyIsArrested = true;
            Destroy(cloneTrap);
        }
        else
            Destroy(cloneTrap);


    }

    void getTimeAnimationClip()
    {

       

        RuntimeAnimatorController ac = animPlayer.runtimeAnimatorController;

        for(int i = 0; i < ac.animationClips.Length;i++)
        {

            if(ac.animationClips[i].name == "Jump (1)")
            {

                myTime = ac.animationClips[i].length;
            }
        }

    }

    

   

}


/*
    private void Shot2()
    {
        enemyIsArrested = false;

        if (enemyLocalToAtk == playerLocalToJump)
        {
            player.GetComponent<Health>().TakeDamange(25);


        }

        if (PlayerLocalToAtk == enemyLocalToJump)
        {

            if (playerSkill == 0)
            {
                //ANIMACAO DA BOMBA STARTA AQUI
                StartCoroutine(TempoTNT());
                // enemy.GetComponent<Health>().TakeDamange(50);
            }
            if (playerSkill == 1)
            {
                //ANIMACAO DO ATK BASICO STARTA AQUI
                StartCoroutine(TempoTiro());
                //  enemy.GetComponent<Health>().TakeDamange(25);
                // animEnemy.SetBool("Dano", true);
                // StartCoroutine(Timer());


            }
            if (playerSkill == 2)
            {
                //ANIMACAO DA ARMADILHA STARTA  AQUI
                enemy.GetComponent<Health>().TakeDamange(10);
                enemyIsArrested = true;
            }
        }
    }*/





