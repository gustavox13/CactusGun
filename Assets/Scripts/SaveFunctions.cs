using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;
using UnityEngine.UI;

public class SaveFunctions : MonoBehaviour
{

    //public Text statusDoBang;



    private void Start()
    {
      
       Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
      Cloud.OnCloudLoadComplete += CloudOnceLoadComplete;
      Cloud.Initialize(true, true);

 
    }

    void CloudOnceInitializeComplete()
    {
        Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
        Cloud.Storage.Load();



        
    }

    void CloudOnceLoadComplete(bool success)
    {
        // statusDoBang.text = success.ToString();
        LoadInventory();
        LoadLevel();
        Save();

    }

    void Save()
    {
        Cloud.Storage.Save();
    }

    public void Load()
    {
        Cloud.Storage.Load();
        
    }


    //------------------------------------ SALVAR -----------------------------
    public void SaveInventory()
    {
        /* //SAVE LOCAL
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.TNT, PlayerStats.PlayerItens.Tnt);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.TRAP, PlayerStats.PlayerItens.Trap);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.COINS, PlayerStats.PlayerItens.Coins);
        */

       
        //Verificar Aqui Jean Inverter 


        /*
        CloudVariables.Tnt = PlayerStats.PlayerItens.Tnt;
        CloudVariables.Trap = PlayerStats.PlayerItens.Trap;
        CloudVariables.Coins = PlayerStats.PlayerItens.Coins;
        */
        Save();

      
        
    }

    public void SaveLevel()
    {
        /* SAVE LOCAL
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.CIDADELA, PlayerStats.LvlStats.Cidadela);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.DESERTO_SILENCIOSO, PlayerStats.LvlStats.DesertoSilencioso);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.FLORESTA_NOTURNA, PlayerStats.LvlStats.FlorestaNoturna);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.MINA_ABANDONADA, PlayerStats.LvlStats.MinaAbandonada);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.MONTANHAS_DO_SUL, PlayerStats.LvlStats.MontanhasDoSul);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.PANTANO_DOS_MORTOS, PlayerStats.LvlStats.PantanoDosMortos);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.VALE_DO_DESESPERO, PlayerStats.LvlStats.ValeDoDesespero);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.VILAREJO_FANTASMA, PlayerStats.LvlStats.VilarejoFantasma);
        */


        //Verificar aqui Inverter

        //Jean
       // CloudVariables.ValeDoDesespero =  CloudVariables.ValeDoDesespero;
       // CloudVariables.VilarejoFantasma = CloudVariables.VilarejoFantasma;

       /* CloudVariables.Cidadela = PlayerStats.LvlStats.Cidadela;
        CloudVariables.DesertoSilencioso = PlayerStats.LvlStats.DesertoSilencioso;
        CloudVariables.FlorestaNoturna = PlayerStats.LvlStats.FlorestaNoturna; 
        CloudVariables.MinaAbandonada = PlayerStats.LvlStats.MinaAbandonada;
        CloudVariables.MontanhasDoSul = PlayerStats.LvlStats.MontanhasDoSul;
        CloudVariables.PantanoDosMortos = PlayerStats.LvlStats.PantanoDosMortos;
        CloudVariables.ValeDoDesespero = PlayerStats.LvlStats.ValeDoDesespero;
        CloudVariables.VilarejoFantasma = PlayerStats.LvlStats.VilarejoFantasma;*/
        Save();


        
        
    }

    //----------------------------------- CARREGAR ----------------------------
    public void LoadInventory()
    {

        /* LOAD LOCAL
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


        */

      

        PlayerStats.PlayerItens.Tnt = CloudVariables.Tnt;
        PlayerStats.PlayerItens.Trap = CloudVariables.Trap;
        PlayerStats.PlayerItens.Coins = CloudVariables.Coins;

        PlayerStats.PlayerItens.removeADS = CloudVariables.Ads;

        //Jean
       // CloudVariables.Coins = CloudVariables.Coins;




    }

    public void LoadLevel()
    {

        /* LOAD LOCAL
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
        */



        //CloudVariables.VilarejoFantasma = CloudVariables.VilarejoFantasma;//Jean
        // CloudVariables.ValeDoDesespero = CloudVariables.ValeDoDesespero;//Jean

       

        PlayerStats.LvlStats.VilarejoFantasma = CloudVariables.VilarejoFantasma;
        PlayerStats.LvlStats.ValeDoDesespero = CloudVariables.ValeDoDesespero;
        PlayerStats.LvlStats.PantanoDosMortos = CloudVariables.PantanoDosMortos;
        PlayerStats.LvlStats.MinaAbandonada = CloudVariables.MinaAbandonada;
        PlayerStats.LvlStats.Cidadela = CloudVariables.Cidadela;
        PlayerStats.LvlStats.FlorestaNoturna = CloudVariables.FlorestaNoturna;
        PlayerStats.LvlStats.MontanhasDoSul = CloudVariables.MontanhasDoSul;
        PlayerStats.LvlStats.DesertoSilencioso = CloudVariables.DesertoSilencioso;




    }

    public void DeleteAllCloud()
    {
        Cloud.Storage.DeleteAll();
    
    }

   


}
