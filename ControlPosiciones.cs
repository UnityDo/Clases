using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPosiciones : MonoBehaviour
{
    //saber las posiciones y colocar al jugador
    public Transform posInicial;
    public Transform camara1;
    public CinemachineVirtualCamera camaraVirtual;

    Transform posInicialCamara;
    private void Start()
    {
        posInicialCamara = camaraVirtual.transform;
        print(camaraVirtual.transform.position);
    }

    //Una funcion que recibe al jugador y lo coloca en la posicionInicial
    public void ReposicionaJugador(GameObject jugador)
    {
        jugador.transform.position = posInicial.position;
        //resetea la posicion de la camara
       

        //si tiene el componente lo guarda en rb
        //sino da false y no guarda nada
        if (jugador.TryGetComponent(out Rigidbody rb))
        {//quitarle la velocidad al jugador
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity=Vector3.zero;
            rb.isKinematic = false;

        }
       
       // camaraVirtual.Follow = null;

        //camaraVirtual.enabled = false;
       // camaraVirtual.transform.position = posInicialCamara.position;
       // camaraVirtual.GetCinemachineComponent<CinemachineTransposer>().
        //transposer.ForceCameraPosition(Vector3.zero, Quaternion.identity);
        // camaraVirtual.transform.SetPositionAndRotation(posInicialCamara.position, posInicialCamara.rotation);
      // camaraVirtual.ForceCameraPosition(posInicialCamara.position, posInicialCamara.rotation);
       // camaraVirtual.enabled = true;
        
        
    }
}
