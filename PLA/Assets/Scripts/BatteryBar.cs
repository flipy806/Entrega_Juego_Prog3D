using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    public Image BatImage;
    public Linterna Lint;
    // Start is called before the first frame update
    void Start()
    {
       // BatImage = transform.Find("Bat").GetComponent<Image>();
       // Lint = new Linterna();
        //BatImage.fillAmount = 0.5f;
    }

    public void Update() {
        BatImage.fillAmount = Lint.Bateria * 0.01f;
    }

}
