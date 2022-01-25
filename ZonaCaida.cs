using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaCaida : MonoBehaviour
{
    public ControlPosiciones controlPosiciones;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider otro)
    {
        //Controlar quien entra
        if (otro.CompareTag("Player"))
        {
            print("ha entrado el jugador");
            controlPosiciones.ReposicionaJugador(otro.gameObject);
        }
    }
  
}
