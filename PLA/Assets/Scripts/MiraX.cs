using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraX : MonoBehaviour
{
    // Start is called before the first frame update
    public float SnowFlake;
    public GameObject NoHomo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float _mouseX = Input.GetAxis("Mouse X");  
     Vector3 Spin = transform.localEulerAngles;
     Spin.y += _mouseX * SnowFlake;

    
     NoHomo.transform.Rotate(0,_mouseX * Time.deltaTime * SnowFlake, 0);
      transform.localEulerAngles = Spin;
     
      //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (_mouseX * Sensitive),transform.localEulerAngles.z); 
    }
}
