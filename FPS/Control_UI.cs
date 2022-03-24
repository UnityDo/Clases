using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_UI : MonoBehaviour
{
    //Convertimos en singlenton
    public static Control_UI instancia;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
       
    }

    public TMPro.TextMeshProUGUI municionActual_txt, municionTotal_txt;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMunicionActual(int municion)
    {
        municionActual_txt.text = municion.ToString();
    }
    public void SetMunicionTotal(int municion)
    {
        municionTotal_txt.text = municion.ToString();
    }
}
