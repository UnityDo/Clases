using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Carta", menuName = "Hearstone/Baraja Predefinida", order = 1)]
public class DataBaraja : ScriptableObject
{
    public string nombre;

    public List<DataHearstoneCarta> Baraja;



}
