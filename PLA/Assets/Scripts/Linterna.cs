using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public bool IsOn = false;
    public GameObject Light;
    public bool FailSafe = false;
    public float Bateria;
    public float LowBat = 0;
    public float MaxBat = 100;
    private Coroutine MenosBateria;
    
   // public BatteryBar Pila;

    // Update is called once per frame
    public void Start() {
        Bateria = MaxBat;
       
    }
    void Update()
    {
       TurnOn();
       Bateria = Mathf.Clamp(Bateria, LowBat, MaxBat);
       //GameObject.Find("Bat").GetComponent<BatteryBar>().SetBattery(Bateria);
       
    }

    public void TurnOn () {

        if (Bateria > LowBat)
        {
            if (SimpleInput.GetButtonDown("FlashLight") && Bateria >= LowBat)
            {
                if (IsOn == false && FailSafe == false)
                {
                    FailSafe = true;
                    Light.SetActive(true);
                    IsOn = true;
                    StartCoroutine(Failsafe());
                    MenosBateria = StartCoroutine(LessBat());

                }
                if (IsOn == true && FailSafe == false)
                {
                    FailSafe = true;
                    Light.SetActive(false);
                    IsOn = false;
                    StartCoroutine(Failsafe());
                    StopCoroutine(MenosBateria);
                }


            }
            else if (Input.GetButtonDown("FlashLight") && Bateria <= LowBat)
            {

                Debug.Log("No battery");

            }
        }
        else if (Bateria == LowBat)
        {
            IsOn = false;
            Light.SetActive(false);
        }
    }
        
        
    

   public void Recharge () {
       if(Bateria < MaxBat){
            Bateria += 10;
            
       }else if(Bateria == MaxBat){
            Bateria = MaxBat;
            
       }
        
   }



    IEnumerator Failsafe(){
        yield return new WaitForSeconds(0.25f);
        FailSafe = false;
    }

    IEnumerator LessBat(){
        while(true) {
            yield return new WaitForSeconds(3.5f);
            Bateria -= 10;
            
        }
    }

    
}
