using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //TEST
    public List<CartaHearstone> CartasPosiblesPc;

    public CartaHearstone cartaElegidaJugador;
    public CartaHearstone cartaEnfretadaPc;

    //Para los heroes
    public Heroe HeroeJugador;
    public Heroe HeroePc;


    //Pinta gemas
    public ContadorGemas contadorGemasJugador, contadorGemasPc;
    int gemasInicialesJugador=0, gemasActualesJugador, gemasInicialesPc=0, gemasActualesPc, gemasMaxJugador,gemasMaxPc=0;

    //Donde construyo y que construyo
    public Transform panelGemas;
    public Gema gema;
     List<Gema> Gemas=new List<Gema>();

    //Para las fases
    public GestionTurno gestionTurno;

    public GameObject turnoImagen;
    public Button botonTurno;
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
        gestionTurno.CambiaFase(GestionTurno.Fases.Presentacion);
        StartCoroutine(gestionTurno.EnFase());
        //Para pruebas
        gemasActualesJugador = 9;
        gemasMaxJugador = 9;
        for (int i = 0; i < 9; i++)
        {
            CreaGemas();
        }
        CreaCartaJugador();
        CreaCartaJugador();
        CreaCartaJugador();
        // gemasActualesJugador = gemasInicialesJugador;
        gemasActualesPc = gemasInicialesPc;
        //pintar las gemas
        contadorGemasJugador.PintaGemas(gemasActualesJugador, gemasMaxJugador);
        contadorGemasPc.PintaGemas(gemasActualesPc, gemasMaxPc);
        
        //En los turnos
         //CreaGemas();
        //cuando usa carta
        //UsaGemas(10);
        //contadorGemasJugador.PintaGemas(0, gemasMax);
        //StartCoroutine(Construcion());
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

        //Solo se puede hacer si tiene suficiente mana
        if (cartaHearstone.GetCoste() <= gemasActualesJugador)
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

            //Quitamos el mana
            gemasActualesJugador -= cartaHearstone.GetCoste();
            contadorGemasJugador.PintaGemas(gemasActualesJugador, gemasMaxJugador);
            UsaGemas(cartaHearstone.GetCoste());
        }
      

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
       // CreaCartaPc();
       // PasaMesaCartaPc(CartasEnManoPc[0]);



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
                print(cartaEnfretadaPc.GetAtaque());
                //Una condicion de perdida
                if (HeroeJugador.GetVida() <= 0)
                {
                    //Muere y pierde
                    print("Ha perdido");
                }
            }
        }

    }
    
    public void CreaGemas()
    {
        //Construye las gemas basadas en el numero de gemas
        Gema clongema = Instantiate(gema, panelGemas);
        Gemas.Add(clongema);

    }
    public void UsaGemas(int gemasUsadas)
    {
        print(Gemas.Count - gemasUsadas);
       List<Gema> GemasUsadas= Gemas.GetRange(Gemas.Count  - gemasUsadas, gemasUsadas);
        //las gemas usadas se ven como usadas
        foreach(Gema g in GemasUsadas)
        {
            g.CambiaUsa();
            g.Usa();
        }
    }
    public void Presentacion()
    {

        StartCoroutine(PresentacionCoroutine());
    }
    IEnumerator PresentacionCoroutine()
    {
    
        botonTurno.interactable = false;
        turnoImagen.SetActive(true);
        yield return new WaitForSeconds(2);
        turnoImagen.SetActive(false);
        botonTurno.interactable = true;
    }
    public void TurnoJugador()
    {
        StartCoroutine(TurnoJugadorCoroutine());
    }
    IEnumerator TurnoJugadorCoroutine()
    {
        if (gemasMaxJugador <= 10)
        {
            gemasMaxJugador++;
            CreaGemas();
            gemasActualesJugador++;
            contadorGemasJugador.PintaGemas(gemasActualesJugador, gemasMaxJugador);
        }
        yield return new WaitForSeconds(1);
        CreaCartaJugador();
    }
    //Cambia el turno se llama desde boton
    public void CambiaTurno()
    {
        gestionTurno.CambiaFase(GestionTurno.Fases.TurnoPc);
    }
   public void TurnoPc()
    {
        StartCoroutine(TurnoPcCoroutine());
    }
    IEnumerator TurnoPcCoroutine()
    {
        //se le da una gema
        if (gemasMaxPc <= 10)
        {
            gemasMaxPc++;
            gemasActualesPc++;
            contadorGemasPc.PintaGemas(gemasActualesPc, gemasMaxPc);
        }
        yield return new WaitForSeconds(1);
        //Saca una carta y la añade a la mano
        CreaCartaPc();
      
        yield return new WaitForSeconds(1);
        //Elegir una carta para pasar a la mesa del Pc
        //Solo puede pasar las que tenga mana para hacerlo
        //Elige una carta cuyo coste es inferior a las gemas que tengo
        List<CartaHearstone> CartasPosibles = CartasEnManoPc.FindAll(x => x.GetCoste() <= gemasActualesPc);
        //Saca cartas hasta agotar el mana
        //De las posibles decide que carta, de momento aleatorio
       cartaEnfretadaPc= CartasPosibles[UnityEngine.Random.Range(0, CartasPosibles.Count)];
        //Pasar a la mesa
        PasaMesaCartaPc(cartaEnfretadaPc);
        //TODO Ese primer turno no ataca, salvo las q tienen cargar
        //Va a atacar directamente
        //Decisiones de ataque
        //Dedice que carta de la mesa es la que ataca
        cartaEnfretadaPc = CartasEnMesaPc[UnityEngine.Random.Range(0, CartasPosibles.Count)];
        //1 si el jugador no tiene cartas en la mesa, va a la cabeza
       if (CartasEnMesaJugador.Count == 0)
        {
            AtacaCabezaEnemigo();
        }
        else
        {
            //Puede atacar al jugador o puede atacar a una criatura
            //TODO si no hay cartas con provocar
            //hay alguna carta que tenga provocar
           if(CartasEnMesaJugador.Exists(x => x.dataHearstoneCarta.poder == Poder.Provocar))
            {
                //no puedo ir a la cabeza
            }
            //El 70% ataca a la cabeza
            if (UnityEngine.Random.Range(0, 100) > 200)
            {
                AtacaCabezaEnemigo();
            }
            else
            {
                List<CartaHearstone> CartasPosiblesAtaque = new List<CartaHearstone>();
                for (int i = 0; i < CartasEnMesaPc.Count; i++)
                {
                    CartasPosiblesAtaque.Add( CartasEnMesaJugador.Find(x => x.GetVida() <= CartasEnMesaPc[i].GetAtaque()));
                }
                if (CartasPosiblesAtaque.Count == 0)
                {
                    cartaEnfretadaPc = CartasEnMesaPc[UnityEngine.Random.Range(0, CartasEnManoPc.Count)];
                    cartaElegidaJugador= CartasEnMesaJugador[UnityEngine.Random.Range(0, CartasEnMesaJugador.Count)];
                }
                else
                {
                    //Elegir la que tenga mas ataque
                    //Ordenar una lista por un criterio
                    
                    //CartasPosiblesAtaque.Sort(ComparaPorAtaque);
                    cartaEnfretadaPc = CartasPosiblesAtaque[0];
                    cartaElegidaJugador = CartasEnMesaJugador[UnityEngine.Random.Range(0, CartasEnMesaJugador.Count)];

                }
                ResuelveEncuentro();
                
            }

        }
    }
    public int ComparaPorAtaque(CartaHearstone a, CartaHearstone b)
    {
        //analizar casos nulos
        if((a==null)&&(b==null))
        {
            return 0;
        }
        if(a==null&&b!=null)
        {
            return -1;
        }else if(a!=null&&b==null)
        {
            return 1;
        }
        
        
        
        if (a.GetAtaque() > b.GetAtaque())
        {
            return 1;
        }
        else
        {
            if (a.GetAtaque() == b.GetAtaque())
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }
    }

}
