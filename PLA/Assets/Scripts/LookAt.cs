using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public float Sensibility = 100;
    public Transform PlayerBody;
    public float xRotacion;
    public Animator Cam;
    public PlayerMove Pla;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cam = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensibility * Time.deltaTime;

        if(Pla.estado == 1) {
            Cam.SetBool("Runnin",false);
        } else if(Pla.estado == 2) {
            Cam.SetBool("Runnin",true);
        }

        PlayerBody.Rotate(Vector3.up * mouseX);

        xRotacion -= mouseY;
        xRotacion = Mathf.Clamp(xRotacion, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);


    }
}
