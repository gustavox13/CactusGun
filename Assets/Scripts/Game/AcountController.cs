using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcountController : MonoBehaviour
{
    private int qtdArmadilha;
    private int qtdDinamite;
    private int noADS = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int CompraArmadilha 
    {
        get { return qtdArmadilha; }
        set { qtdArmadilha = value; }
    }

    public int CompraDinamite
    {
        get { return qtdDinamite;}
        set { qtdDinamite = value;}
    }

    public int RemoveADS
    {
        get { return noADS; }
        set { noADS = value;}
    }

}
