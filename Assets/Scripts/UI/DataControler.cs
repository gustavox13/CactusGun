using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;


public class DataControler : MonoBehaviour
{
    [SerializeField]
    private int moneyMin;
    [SerializeField]
    private int moneyMed;
    [SerializeField]
    private int moneyMax;


    [SerializeField]
    private int tntPrice;
    [SerializeField]
    private int trapPrice;
    [SerializeField]
    private int kitPrice;

    [SerializeField]
    private int tntQuant;
    [SerializeField]
    private int trapQuant;
    [SerializeField]
    private int kitQuant;

    


    [SerializeField]
    private Text moneyInfo;
    [SerializeField]
    private Text tntInfo;
    [SerializeField]
    private Text trapInfo;

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
        Cloud.Storage.Load();//Teste

        gameObject.GetComponent<SaveFunctions>().LoadInventory();
        gameObject.GetComponent<SaveFunctions>().LoadLevel();

  
      // moneyInfo.text = PlayerStats.PlayerItens.Coins.ToString();
       //tntInfo.text = PlayerStats.PlayerItens.Tnt.ToString();
        //trapInfo.text = PlayerStats.PlayerItens.Trap.ToString();


    }



    private void CheckAndUnlockLvls()
    {

        //1 - Vilarejo Fantasma
        //2 - Vale do Desespero
        //3 - Pantano dos Mortos
        //4 - Mina Abandonada
        //5 - Cidadela
        //6 - Floresta Noturna
        //7 - Montanhas do Sul
        //8 - Deserto Silencioso 


        if(PlayerStats.LvlStats.VilarejoFantasma < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            valeDoDesespero.interactable = false;

        }if(PlayerStats.LvlStats.ValeDoDesespero < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            pantanoDosMortos.interactable = false;
             
        }if(PlayerStats.LvlStats.PantanoDosMortos < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            minaAbandonada.interactable = false;

        }if(PlayerStats.LvlStats.MinaAbandonada < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            cidadela.interactable = false;

        }if(PlayerStats.LvlStats.Cidadela < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            florestaNoturna.interactable = false;

        }if(PlayerStats.LvlStats.FlorestaNoturna < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            montanhasDoSul.interactable = false;

        }if(PlayerStats.LvlStats.MontanhasDoSul < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            desertoSilencioso.interactable = false;
        }



        /*


        if (PlayerStats.LvlStats.MinaAbandonada < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            montanhasDoSul.interactable = false;
        }
       if(PlayerStats.LvlStats.MontanhasDoSul < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            cidadela.interactable = false;
        }
        if (PlayerStats.LvlStats.Cidadela < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            florestaNoturna.interactable = false;
        }
        if (PlayerStats.LvlStats.FlorestaNoturna < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            pantanoDosMortos.interactable = false;
        }
        if (PlayerStats.LvlStats.PantanoDosMortos < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            desertoSilencioso.interactable = false;
        }
        if (PlayerStats.LvlStats.DesertoSilencioso < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            vilarejoFantasma.interactable = false;
        }
        if (PlayerStats.LvlStats.VilarejoFantasma < PlayerStats.LvlStats.MaxLvlRepeat)
        {
            valeDoDesespero.interactable = false;
        }

       */
    }

    public void BuyTrap()
    {
        if (PlayerStats.PlayerItens.Coins >= trapPrice)
        {

            CloudVariables.Coins -= trapPrice;//Jean
            CloudVariables.Trap += trapQuant;//Jean

            //PlayerStats.PlayerItens.Coins -= trapPrice;
            //PlayerStats.PlayerItens.Trap += trapQuant;
            SaveInventory();
            

        }
        LoadValues();
    }

    public void BuyTNT()
    {
        if (PlayerStats.PlayerItens.Coins >= tntPrice)
        {
            CloudVariables.Coins -= tntPrice;// Jean
            CloudVariables.Tnt += tntQuant;//Jean

         //   PlayerStats.PlayerItens.Coins -= tntPrice;
          //  PlayerStats.PlayerItens.Tnt += tntQuant;
            SaveInventory();
        }
        LoadValues();
    }

    public void BuyKit()
    {
        if (PlayerStats.PlayerItens.Coins >= kitPrice)
        {

            CloudVariables.Coins -= kitPrice;//Jean
            CloudVariables.Trap += kitQuant;//Jean
            CloudVariables.Tnt += kitQuant;//Jean

          //  PlayerStats.PlayerItens.Coins -= kitPrice; 
          //  PlayerStats.PlayerItens.Trap += kitQuant;
          //  PlayerStats.PlayerItens.Tnt += kitQuant;

            SaveInventory();
        }
        LoadValues();
    }

    public void BuyMoneyMin()
    {
      //  PlayerStats.PlayerItens.Coins += moneyMin;
        CloudVariables.Coins += moneyMin; //Jean
        SaveInventory();
        LoadValues();
        
    }

    public void BuyMoneyMed()
    {
        // PlayerStats.PlayerItens.Coins += moneyMed;
        CloudVariables.Coins += moneyMed; //Jean
        
        SaveInventory();
        LoadValues();
    }

    public void BuyMoneyMax()
    {
        //PlayerStats.PlayerItens.Coins += moneyMax;
        CloudVariables.Coins = moneyMax; //Jean

        SaveInventory();
        LoadValues();
    }

    public void BuyRemoveADS()
    {
        CloudVariables.Ads = 1;

        SaveInventory();
        LoadValues();
    }

    // ---------------- Salvar Inventario ----------------
    private void SaveInventory()
    {
        gameObject.GetComponent<SaveFunctions>().SaveInventory();
     
    }

}
