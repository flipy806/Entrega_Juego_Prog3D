using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCont : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private Transform playerTransform; // Transform del jugador
    [SerializeField] private float playerHeight = 2f; // Altura del jugador
    [SerializeField] private float playerRotationSpeed = 100f; // Velocidad de rotación del jugador

    [Header("Camera Settings")]
    [SerializeField] private Transform cameraTransform; // Transform de la cámara
    [SerializeField] private float cameraSensitivity = 2.5f; // Sensibilidad del movimiento de la cámara
    [SerializeField] private float cameraDistance = 3f; // Distancia de la cámara al jugador
    [SerializeField] private float cameraHeight = 1f; // Altura de la cámara con respecto al jugador

    private float xRotation = 0f;

    void Start()
    {
        // Oculta el cursor del mouse y lo mantiene en el centro de la pantalla
        //Cursor.lockState = CursorLockMode.Locked;

        // Si no se especifica el jugador, se busca automáticamente en la escena
        if (playerTransform == null)
        {
            playerTransform = FindObjectOfType<PlayerMove>().transform;
        }
    }

    void Update()
    {
        // Obtener el movimiento del mouse
        float mouseX = SimpleInput.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        float mouseY = SimpleInput.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;

        // Rotar el jugador horizontalmente
        playerTransform.Rotate(Vector3.up * mouseX * playerRotationSpeed);

        // Rotar la cámara verticalmente
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Aplicar la rotación de la cámara
        Quaternion cameraRotation = Quaternion.Euler(xRotation, playerTransform.eulerAngles.y, 0f);
        cameraTransform.rotation = cameraRotation;

        // Posicionar la cámara detrás del jugador
        Vector3 cameraPosition = playerTransform.position - (cameraRotation * Vector3.forward * cameraDistance);
        cameraPosition.y = playerTransform.position.y + cameraHeight;
        cameraTransform.position = cameraPosition;
    }
}

