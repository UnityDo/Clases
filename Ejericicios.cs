using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejericicios : MonoBehaviour
{
    bool meVe=false, enRago=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool EvaluaPar(float numero)
    {
        if (numero % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool PuedeAtacar(){
    //recuerda una funcion que devuelve valor siempre devuelve valor, en cualquier caso
        if(meVe&&enRango){
        //solo es true si los dos son true
            return true;
           }else{
        return false;
        }
    }
    
}
