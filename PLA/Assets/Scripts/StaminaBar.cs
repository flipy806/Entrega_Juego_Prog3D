using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
     public Slider Stamn;
     public PlayerMove Play;
 
    // Start is called before the first frame update
    void Start()
    {
        Stamn.value = Play.Stamina;
        Stamn.maxValue = Play.MaxStam;
    }


    // Update is called once per frame
    void Update()
    {
        Stamn.value = Play.Stamina;
    }
}
