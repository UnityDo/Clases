using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion 
{
    string nombreJugador;
    int puntuacion;

    public Puntuacion(string _nombreJugador, int _puntuacion)
    {
        this.nombreJugador = _nombreJugador;
        this.puntuacion = _puntuacion;
    }
    void SetPuntuacion(int _puntuacion)
    {
        this.puntuacion = _puntuacion;
    }
    int GetPuntuacion()
    {
        return this.puntuacion;
    }
    
}
