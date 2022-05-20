using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Equipo", menuName = "Equipamiento/Casco", order = 1)]
public class Casco : Equipo
{
    public int ModificadorArmadura;
    public int ModifcadorArmaduraMagica;
   
    public float BonusFuerza = 0;
    public float BonusConstitucion = 0;
    public float BonusPericia = 0;
    public float BonusInteligencia = 0;
    public float BonusMemoria = 0;
    public float BonusIngenio = 0;


    public void OnEnable()
    {
        posicionEquipo = PosicionEquipo.Casco;
     
    }
  

}
