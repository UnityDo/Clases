using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Items/Arcos", order = 1)]
public class Arcos : Arma
{
  
    public float danio;
    public float nivel_exigencia;
    public float destreza_min;
    public GameObject modelo;
    public float fuerzaDisparo;

    public override void Usa()
    {
        // base.Usa();
        Debug.Log("Pone el arco");
    }
}
