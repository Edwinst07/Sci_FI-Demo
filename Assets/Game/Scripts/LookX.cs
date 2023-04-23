using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
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
        float _mouseX = Input.GetAxis("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += _mouseX * sensitivity;
        transform.localEulerAngles = newRotation;

        /*
        float localEulerAnglesX = transform.localEulerAngles.x;
        float localEulerAnglesY = transform.localEulerAngles.y;
        float localEulerAnglesZ = transform.localEulerAngles.z;
        transform.localEulerAngles = new Vector3(localEulerAnglesX, localEulerAnglesY + (_mouseX*sensitivity), localEulerAnglesZ);
        */
    }
}
