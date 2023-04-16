using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaraa : MonoBehaviour
{
   public float Sensibility = 100;
    public Transform PlayerBody;
    public Transform CamPlace;
    private Transform Came;
    public float xRotacion;
    public float rotY;
    public Animator Cam;
    public PlayerMove Pla;
    

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Came = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Pla.estado == 1) {
            Cam.SetBool("Runnin",false);
        } else if(Pla.estado == 2) {
            Cam.SetBool("Runnin",true);
        }

        float mouseX = SimpleInput.GetAxis("Mouse X")/* * Sensibility * Time.deltaTime*/;
        float mouseY = SimpleInput.GetAxis("Mouse Y")/* * Sensibility * Time.deltaTime*/;

        rotY += mouseY * Sensibility * Time.deltaTime;
        float rotX = mouseX * Sensibility * Time.deltaTime;

        PlayerBody.Rotate(0 ,rotX, 0);
        
        rotY = Mathf.Clamp(rotY, -90, 90);

        Quaternion localRotation = Quaternion.Euler(-rotY, 0, 0);
        CamPlace.localRotation = localRotation;

        Came.position = Vector3.Lerp(Came.position, CamPlace.position, Sensibility * Time.deltaTime);
        Came.rotation = Quaternion.Lerp(Came.rotation, CamPlace.rotation, Sensibility * Time.deltaTime);


    }
}
