using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Tribu { Bestia,Demonio,Dragon,Elemental,Robot,Murloc,Pirata,Totem,Jabaespin}
public enum Tipo { Esbirro,Arma,Hechizo}
public enum Poder { Provocar, Cargar }
[CreateAssetMenu(fileName = "Carta", menuName = "Hearstone/Carta", order = 1)]
public class DataHearstoneCarta : ScriptableObject
{
    public string nombre;
    public int id;
    [TextArea]
    public string descripcion;
    public int coste;
    public int ataque;
    public int vida;
    public Sprite sprite;
    public Tribu tribu;
    public Tipo tipo;
    public Poder poder;
    public GameObject particulas;
    

}
