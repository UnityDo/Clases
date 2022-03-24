using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataArma", menuName = "ScriptableObjects/Armas", order = 1)]
public class DataArma : ScriptableObject
{
    public int id;
    public Vector3 posInicial;
    public Vector3 posApuntar;
    //Meter todos los datos que se necesiten
    public AudioClip sonidoDisparo;
    public AudioClip sonidoRecarga;
    public float alcance;
    public float dano;
    public float FuerzaDisparo;
    public Sprite icono;
    public int BalasXCargador;
    public int CargadoresInicial;
    public string nombre;
    public string descripcion;
    public GameObject casquillo;
    public AudioClip[] CasquilloSonidos;
    public float fuerzaCasquillo;
    public enum TipoArma { pistola,escopeta,ametralladora,fusil,francotirador, lanzamisiles}
    public TipoArma tipoArma = TipoArma.pistola;

}
