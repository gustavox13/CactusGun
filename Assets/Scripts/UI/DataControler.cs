using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataControler : MonoBehaviour
{
    [SerializeField]
    private Text moneyInfo;

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
        moneyInfo.text = PlayerStats.PlayerItens.Coins.ToString();

        CheckAndUnlockLvls();
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

}
