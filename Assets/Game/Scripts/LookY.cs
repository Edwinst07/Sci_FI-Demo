using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= _mouseY * sensitivity;
        transform.localEulerAngles = newRotation;

        /*
        float localEulerAnglesX = transform.localEulerAngles.x;
        float localEulerAnglesY = transform.localEulerAngles.y;
        float localEulerAnglesZ = transform.localEulerAngles.z;

        transform.localEulerAngles = new Vector3(localEulerAnglesX+ (_mouseY * sensitivity), localEulerAnglesY, localEulerAnglesZ);
        */
    
    }



}
