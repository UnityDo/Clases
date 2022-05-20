using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlDinero : MonoBehaviour
{
    public TextMeshProUGUI cantidadDineroText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PintaDinero(int monedas)
    {
        cantidadDineroText.text = monedas.ToString();
    }
}
