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
        //Cloud.Storage.Load();//Teste

        gameObject.GetComponent<SaveFunctions>().LoadInventory();
        gameObject.GetComponent<SaveFunctions>().LoadLevel();


        

        moneyInfo.text = PlayerStats.PlayerItens.Coins.ToString();
        tntInfo.text = PlayerStats.PlayerItens.Tnt.ToString();
        trapInfo.text = PlayerStats.PlayerItens.Trap.ToString();


    }




    private void CheckAndUnlockLvls()
    {
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
    }

    public void BuyTrap()
    {
        if (PlayerStats.PlayerItens.Coins >= trapPrice)
        {
            PlayerStats.PlayerItens.Coins -= trapPrice;
            PlayerStats.PlayerItens.Trap += trapQuant;
            SaveInventory();
            

        }
        LoadValues();
    }

    public void BuyTNT()
    {
        if (PlayerStats.PlayerItens.Coins >= tntPrice)
        {
            PlayerStats.PlayerItens.Coins -= tntPrice;
            PlayerStats.PlayerItens.Tnt += tntQuant;
            SaveInventory();
        }
        LoadValues();
    }

    public void BuyKit()
    {
        if (PlayerStats.PlayerItens.Coins >= kitPrice)
        {
            PlayerStats.PlayerItens.Coins -= kitPrice;
            
            PlayerStats.PlayerItens.Trap += kitQuant;
            PlayerStats.PlayerItens.Tnt += kitQuant;
            SaveInventory();
        }
        LoadValues();
    }

    public void BuyMoneyMin()
    {
        PlayerStats.PlayerItens.Coins += moneyMin;
       
        SaveInventory();
        LoadValues();
        
    }

    public void BuyMoneyMed()
    {
        PlayerStats.PlayerItens.Coins += moneyMed;
        
        SaveInventory();
        LoadValues();
    }

    public void BuyMoneyMax()
    {
        PlayerStats.PlayerItens.Coins += moneyMax;
        
        SaveInventory();
        LoadValues();
    }

    // ---------------- Salvar Inventario ----------------
    private void SaveInventory()
    {
        gameObject.GetComponent<SaveFunctions>().SaveInventory();
     
    }

}
