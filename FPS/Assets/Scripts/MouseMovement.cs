using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;
    void Start()
    {
        //Locked at the middle and invisible cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //mouse updates
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //x axis rotation
        xRotation -= mouseY;

        //clamp the rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //y axis rotation
        yRotation += mouseX;

        //apply rotation to transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }
}
