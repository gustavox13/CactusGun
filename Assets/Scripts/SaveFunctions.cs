using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFunctions : MonoBehaviour
{
    //------------------------------------ SALVAR -----------------------------
    public void SaveInventory()
    {
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.TNT, PlayerStats.PlayerItens.Tnt);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.TRAP, PlayerStats.PlayerItens.Trap);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.COINS, PlayerStats.PlayerItens.Coins);
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.CIDADELA, PlayerStats.LvlStats.Cidadela);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.DESERTO_SILENCIOSO, PlayerStats.LvlStats.DesertoSilencioso);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.FLORESTA_NOTURNA, PlayerStats.LvlStats.FlorestaNoturna);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.MINA_ABANDONADA, PlayerStats.LvlStats.MinaAbandonada);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.MONTANHAS_DO_SUL, PlayerStats.LvlStats.MontanhasDoSul);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.PANTANO_DOS_MORTOS, PlayerStats.LvlStats.PantanoDosMortos);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.VALE_DO_DESESPERO, PlayerStats.LvlStats.ValeDoDesespero);
        PlayerPrefs.SetInt(PlayerStats.DataBaseInfo.VILAREJO_FANTASMA, PlayerStats.LvlStats.VilarejoFantasma);
    }

    //----------------------------------- CARREGAR ----------------------------
    public void LoadInventory()
    {
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
    }

    public void LoadLevel()
    {
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
    }


}
