using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoHeroe { Mago,Sacerdote,Paladin,Brujo,Cazador,Druida,Asesina,Chaman,Guerrero}

[CreateAssetMenu(fileName = "Heroe", menuName = "Hearstone/Heroe", order = 1)]
public class DataHeroe : ScriptableObject
{
    public string nombre;
    public Sprite sprite;
   public TipoHeroe tipoHeroe;
    public int vida=30;
}
