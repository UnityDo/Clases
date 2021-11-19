using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum TipoJugador { Jugador,Pc}

public class CartaHearstone : MonoBehaviour
{
    public DataHearstoneCarta dataHearstoneCarta;
   public TextMeshProUGUI nombreText,descripcionText,costeText,ataqueText,vidaText;
    public Image imagenIlustracion, baseImagen;
    public Golpe golpe;

    public Sprite[] BaseSprites;
    //Variables para el juego
    int vida, ataque, coste;
    Button botonCarta;
    public TipoJugador tipoJugador;
    
//Create delegate for button
  

    // Start is called before the first frame update
    void Start()
    {
        RellenaInformacion();

        botonCarta = GetComponent<Button>();
        //le metemos una funcion al boton ()=> la funcion que quieras
        //this es la propia instancia de la clase
        botonCarta.onClick.AddListener(()=>PulsaBoton(this));

        //Buscar en la jeraquia a Hearstone
        //Recojo su componente y lo almaceno
        //1 Buscar por nombre
        //  hearstoneControl = GameObject.Find("CONTROL").GetComponent<Hearstone>();
        //2 Buscar por Tag
        // hearstoneControl= GameObject.FindGameObjectWithTag("CONTROLADOR").GetComponent<Hearstone>();
        //3 Busca por el Tipo
       // hearstoneControl = GameObject.FindObjectOfType<Hearstone>();
       
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PulsaBoton(CartaHearstone cartaHearstone)
    {
        switch (tipoJugador)
        {
            case TipoJugador.Jugador:
                //Le pasamos la cartapulsada al controlador del juego
                Hearstone.instancia.cartaElegidaJugador = cartaHearstone;
                break;
            case TipoJugador.Pc:
                Hearstone.instancia.cartaEnfretadaPc = cartaHearstone;
                break;
        }
        Hearstone.instancia.ResuelveEncuentro();



    }
    void RellenaInformacion()
    {
       
        nombreText.text = dataHearstoneCarta.nombre;
        descripcionText.text = dataHearstoneCarta.descripcion;
        costeText.text = dataHearstoneCarta.coste.ToString();
        ataqueText.text = dataHearstoneCarta.ataque.ToString();
        vidaText.text = dataHearstoneCarta.vida.ToString();
        imagenIlustracion.sprite = dataHearstoneCarta.sprite;
        baseImagen.sprite = BaseSprites[(int)dataHearstoneCarta.tipo];
        if (dataHearstoneCarta.tipo == Tipo.Hechizo)
        {
            ataqueText.enabled = false;
            vidaText.enabled = false;
        }
        vida = dataHearstoneCarta.vida;
        ataque = dataHearstoneCarta.ataque;
        coste = dataHearstoneCarta.coste;
    }
   public int GetAtaque()
    {
        return ataque;
    }
   public void SetAtaque(int _ataque)
    {
        ataque = _ataque;
    }
    public int GetVida()
    {
        return vida;
    }
    public void SetVida(int _vida)
    {
        vida = _vida;
        vidaText.text = vida.ToString();
    }
    public void PoneDanio(int danio)
    {
        golpe.PintaDanio(danio);
    }
   
}
