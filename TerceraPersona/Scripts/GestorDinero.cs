using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorDinero : MonoBehaviour
{
    //La hacemos privada para protegerla
    private int dinero = 10;

    //propiedades
    public int Dinero { get => dinero; set => dinero = value; }

    // Start is called before the first frame update
    void Start()
    {
        SumaDinero(300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SumaDinero(int _dinero)
    {
        Dinero = Dinero+ _dinero;
        Control_UI.instancia.PintaDinero(Dinero);
    }
    public void RestaDinero(int _dinero)
    {
        if(Dinero - _dinero < 0)
        {//Mensaje de no tiene dinero suficiente para comprar

        }
        else
        {
            Dinero = Dinero - _dinero;
            Control_UI.instancia.PintaDinero(Dinero);

        }
        
    }
    public int GetDinero()
    {
        return Dinero;
    }
}
