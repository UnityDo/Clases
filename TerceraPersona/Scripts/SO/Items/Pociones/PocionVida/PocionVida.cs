using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Items/Pociones/PocionVida", order = 1)]
public class PocionVida : Pociones
{
    //Cuanta vida recupera con la pocion de vida
    public int vidaRecupera;

    //sobre escribe la funcioncionalidad
    //para hacer la q nosotros necesitemos
    public override void Usa()
    {
       // base.Usa();
        Debug.Log("Usa la pocion de vida");

   GameController.instancia.playerController.vidaJugador += vidaRecupera;
    }
}
