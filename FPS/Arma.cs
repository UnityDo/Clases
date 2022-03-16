using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase abstracta de la clase Arma q es un marco definidor
//Con la palabra clave abstract
public abstract class Arma: MonoBehaviour
{
    //definimos un metodo abstracto q sea comun a las clase hijas
    public abstract void Dispara();
    public abstract void Recarga();

}

