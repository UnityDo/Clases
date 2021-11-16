using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PintaCartas : MonoBehaviour
{
    public Transform panelJugador, panelPc, panelMesa;
    public GameObject cartaBase;
    //para almacenar las cartas imagen que se crean
    //Pueden no ser publicas
    public List<GameObject> CartasImagenJugador,CartasImagenPc,CartasImagenMesa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GameObject CreaImagenCarta(Transform panel, Carta carta)
    {
        GameObject clonCarta = Instantiate(cartaBase, panel);
        //le mete la imagen de la carta
        clonCarta.GetComponent<Image>().sprite = carta.cartaSprite;
        clonCarta.name = carta.nombre;
        return clonCarta;
    }
    //Lo q se guarda y donde se guarda
    //La imagen carta construida en una lista de imagenes carta
    void GuardaCartaImagen(GameObject cartaImagen, List<GameObject> CartasImagen)
    {
        //Guarda la carta
        CartasImagen.Add(cartaImagen);
    }
    //Elimina carta
    //Elimina la visualizacion y la referencia
    void EliminaCarta(GameObject cartaImagen, List<GameObject> CartasImagen)
    {
        Destroy(cartaImagen);
        //La elimino de la lista
        CartasImagen.Remove(cartaImagen);
    }
    public void PintaCartaJugador(Carta carta)
    {
        //Crea la imagen
       GameObject cartaCreada= CreaImagenCarta(panelJugador,carta);
        //Guarda la imagen
        GuardaCartaImagen(cartaCreada, CartasImagenJugador);
    }
    public void EliminaCartaPc(GameObject cartaEliminar)
    {
        EliminaCarta(cartaEliminar, CartasImagenPc);
    }
    public void EliminaCartaJugador(GameObject cartaEliminar)
    {
        EliminaCarta(cartaEliminar, CartasImagenJugador);
    }
    public void PintaCartaPc(Carta carta)
    {
        GameObject cartaCreada = CreaImagenCarta(panelPc, carta);
        //Guarda la imagen
        GuardaCartaImagen(cartaCreada, CartasImagenPc);
    }
    public void PintaCartaMesa(Carta carta)
    {
        GameObject cartaCreada = CreaImagenCarta(panelMesa, carta);
        //Guarda la imagen
        GuardaCartaImagen(cartaCreada, CartasImagenMesa);
    }
}
