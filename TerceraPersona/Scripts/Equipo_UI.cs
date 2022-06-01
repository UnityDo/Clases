using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipo_UI : MonoBehaviour
{
    public Slot_Equipo Armadura, Guantes, Botas, Cinturon, Collar, Anillo1, Anillo2, Piernas, Casco, Arma, Escudo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiaSlot(Sprite icono,Equipo.PosicionEquipo posicionEquipo)
    {
        //evaluamos la posicion
        switch (posicionEquipo)
        {
            case Equipo.PosicionEquipo.Armadura:
                Armadura.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Guantes:
                Guantes.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Botas:
                Botas.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Cinturon:
                Cinturon.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Collar:
                Collar.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Anillo1:
                Anillo1.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Anillo2:
                Anillo2.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Piernas:
                Piernas.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Casco:
                Casco.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Arma:
                Arma.SetIcono(icono);
                break;
            case Equipo.PosicionEquipo.Escudo:
                Escudo.SetIcono(icono);
                break;
        }
    }
}
