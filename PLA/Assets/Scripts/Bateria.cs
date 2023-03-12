using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{

    Vector3 Angulos;
    Quaternion Rotacion;
    
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Angulos += new Vector3(45.0f,45.0f,45.0f) * Time.deltaTime * Speed;
        Rotacion.eulerAngles = Angulos; 
        this.transform.rotation = Rotacion;
    }

    public void OnTriggerEnter(Collider other) {

         if(other.gameObject.CompareTag("Player")){
              GameObject.Find("Flashlight").GetComponent<Linterna>().Recharge();
              Destroy(this.gameObject);
         }
    }
}
