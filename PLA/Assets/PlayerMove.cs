using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    #region Variables_Publicas
    public CharacterController cc;
    public Vector3 velocity;
    public Slider Slid;
    public Transform groundCheck;
    public LayerMask floorMask;
    public float Lifes;
    public float LowLifes = 0;
    public float MaxLifes = 3;
    public float estado;
    public bool IsMoving;
    public AudioSource Pasos;
    public AudioClip walkClip;
    public AudioClip runClip;
    #endregion

    #region Variables_Privadas
    private bool isGrounded;
    [SerializeField] private float Gravedad = -9.81f;
    [SerializeField] private float speed = 12;
    [SerializeField] private float MaxStam = 1f;
    [SerializeField] private float MinStam = 0f;
    [SerializeField] private float ReStam = 0.000002f;
    [SerializeField] private float LoseStam = 0.000003f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float Stamina;
    #endregion

    void Start() {

       
        Lifes = MaxLifes;
        Stamina = MaxStam;
        BarraStamina();

    }

    public void Update()
    {
        
        Lifes = Mathf.Clamp(Lifes, LowLifes, MaxLifes);  
        
        //Maquina de estado
        switch (estado) {

            case 1 :
                speed = 9;
                GainStamina(ReStam);
                
                break;
            case 2 :
                speed = 15;
                NoStamina(LoseStam);

                break;
            default :
                
                break;
        } 

        Ouch();
        Movement();
        Sprinting();
        Jumping();
    }

    //Funcion de movimiento
    public void Movement()
    {
        float x = SimpleInput.GetAxis("Horizontal");
        float z = SimpleInput.GetAxis("Vertical"); 

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * speed * Time.deltaTime);

        velocity.y += Gravedad * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        
         if (move.magnitude > 0.1f && !Pasos.isPlaying) {
            Pasos.Play();
        } else if (move.magnitude < 0.1f && Pasos.isPlaying) {
            Pasos.Stop();
        }

    }

    //Funci�n de Salto
    public void Jumping()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (SimpleInput.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(2 * -2 * Gravedad);
        }
    }

    //Lo que permite correr
    public void Sprinting()
    {

        if (SimpleInput.GetButtonDown("Sprint"))
        {
            estado = 2;
             Pasos.clip = runClip;
             Pasos.Play();
        }
        else if (SimpleInput.GetButtonUp("Sprint"))
        {
            estado = 1;
            Pasos.clip = walkClip;
            Pasos.Play();
        }
    }

    //activa la funcion de recibir da�o
    public void  Ouch() {
        if(Input.GetKeyDown(KeyCode.N)) {
            TakeDamage();
        }
    }

    // funcion de recibir da�o
    public void TakeDamage() {
        Lifes -= 1;

        if(Lifes == LowLifes) {
            Debug.Log("U Ded");
        }
    }

    //Activa la perdida de Stamina
    public void NoStamina(float Cant) {
        Stamina = Mathf.Clamp(Stamina - Cant * Time.deltaTime, MinStam, MaxStam);
        if (Stamina <= 0) { 
            estado = 1;
            Pasos.clip = runClip;
            Pasos.Stop();  
        }
        BarraStamina();
       
    }

    //Activa la ganancia de Stamina
    public void GainStamina (float Cant) {
         
        Stamina = Mathf.Clamp(Stamina + Cant * Time.deltaTime, MinStam, MaxStam);
        BarraStamina();

    }

    //Cambia el estado de la barra de Stamina
    public void BarraStamina() {
        Slid.value = Stamina / MaxStam;
    }
    
}
    


