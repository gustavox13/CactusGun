﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Tempo());
	}


    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }
	
	
}
