using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Items/Arcos/ArcoLargo", order = 1)]
public class ArcoLargo : Arcos
{
    public float alcance = 400;
    //Disparo especial
    public AudioClip sonido_disparo;
    public GameObject flecha_larga;
    
}
