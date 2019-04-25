using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    

    public event Action<float> OnHealthPctChanged = delegate { };

    private Animator anim;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    private int currentHealth;

    private void OnEnable()
    {
        anim = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;

    }

    
    public void TakeDamange(int amount)
    {
        currentHealth += amount;
        

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            anim.SetBool("Morrendo", true);
        }
    }

    private void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Space))
         //   TakeDamange(-10);
    }

}
