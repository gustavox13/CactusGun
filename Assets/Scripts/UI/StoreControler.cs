using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;
using UnityEngine.SceneManagement;

public class StoreControler : MonoBehaviour
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


    private void Awake()
    {
        LoadValues();
    }

    //--------------------- Resgatar valores salvos ------------------------
    private void LoadValues()
    {
        Cloud.Storage.Load();//Teste

        gameObject.GetComponent<SaveFunctions>().LoadInventory();

        moneyInfo.text = PlayerStats.PlayerItens.Coins.ToString();
        tntInfo.text = PlayerStats.PlayerItens.Tnt.ToString();
        trapInfo.text = PlayerStats.PlayerItens.Trap.ToString();

    }

    //COMPRA TRAP
    public void BuyTrap()
    {
        if (PlayerStats.PlayerItens.Coins >= trapPrice)
        {

            CloudVariables.Coins -= trapPrice;
            CloudVariables.Trap += trapQuant;

            //PlayerStats.PlayerItens.Coins -= trapPrice;
            //PlayerStats.PlayerItens.Trap += trapQuant;
            SaveInventory();

        }
        LoadValues();
    }

    //COMPRA TNT
    public void BuyTNT()
    {
        if (PlayerStats.PlayerItens.Coins >= tntPrice)
        {
            CloudVariables.Coins -= tntPrice;
            CloudVariables.Tnt += tntQuant;

            //   PlayerStats.PlayerItens.Coins -= tntPrice;
            //  PlayerStats.PlayerItens.Tnt += tntQuant;
            SaveInventory();
        }
        LoadValues();
    }

    //COMPRA KIT
    public void BuyKit()
    {
        if (PlayerStats.PlayerItens.Coins >= kitPrice)
        {

            CloudVariables.Coins -= kitPrice;
            CloudVariables.Trap += kitQuant;
            CloudVariables.Tnt += kitQuant;

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
        CloudVariables.Coins += moneyMin; 
        SaveInventory();
        LoadValues();

    }

    public void BuyMoneyMed()
    {
        // PlayerStats.PlayerItens.Coins += moneyMed;
        CloudVariables.Coins += moneyMed; 

        SaveInventory();
        LoadValues();
    }

    public void BuyMoneyMax()
    {
        //PlayerStats.PlayerItens.Coins += moneyMax;
        CloudVariables.Coins = moneyMax; 

        SaveInventory();
        LoadValues();
    }

    public void BuyRemoveADS()
    {
        CloudVariables.Ads = 1;

        SaveInventory();
        LoadValues();
    }


    public void ExitStore()
    {
        SceneManager.LoadScene("MainMenu");
    }


    // ---------------- Salvar Inventario ----------------
    private void SaveInventory()
    {
        gameObject.GetComponent<SaveFunctions>().SaveInventory();

    }
}
