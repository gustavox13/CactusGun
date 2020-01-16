using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRotation : MonoBehaviour {

    [SerializeField]
    private Transform mainCamera;

   
    [SerializeField]
    private float positionOffset;
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
        
    }

    private void Update()
    {
         transform.LookAt(mainCamera);

       transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.back, mainCamera.transform.rotation * Vector3.up);

    }

    private void LateUpdate()
    {
        
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.back, mainCamera.transform.rotation * Vector3.up);
    }


}
