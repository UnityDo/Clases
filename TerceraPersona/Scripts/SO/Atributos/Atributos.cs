using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Atributos", menuName = "Atributos/Atributo", order = 1)]
public class Atributos : ScriptableObject
{
    public float Fuerza=10;
    public float Constitucion=10;
    public float Pericia=10;
    public float Inteligencia=10;
    public float Memoria=10;
    public float Ingenio=10;

    public Raza raza;

    public int VidaBase=10;
    public int MagiaBase=10;

   public struct AtributosBasicos{
        public float _Fuerza;
        public float _Constitucion;
        public float _Pericia;
        public float _Inteligencia;
        public float _Memoria;
        public float _Ingenio;
    }


    public AtributosBasicos AtributosConModificador()
    {
        AtributosBasicos atributosBasicos = new AtributosBasicos();
        atributosBasicos._Fuerza = Fuerza + raza.FuerzaMod;
        atributosBasicos._Constitucion = Constitucion+raza.ConstitucionMod;
        atributosBasicos._Pericia = Pericia + raza.PericiaMod;
        atributosBasicos._Inteligencia = Inteligencia + raza.InteligenciaMod;
        atributosBasicos._Memoria = Memoria + raza.MemoriaMod;
        atributosBasicos._Ingenio = Ingenio + raza.IngenioMod;
        return atributosBasicos;

    }

}
