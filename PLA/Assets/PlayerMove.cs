using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController cc;
    public float Gravedad = -9.81f;
    public Vector3 velocity;
    public float speed = 12;
    public float Lifes;
    public float LowLifes = 0;
    public float MaxLifes = 3;
    


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask floorMask;
    bool isGrounded;
    

    public float estado;

     void Start() {
        estado = 1;
        Lifes = MaxLifes;
        //Cam = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    public void Update()
    {
        
        Lifes = Mathf.Clamp(Lifes, LowLifes, MaxLifes);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(2 * -2 * Gravedad);
        }

        switch (estado) {
            case 1 :
                speed = 12;
                
                break;
            case 2 :
                speed = 15;
                

                break;
            default :
                
                break;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            estado = 2;
        } else if(Input.GetKeyUp(KeyCode.LeftShift)){
            estado = 1;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

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

     
    
}
    


