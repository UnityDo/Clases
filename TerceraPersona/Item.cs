using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 1)]
public class Item : ScriptableObject
{
    public string nombre;
    public string descripcion;
    public float precio;
    public Sprite icono;
}
