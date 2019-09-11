using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  

    public class LvlStats
    {
        public static bool TimeToBoss;
        public static string CurrentMap;

        //Numero de repeticoes por nivel
        public static int MaxLvlRepeat = 3;


        public static int Cidadela = 0;
        public static int DesertoSilencioso = 0;
        public static int FlorestaNoturna = 0;
        public static int MinaAbandonada = 0;
        public static int MontanhasDoSul = 0;
        public static int PantanoDosMortos = 0;
        public static int ValeDoDesespero = 0;
        public static int VilarejoFantasma = 0;

    }

    public sealed class PlayerItens
    {
        public static int Trap = 0;
        public static int Tnt = 0;
        public static int Coins = 0;

    }

    public sealed class DataBaseInfo
    {
        //inventario
        public const string TNT = "tnt";
        public const string TRAP = "trap";
        public const string COINS = "coins";

        //levels
        public const string CIDADELA = "cidadela";
        public const string DESERTO_SILENCIOSO = "desertoSilencioso";
        public const string FLORESTA_NOTURNA = "florestaNoturna";
        public const string MINA_ABANDONADA = "minaAbandonada";
        public const string MONTANHAS_DO_SUL = "montanhasDoSul";
        public const string PANTANO_DOS_MORTOS = "pantanoDosMortos";
        public const string VALE_DO_DESESPERO = "valeDoDesespero";
        public const string VILAREJO_FANTASMA = "vilarejoFantasma";
           


    }

}
