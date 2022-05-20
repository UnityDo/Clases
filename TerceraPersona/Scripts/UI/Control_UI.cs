using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_UI : MonoBehaviour
{
    //es una singleton
    public static Control_UI instancia;
    public ControlVida controlVida;
    public ControlMagia controlMagia;
    public Control_Atributos control_Atributos;
    public ControlDinero controlDinero;
    public Inventario_UI inventarioUI;
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiaVida(float vida)
    {
        if (controlVida)
        {
            controlVida.SetVida(vida);
        }
        else
        {
            throw new System.Exception("Me falta control Vida");
        }
       
    }
    public void CambiaMagia(float magia)
    {
        if (controlMagia)
        {
            controlMagia.SetMagia(magia);
        }
        else
        {
            throw new System.Exception("Me falta control magia");
        }
      
    }
    public void PintarAtributos(Atributos atributos)
    {
        //como la raza modifica el atributo
        Atributos.AtributosBasicos atributosModificados = atributos.AtributosConModificador();
        control_Atributos.RellenaAtributos(atributosModificados._Fuerza, atributosModificados._Pericia,
           atributosModificados._Inteligencia, atributosModificados._Constitucion, atributosModificados._Memoria,
           atributosModificados._Ingenio);
    }
    public void PintaDinero(int _monedas)
    {
        controlDinero.PintaDinero(_monedas);
    }
}
