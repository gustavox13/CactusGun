using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public int[] level = new int[8];
    public int currentLevel;


    //Shop itens comprados

    //Golden
    public int golden;
    public int ruby;



    public void SaveVariables()
    {
        SaveSystem.SaveVariables(this);
    }

    public void LoadSave()
    {
        VariablesData data = SaveSystem.LoadVariables();

       

       level[0] = data.level[0];
       level[1] = data.level[1];
       level[2] = data.level[2];
       level[3] = data.level[3];
       level[4] = data.level[4];
       level[5] = data.level[5];
       level[6] = data.level[6];
       level[7] = data.level[7];

        ruby = data.ruby;
        currentLevel = data.currentLevel;
        golden = data.golden;
    }

    public void AddLevel(int value)
    {
        level[currentLevel-1] += value ; //substituir [0] por level(fase selecionada) atual, depois
    }

    public void AddGolden(int value)
    {
        golden += value; 
    }

    public int CompraRuby
    {
        get { return ruby; }
        set { ruby = value; }
    }





}
