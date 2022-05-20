using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Equipo", menuName = "Equipamiento/Equipo", order = 1)]
public class Equipo : Item
{
    //Saber donde va a estar ubicado
    public enum PosicionEquipo { Armadura,Guantes,Botas,Cinturon,Collar,Anillo1,Anillo2,Casco,Arma,Escudo}
    public PosicionEquipo posicionEquipo = PosicionEquipo.Armadura;
    public Sprite iconoEquipo;

    [Header("Posicion en el jugador")]
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
   

    public GameObject equipoPrefab;
    public override void Usa()
    {
        Transform posColoca = null;
        //Colocar el objeto en el panel de Equipo
        Debug.Log("Se va a poner" + nombre);
        //Construir el casco y ponerselo al jugador
        // Instantiate(equipoPrefab,)
        switch (posicionEquipo)
        {
            case PosicionEquipo.Armadura:
                posColoca = GameController.instancia.playerController.Armadura;
                break;
            case PosicionEquipo.Guantes:
                posColoca = GameController.instancia.playerController.Guantes;
                break;
            case PosicionEquipo.Botas:
                posColoca = GameController.instancia.playerController.Botas;
                break;
            case PosicionEquipo.Cinturon:
                posColoca = GameController.instancia.playerController.Cinturon;
                break;
            case PosicionEquipo.Collar:
                posColoca = GameController.instancia.playerController.Collar;
                break;
            case PosicionEquipo.Anillo1:
                break;
            case PosicionEquipo.Anillo2:
                break;
            case PosicionEquipo.Casco:
                posColoca = GameController.instancia.playerController.Casco;
                break;
            case PosicionEquipo.Arma:
                posColoca = GameController.instancia.playerController.Arma;
                break;
            case PosicionEquipo.Escudo:
                posColoca = GameController.instancia.playerController.Escudo;
                break;
        }
        if (posColoca != null)
        {
            GameObject clonEquipo = Instantiate(equipoPrefab, posColoca);

            clonEquipo.transform.localPosition = position;
            clonEquipo.transform.localRotation= Quaternion.Euler(rotation);
                   clonEquipo.transform.localScale = scale;
            //TODO guardar el clon
            //Meterlo en el UI del Equipo
        }
       
    }
}
