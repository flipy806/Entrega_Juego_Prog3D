using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    #region Variables_Publicas
    public Transform PlayerBody;
    public Animator Cam;
    public PlayerMove Pla;
    #endregion

    #region Variables_Privadas
    [SerializeField] private float xRotacion;
    [SerializeField] private float Sensibility = 100;
    #endregion

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

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

        transform.localRotation = Quaternion.Euler(xRotacion, 0, 0) * PlayerBody.rotation;


    }
}

