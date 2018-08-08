using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{

    [SerializeField]
    private int[] medalhas = new int[3]; // 0 - Ouro  / 1 - Prata / 2 - Bronze
    [SerializeField]
    private float dinheiro = 0f;

	// Use this for initialization
	void Start ()
    {
       

	}
	
	// Update is called once per frame
	void Update ()
    {
      
	}

    public void AddDinheiro(float valor)
    {
        dinheiro += valor;
    }

    public float GetDinheiro()
    {
        return this.dinheiro;
    }

    public void AddMedalha(int valor)
    {
        switch(valor)
        {
            case 0:
                medalhas[0] += 1; //Ouro
                break;
            case 1:
                medalhas[1] += 1; //Prata
                break;
            case 2:
                medalhas[2] += 1; //Bronze
                break;

        }
    }

   
}
