using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    [SerializeField]
    private GameObject capanga;
    [SerializeField]
    private GameObject chefe;

    private void Awake()
    {
        if(PlayerStats.LvlStats.TimeToBoss == true)
        {
            capanga.SetActive(false);
        }
        else
        {
            chefe.SetActive(false);
        }
    }

}
