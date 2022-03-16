using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Control_Armas : MonoBehaviour
{
    //Me centro en q sea un Arma sin importar el tipo
    public Arma armaActual;
    //Cambios de arma, todas las armas son Arma
    public List<Arma> Armas;
    int indiceArma = 0;

    // Start is called before the first frame update
    void Start()
    {
        armaActual = Armas[indiceArma];
        //desactivo todas
        foreach (Arma a in Armas)
        {
            a.gameObject.SetActive(false);
        }
        //activa el arma principal
        armaActual.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnFire()
    {
        if (!enabled)
        {
            return;
        }
        //
        armaActual.Dispara();
    }
    public void OnRecarga()
    {
        if (!enabled)
        {
            return;
        }
        //
        armaActual.Recarga();
    }
    void CambiaArma(float mouseWheel)
    {
        //Ahora seria el colt
       
        if (mouseWheel > 0)
        {
            indiceArma++;
            //controlar los limites de la matriz o lista
            if(indiceArma> Armas.Count-1)
            {
                indiceArma = 0;
            }
            print("Para arriba");
        }else if (mouseWheel < 0)
        {
            indiceArma--;
            //controlar el limite de la matriz
            if (indiceArma < 0)
            {
                indiceArma = Armas.Count - 1;
            }
            print("Para abajo");
        }
        armaActual = Armas[indiceArma];
        //desactivo todas
        foreach (Arma a in Armas)
        {
            a.gameObject.SetActive(false);
        }
        //activa el arma principal
        armaActual.gameObject.SetActive(true);
    }
    public void OnCambiaArma(InputValue value)
    {
        if (!enabled)
        {
            return;
        }
        //
       // print(value.Get());
        CambiaArma((float)value.Get());
       
     
    }
}
