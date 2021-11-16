using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baraja : MonoBehaviour
{
    public List<Carta> Cartas = new List<Carta>();
    public Sprite[] CartasSprites;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ConstruyeBaraja()
    {
       
        Cartas.Add ( new Carta(1, "As de Oros", CartasSprites[0], Carta.Palos.Oros, false));
        Cartas.Add(new Carta(2, "Dos de Oros", CartasSprites[1], Carta.Palos.Oros, false));
      Cartas.Add ( new Carta(3, "Tres de Oros", CartasSprites[2], Carta.Palos.Oros, false));
      Cartas.Add ( new Carta(4, "Cuatro de Oros", CartasSprites[3], Carta.Palos.Oros, false));
      Cartas.Add ( new Carta(5, "Cinco de Oros", CartasSprites[4], Carta.Palos.Oros, false));
      Cartas.Add ( new Carta(6, "Seis de Oros", CartasSprites[5], Carta.Palos.Oros, false));
      Cartas.Add ( new Carta(7, "Siete de Oros", CartasSprites[6], Carta.Palos.Oros, false));
      Cartas.Add ( new Carta(8, "Sota de Oros", CartasSprites[7], Carta.Palos.Oros, true));
      Cartas.Add ( new Carta(9, "Caballo de Oros", CartasSprites[8], Carta.Palos.Oros, true));
        Cartas.Add(new Carta(10, "Rey de Oros", CartasSprites[9], Carta.Palos.Oros, true));

        //Copas
        Cartas.Add ( new Carta(1, "As de Copas", CartasSprites[10], Carta.Palos.Copas, false));
        Cartas.Add ( new Carta(2, "Dos de Copas", CartasSprites[11], Carta.Palos.Copas, false));
        Cartas.Add ( new Carta(3, "Tres de Copas", CartasSprites[12], Carta.Palos.Copas, false));
        Cartas.Add ( new Carta(4, "Cuatro de Copas", CartasSprites[13], Carta.Palos.Copas, false));
        Cartas.Add ( new Carta(5, "Cinco de Copas", CartasSprites[14], Carta.Palos.Copas, false));
        Cartas.Add ( new Carta(6, "Seis de Copas", CartasSprites[15], Carta.Palos.Copas, false));
        Cartas.Add ( new Carta(7, "Siete de Copas", CartasSprites[16], Carta.Palos.Copas, false));
        Cartas.Add ( new Carta(8, "Sota de Copas", CartasSprites[17], Carta.Palos.Copas, true));
        Cartas.Add ( new Carta(9, "Caballo de Copas", CartasSprites[18], Carta.Palos.Copas, true));
        Cartas.Add ( new Carta(10, "Rey de Copas", CartasSprites[19], Carta.Palos.Copas, true));
       
        Cartas.Add ( new Carta(1, "As de Espadas", CartasSprites[20], Carta.Palos.Espadas, false));
        Cartas.Add ( new Carta(2, "Dos de Espadas", CartasSprites[21], Carta.Palos.Espadas, false));
        Cartas.Add ( new Carta(3, "Tres de Espadas", CartasSprites[22], Carta.Palos.Espadas, false));
        Cartas.Add ( new Carta(4, "Cuatro de Espadas", CartasSprites[23], Carta.Palos.Espadas, false));
        Cartas.Add ( new Carta(5, "Cinco de Espadas", CartasSprites[24], Carta.Palos.Espadas, false));
        Cartas.Add ( new Carta(6, "Seis de Espadas", CartasSprites[25], Carta.Palos.Espadas, false));
        Cartas.Add ( new Carta(7, "Siete de Espadas", CartasSprites[26], Carta.Palos.Espadas, false));
        Cartas.Add ( new Carta(8, "Sota de Espadas", CartasSprites[27], Carta.Palos.Espadas, true));
        Cartas.Add ( new Carta(9, "Caballo de Espadas", CartasSprites[28], Carta.Palos.Espadas, true));
        Cartas.Add ( new Carta(10, "Rey de Espadas", CartasSprites[29], Carta.Palos.Espadas, true));
        
        Cartas.Add ( new Carta(1, "As de Bastos", CartasSprites[30], Carta.Palos.Bastos, false));
        Cartas.Add ( new Carta(2, "Dos de Bastos", CartasSprites[31], Carta.Palos.Bastos, false));
        Cartas.Add ( new Carta(3, "Tres de Bastos", CartasSprites[32], Carta.Palos.Bastos, false));
        Cartas.Add ( new Carta(4, "Cuatro de Bastos", CartasSprites[33], Carta.Palos.Bastos, false));
        Cartas.Add ( new Carta(5, "Cinco de Bastos", CartasSprites[34], Carta.Palos.Bastos, false));
        Cartas.Add ( new Carta(6, "Seis de Bastos", CartasSprites[35], Carta.Palos.Bastos, false));
        Cartas.Add ( new Carta(7, "Siete de Bastos", CartasSprites[36], Carta.Palos.Bastos, false));
        Cartas.Add ( new Carta(8, "Sota de Bastos", CartasSprites[37], Carta.Palos.Bastos, true));
        Cartas.Add ( new Carta(9, "Caballo de Bastos", CartasSprites[38], Carta.Palos.Bastos, true));
        Cartas.Add(new Carta(10, "Rey de Bastos", CartasSprites[39], Carta.Palos.Bastos, true));
    }

    public Carta SacaCarta()
    {
        Carta cartaSacada = null;
        //escoger una carta aleatoria
        int alea = Random.Range(0, Cartas.Count);
        cartaSacada = Cartas[alea];
        //quitaremos de la baraja
        Cartas.Remove(cartaSacada);
        return cartaSacada;
    }
    //encontrar una carta
    public Carta EncuentraCarta(Carta cartaBuscar)
    {
        Carta cartaEncontrada = null;
        if (Cartas.Contains(cartaBuscar))
        {
            cartaEncontrada = cartaBuscar;
        }

        return cartaEncontrada;
    }
}
