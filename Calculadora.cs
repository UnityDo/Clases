using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculadora : MonoBehaviour
{
    public Text cajetin;
    int operacionMatematica = 0;
    float operando1, operando2;
    bool anota = true;
 
    // Start is called before the first frame update
    void Start()
    {
        cajetin.text = "0";
        
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    //Convertir las funciones de pulsar numero en una
    public void PulsaNumero(int numero)
    {
        if (anota)
        {
            if (float.Parse(cajetin.text) == 0)
            {
                cajetin.text = numero.ToString();
            }
            else
            {
                //concatenar es unir dos cadenas con +;
                cajetin.text += numero.ToString();
            }
        }
        else
        {
            cajetin.text = numero.ToString();
            anota = true;
        }
       
    }
    // Funcion para las operaciones
    public void PulsaOperacion(int operacion)
    {
        
        operacionMatematica = operacion;
        operando1 = float.Parse(cajetin.text);
        anota = false;
       
    }
    public void Igual()
    {
        //0 suma
        //1 resta
        //2 multiplicacion
        //3 division
        operando2 = float.Parse(cajetin.text);
        switch (operacionMatematica)
        {
            // suma
            case 0:
                //sumar operando1 con el operando2 delvolver el resultado y ponerlo en la caja de texto
                cajetin.text = ""+(operando1 + operando2);
                break;
            //1 resta
            case 1:

                break;
        }
    }

   

}
