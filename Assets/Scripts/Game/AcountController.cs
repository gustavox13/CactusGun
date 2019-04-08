using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcountController : MonoBehaviour
{
    private int qtdArmadilha;
    private int qtdDinamite;
    private int noADS = 0;
    private float score;

    private int level = 1;
    private int[] levels = new int[8];

    private void Awake()
    {
       
        qtdArmadilha = 3;
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

    public float GetScore()
    {
        score = PlayerPrefs.GetFloat("Score");
        return score;
    }

    public void SetScore(float var)
    {
        score += var;
        PlayerPrefs.SetFloat("Score", score);
       
    }

    public void SetLevel()
    {
        levels[level - 1] += 1 ;
    }

    

}
