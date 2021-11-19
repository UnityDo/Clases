using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearstone : MonoBehaviour
{
    //Patron singleton
    //1 Se define una copia de la propia clase como static
    public static Hearstone instancia = null;

    public BarajaH MazoJugador,MazoPc;
    //Donde se crea
    public Transform ManoJugadorPanel,ManoPcPanel,MesaJugadorPanel,MesaPcPanel;
    //La carta base
    public CartaHearstone cartaHearstone;
    //solo para visualizarlo
    public List<CartaHearstone> CartasEnManoJugador;
    public List<CartaHearstone> CartasEnManoPc;
    public List<CartaHearstone> CartasEnMesaJugador;
    public List<CartaHearstone> CartasEnMesaPc;
    int limiteCartasMesa = 8;
    //Almacenar la carta que ha elegido el jugador
    
    public CartaHearstone cartaElegidaJugador;
    public CartaHearstone cartaEnfretadaPc;

    //Para los heroes
    public Heroe HeroeJugador;
    public Heroe HeroePc;
  

    //2 del patron singleton 
    //rellenar la instancia
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        StartCoroutine(Construcion());
    }

    private void CreaCartaJugador()
    {
        //sacar una carta de la baraja
        DataHearstoneCarta cartaSacada = MazoJugador.SacaCarta();
        //pasarle esa carta a cartaHearstone
        cartaHearstone.dataHearstoneCarta = cartaSacada;
        //crear la carta en la manojugador
      CartaHearstone cartaCreada=  Instantiate(cartaHearstone, ManoJugadorPanel);
        cartaCreada.name = cartaSacada.nombre;
        cartaCreada.tipoJugador = TipoJugador.Jugador;
        CartasEnManoJugador.Add(cartaCreada);

    }
    public void CreaCartaPc()
    {
        //sacar una carta de la baraja
        DataHearstoneCarta cartaSacada = MazoPc.SacaCarta();
        //pasarle esa carta a cartaHearstone
        cartaHearstone.dataHearstoneCarta = cartaSacada;
        //crear la carta en la manojugador
        CartaHearstone cartaCreada=   Instantiate(cartaHearstone, ManoPcPanel);
        cartaCreada.name = cartaSacada.nombre;
        cartaCreada.tipoJugador = TipoJugador.Pc;
        CartasEnManoPc.Add(cartaCreada);

    }

    public void ResuelveEncuentro()
    {
        if (cartaElegidaJugador != null && cartaEnfretadaPc != null)
        {
            //ataca el jugador
            int vidaResultadoPc = cartaEnfretadaPc.GetVida() - cartaElegidaJugador.GetAtaque();
            int vidaResultadoJugador = cartaElegidaJugador.GetVida() - cartaEnfretadaPc.GetAtaque();
            //modificamos la vida de la carta jugador y de la carta pc
            cartaEnfretadaPc.SetVida(vidaResultadoPc);
            cartaEnfretadaPc.PoneDanio(cartaElegidaJugador.GetAtaque());
            cartaElegidaJugador.SetVida(vidaResultadoJugador);
            cartaElegidaJugador.PoneDanio(cartaEnfretadaPc.GetAtaque());
            //Si la vida la carta es 0 o menos se destruye
            if (cartaElegidaJugador.GetVida() <= 0)
            {
                Destroy(cartaElegidaJugador.gameObject);
                //Quitar de la mesa del jugador
                CartasEnMesaJugador.Remove(cartaElegidaJugador);
            }
       
            if (cartaEnfretadaPc.GetVida() <= 0)
            {
                Destroy(cartaEnfretadaPc.gameObject);
                //Quitar de la mesa del pc
                CartasEnMesaPc.Remove(cartaEnfretadaPc);
            }
           
        }
    }

    public void PasaMesaCartaJugador(CartaHearstone cartaHearstone)
    {
       
        //Crea en la mesa del jugador
        //Creamos otra carta en la mesa
        CartaHearstone cartaCreada = Instantiate(cartaHearstone, MesaJugadorPanel);
        //A�adirla a la lista de la mesa
        CartasEnMesaJugador.Add(cartaCreada);

        //Eliminarse de la mano del jugador
        Destroy(cartaHearstone.gameObject);
        //Visualmente
        //De la lista de cartas del jugador
        CartasEnManoJugador.Remove(cartaHearstone);

    }
    public void PasaMesaCartaPc(CartaHearstone cartaHearstone)
    {
       
        CartaHearstone cartaCreada = Instantiate(cartaHearstone, MesaPcPanel);

        CartasEnMesaPc.Add(cartaCreada);

     
        Destroy(cartaHearstone.gameObject);
  
        CartasEnManoPc.Remove(cartaHearstone);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Construcion()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < 10; i++)
        {
            CreaCartaJugador();
        }
        CreaCartaPc();
        PasaMesaCartaPc(CartasEnManoPc[0]);



    }
    public void LlamaAControl()
    {
        print("Llama a control");
    }
    //Boton mesa jugador
    //La carta seleccionada la pasa a mesa
    public void PasaAMesa()
    {
        //como puede no haber seleccionado ninguna
        if (cartaElegidaJugador != null&& CartasEnMesaJugador.Count< limiteCartasMesa)
        {
            PasaMesaCartaJugador(cartaElegidaJugador);
        }
    }
    //Ataca a cabeza se llama desde boton
    public void AtacaCabeza()
    {
        if (cartaElegidaJugador != null)
        {
            //que la carta esta en la mesa
           if(CartasEnMesaJugador.Contains(cartaElegidaJugador))
            {
                //Resuelve
                //Quien hace el daño cartaElegidaJugador
                //A quien se lo hace, es al enemigo
                HeroePc.SetVida(HeroePc.GetVida() - cartaElegidaJugador.GetAtaque());
                HeroePc.PoneDanio(cartaElegidaJugador.GetAtaque());
                //Una condicion de perdida
                if (HeroePc.GetVida() <= 0)
                {
                    //Muere y pierde
                    print("Ha perdido");
                }
            }
        }
    }
    public void AtacaCabezaEnemigo()
    {
        if (cartaEnfretadaPc != null)
        {
            //que la carta esta en la mesa
            if (CartasEnMesaPc.Contains(cartaEnfretadaPc))
            {
                //Resuelve
                //Quien hace el daño cartaElegidaJugador
                //A quien se lo hace, es al enemigo
                HeroeJugador.SetVida(HeroeJugador.GetVida() - cartaEnfretadaPc.GetAtaque());
                HeroeJugador.PoneDanio(cartaEnfretadaPc.GetAtaque());
                //Una condicion de perdida
                if (HeroeJugador.GetVida() <= 0)
                {
                    //Muere y pierde
                    print("Ha perdido");
                }
            }
        }

    }


 
    
}
