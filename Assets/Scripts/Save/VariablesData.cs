using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VariablesData
{ 


    public int[] level = new int[8];
    public int golden;
    public int currentLevel;
    public int ruby;



    public VariablesData (Variables variables)
    {
        level[0] = variables.level[0];//verificar aqui
        level[1] = variables.level[1];
        level[2] = variables.level[2];
        level[3] = variables.level[3];
        level[4] = variables.level[4];
        level[5] = variables.level[5];
        level[6] = variables.level[6];
        level[7] = variables.level[7];

        ruby = variables.ruby;
        golden = variables.golden;
        currentLevel = variables.currentLevel;
    }
}
