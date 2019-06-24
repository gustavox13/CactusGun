using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        
        LoadValues();

        CheckAndUnlockLvls();

        
    }

    //--------------------- Resgata valores salvos ------------------------
    private void LoadValues()
    {
        
       

        //Get inventory
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.TNT))
        {

            PlayerStats.PlayerItens.Tnt = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.TNT);
        }
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.COINS))
        {

            PlayerStats.PlayerItens.Coins = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.COINS);
        }
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.TRAP))
        {

            PlayerStats.PlayerItens.Trap = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.TRAP);
        }

        //get lvl
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.CIDADELA))
        {

            PlayerStats.LvlStats.Cidadela = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.CIDADELA);
        }
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.DESERTO_SILENCIOSO))
        {

            PlayerStats.LvlStats.DesertoSilencioso = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.DESERTO_SILENCIOSO);
        }
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.FLORESTA_NOTURNA))
        {

            PlayerStats.LvlStats.FlorestaNoturna = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.FLORESTA_NOTURNA);
        }
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.MINA_ABANDONADA))
        {

            PlayerStats.LvlStats.MinaAbandonada = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.MINA_ABANDONADA);
        }
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.MONTANHAS_DO_SUL))
        {

            PlayerStats.LvlStats.MontanhasDoSul = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.MONTANHAS_DO_SUL);
        }
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.PANTANO_DOS_MORTOS))
        {

            PlayerStats.LvlStats.PantanoDosMortos = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.PANTANO_DOS_MORTOS);
        }
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.VALE_DO_DESESPERO))
        {

            PlayerStats.LvlStats.ValeDoDesespero = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.VALE_DO_DESESPERO);
        }
        if (PlayerPrefs.HasKey(PlayerStats.DataBaseInfo.VILAREJO_FANTASMA))
        {

            PlayerStats.LvlStats.VilarejoFantasma = PlayerPrefs.GetInt(PlayerStats.DataBaseInfo.VILAREJO_FANTASMA);
        }


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

    // ---------------- SALVAR INVENTARIO ----------------
    private void SaveInventory()
    {
        //inventory
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.TNT, PlayerStats.PlayerItens.Tnt);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.TRAP, PlayerStats.PlayerItens.Trap);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.COINS, PlayerStats.PlayerItens.Coins);
    }

}
