using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTurno : MonoBehaviour
{
    public enum Fases { Presentacion,TurnoJugador,TurnoPc,Final,EnJuego }
    public Fases fase;
    bool EnJuego = true;
   
    // Start is called before the first frame update

    public void CambiaFase(Fases fase)
    {
        this.fase = fase;
        
      
    }
    public IEnumerator EnFase()
    {
      while (EnJuego) { 
        switch (fase)
        {
            case Fases.Presentacion:
                print("Presentacion");
                    Hearstone.instancia.Presentacion();
                yield return new WaitForSeconds(3);
                    CambiaFase(Fases.TurnoJugador);
                break;
            case Fases.TurnoJugador:
                print("Turno jugador");
                    Hearstone.instancia.TurnoJugador();
                    yield return new WaitForSeconds(1);
                    CambiaFase(Fases.EnJuego);
                    //salta el turno del jugador
                break;
            case Fases.TurnoPc:
                print("Turno pc");
                    //salta el turno del pc
                    Hearstone.instancia.TurnoPc();
                    yield return new WaitForSeconds(5);
                break;
            case Fases.Final:
                print("final");
                yield return new WaitForSeconds(1);
                break;
            case Fases.EnJuego:
                print("en juego");
                yield return new WaitForSeconds(1);
                break;
        }

    }
    }
}