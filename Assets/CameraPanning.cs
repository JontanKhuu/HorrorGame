using System;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject activeCamera;
    [SerializeField] float sensitivity;

    float xRotation;
    float yRotation;

    private void Update()
    {   
        if(activeCamera.activeSelf == true){   
            xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
            yRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);           

            transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);
        }
    }
}