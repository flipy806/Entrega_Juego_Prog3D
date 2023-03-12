using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIRAAY : MonoBehaviour
{
     // Start is called before the first frame update
        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float _mouseY = Input.GetAxis("Mouse Y");  
     Vector3 Spiny = transform.localEulerAngles;
     Spiny.x -= _mouseY;
     transform.localEulerAngles = Spiny;
  
      //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (_mouseX * Sensitive),transform.localEulerAngles.z); 
    }
}
