using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public CharacterController cc;
    public float Gravedad = -9.81f;
    public Vector3 velocity;
    public float speed = 12;
    public float Lifes;
    public float Stamina;
    public float LowLifes = 0;
    public float MaxLifes = 3;
    public float MaxStam = 100f;
    public float MinStam = 0f;
    public float ReStam = 10f;
    public float LoseStam = 20f;
    public Slider Slid;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask floorMask;
    bool isGrounded;
    

    public float estado;

     void Start() {
        estado = 1;
        Lifes = MaxLifes;
        Stamina = MaxStam;
        BarraStamina();

        //Cam = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    public void Update()
    {
        
        Lifes = Mathf.Clamp(Lifes, LowLifes, MaxLifes);
        //Stamina = Mathf.Clamp(Stamina, MinStam, MaxStam);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        if(SimpleInput.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(2 * -2 * Gravedad);
        }

        switch (estado) {
            case 1 :
                speed = 12;
                GainStamina(ReStam);
                
                break;
            case 2 :
                speed = 15;
                NoStamina(LoseStam);

                break;
            default :
                
                break;
        }

        if(SimpleInput.GetButtonDown("Sprint")){
            
            estado = 2;
        } else if(SimpleInput.GetButtonUp("Sprint")){
            estado = 1;
        }

        float x = SimpleInput.GetAxis("Horizontal");
        float z = SimpleInput.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move*speed*Time.deltaTime);

        

        velocity.y += Gravedad * Time.deltaTime;
        cc.Move(velocity* Time.deltaTime);

        Ouch();

    }

    public void  Ouch() {
        if(Input.GetKeyDown(KeyCode.N)) {
            TakeDamage();
        }
    }

    public void TakeDamage() {
        Lifes -= 1;

        if(Lifes == LowLifes) {
            Debug.Log("U Ded");
        }
    }

    public void NoStamina(float Cant) {
        Stamina = Mathf.Clamp(Stamina - Cant, MinStam, MaxStam);
        BarraStamina();
       
    }
    public void GainStamina (float Cant) {
         
        Stamina = Mathf.Clamp(Stamina + Cant, MinStam, MaxStam);
        BarraStamina();

    }

    public void BarraStamina() {
        Slid.value = Stamina / MaxStam;
    }
    
}
    


