using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRotation : MonoBehaviour {

    [SerializeField]
    private Transform mainCamera;

    private void Update()
    {
        // transform.LookAt(mainCamera);
        
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.back, mainCamera.transform.rotation * Vector3.up);
        
    }
}
