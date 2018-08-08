using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour {

    
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    [SerializeField]
    private int currentHealth = 100;

    [SerializeField]
    private RectTransform healthBar;

    [SerializeField]
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }



    public void TakeDamange(int amount)
    {
        currentHealth -= amount;
        GetComponent<AudioSource>().Play();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            anim.SetBool("Morrendo", true);
           // Debug.Log("E morreu");
        }
        
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

}
