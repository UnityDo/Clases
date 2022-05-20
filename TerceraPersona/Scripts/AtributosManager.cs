using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributosManager : MonoBehaviour
{
    //TODO solo para verlos
    public float _Fuerza;
    public float _Constitucion;
    public float _Pericia;
    public float _Inteligencia;
    public float _Memoria;
    public float _Ingenio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiaAtributos(Atributos.AtributosBasicos atributosBasicos)
    {
        _Fuerza += atributosBasicos._Fuerza;
        _Constitucion += atributosBasicos._Constitucion;
        _Pericia += atributosBasicos._Pericia;
        _Inteligencia += atributosBasicos._Inteligencia;
        _Memoria += atributosBasicos._Memoria;
        _Ingenio += atributosBasicos._Inteligencia;
        Control_UI.instancia.control_Atributos.RellenaAtributos(_Fuerza, _Constitucion, _Pericia, _Inteligencia, _Memoria, _Ingenio);
    }
    public void CambiaAtributos(float mF,float mC,float mP,float mI,float mM,float mIng)
    {
        _Fuerza += mF;
        _Constitucion += mC;
        _Pericia += mP;
        _Inteligencia += mI;
        _Memoria += mM;
        _Ingenio += mIng;
        Control_UI.instancia.control_Atributos.RellenaAtributos(_Fuerza, _Constitucion, _Pericia, _Inteligencia, _Memoria, _Ingenio);
    }
}
