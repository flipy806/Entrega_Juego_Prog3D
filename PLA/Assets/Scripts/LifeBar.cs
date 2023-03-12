using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Slider Vid;
    public PlayerMove Play;
 
    // Start is called before the first frame update
    void Start()
    {
        Vid.value = 0;
        Vid.maxValue = Play.MaxLifes;
    }


    // Update is called once per frame
    void Update()
    {
        Vid.value = Play.Lifes;
    }
}
