using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class SieteYMedia : MonoBehaviour
{
    public Baraja baraja;
    public List<Carta> ManoJugador;
    public List<Carta> ManoPc;
    public List<Carta> Mesa;
    public Transform ManoJugadorPanel;
    public AnimationCurve animationCurve;
  
    //El que pinta las cartas
    public PintaCartas PintaCartas;
    int[] Matriz = new int[3];
    // Start is called before the first frame update
    void Start()
    {
        baraja.ConstruyeBaraja();
        ReglaSieteyMedia();
       

        //print("Mano jugador" + GetSumaMano(ManoJugador)) ;
        //print("Mano Pc" + GetSumaMano(ManoPc));
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
    //Use animation curve to make the cards move
    float ContarSietes(List<Carta> mano)
    {
        //cuantos sietes tienes en la mano
        return mano.FindAll(x => x.numero == 7).Count;
    }
    float ContarOros(List<Carta> mano)
    {
        return mano.FindAll(x => x.palo == Carta.Palos.Oros).Count;
    }
    bool SieteDeOros(List<Carta> mano)
    {
        return mano.Exists(x => x.nombre == "Siete de Oros");
    }
    float NumeroDeCartas(List<Carta> mano)
    {
        return mano.Count;
    }

    //Calcular cuanto suman las cartas de una mano
    float GetSumaMano(List<Carta> mano)
    {
        float suma = 0;
        foreach(Carta c in mano)
        {
            suma += c.numero;
        }
        return suma;
    }
    void ReglaSieteyMedia()
    {
        //las figuras valen media 0.5f
        foreach(Carta c in baraja.Cartas)
        {
            if (c.esFigura)
            {
                c.numero = 0.5f;
            }
        }
    }
    //para pasar a la mesa
    public void PasaMesaPc()
    {
        //la primera carta se pasa a la mesa

        //1 Pinto en la mesa
        PintaCartas.PintaCartaMesa(ManoPc[0]);
        Mesa.Add(ManoPc[0]);
        //2 La quito de la mano del pc
        ManoPc.RemoveAt(0);
        //3 La quito del panel de Pc
        PintaCartas.EliminaCartaPc(PintaCartas.CartasImagenPc[0]);
    }
    public void PasaMesaJugador()
    {
        //la primera carta se pasa a la mesa

        //1 Pinto en la mesa
        PintaCartas.PintaCartaMesa(ManoJugador[0]);
        Mesa.Add(ManoJugador[0]);
        //2 La quito de la mano del pc
        ManoJugador.RemoveAt(0);
        //3 La quito del panel de Pc
        PintaCartas.EliminaCartaJugador(PintaCartas.CartasImagenJugador[0]);
    }

    //se llama desde boton
    public void PideCartaJugador()
    {
        Carta cartaJugador = baraja.SacaCarta();
        PintaCartas.PintaCartaJugador(cartaJugador);
        ManoJugador.Add(cartaJugador);

        //El Pc decida que hacer
        DecisionPc();
        
    }

    private void DecisionPc()
    {
        //Perfecta informacion
        //Saber cuanto tiene en la mano el jugador
        float sumaManoJugador = GetSumaMano(ManoJugador);
        float sumaManoPc = GetSumaMano(ManoPc);
        if (sumaManoPc > 7.5f)
        {
            return;
        }

        if (sumaManoPc == 7.5f)
        {
            print("Se planta");
        }
        else
        {
            if (sumaManoJugador == 7)
            {
                if (sumaManoPc == 7)
                {
                    print("Pide otra");
                    PideCartaPc();
                }
            }
            else
            {
                if (sumaManoPc < sumaManoJugador&& sumaManoJugador<7.5f)
                {
                    print("Pide carta");
                    PideCartaPc();
                }
            }
        }
    }

    private void PideCartaPc()
    {
        Carta cartaPc = baraja.SacaCarta();
        PintaCartas.PintaCartaPc(cartaPc);
        ManoPc.Add(cartaPc);
    }
    //se llama desde boton
    public void PlantaJugador()
    {
        VerificaGanador();
    }

    private void VerificaGanador()
    {
        bool pasaJugador = false, pasaPc = false;
        float sumaManoJugador = GetSumaMano(ManoJugador);
        float sumaManoPc = GetSumaMano(ManoPc);
        //Comprobar quien gana
        if (sumaManoJugador > 7.5f)
        {
            pasaJugador = true;
        }
        if (sumaManoPc > 7.5f)
        {
            pasaPc = true;
        }
        //si el jugador se pasa y no se pasa el pc , gana el pc
        if (pasaJugador && !pasaPc)
        {
            print("Gana Pc" + sumaManoPc);
        }
        if (!pasaJugador && pasaPc)
        {
            print("Gana Jugador" + sumaManoJugador);
        }
        if (!pasaJugador && !pasaPc)
        {
            if (sumaManoJugador > sumaManoPc)
            {
                print("Gana Jugador" + sumaManoJugador);
            }
            else
            {
                if (sumaManoJugador == sumaManoPc)
                {
                    print("Empata" + sumaManoJugador);
                }
                else
                {
                    print("Gana Pc" + sumaManoPc);
                }
            }
        }
        //si el pc se pasa y no se pasa el jugador, gan el jugador
        //si ninguno se pasa, quien tiene mas
    }
}
