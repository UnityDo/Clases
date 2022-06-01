using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoderes : MonoBehaviour
{
    public Poder poder1, poder2, poder3;
    Poder poderactual;
    // Start is called before the first frame update
    void Start()
    {
        Control_UI.instancia.magia_UI.PoneSpriteMagia1(poder1.iconoPoder);
        Control_UI.instancia.magia_UI.PoneSpriteMagia2(poder2.iconoPoder);
        poderactual = poder2;
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
    public Poder GetPoderActual()
    {
        return poderactual;
    }
    //TODO para testear
    public void CambiaPoder(int indice)
    {
        
        switch (indice)
        {
            case 0:
                poderactual = poder1;
                break;
            case 1:
                poderactual = poder2;
                break;
            case 2:
                poderactual = poder3;
                Control_UI.instancia.magia_UI.PoneSpriteMagia2(poder3.iconoPoder);
                break;
        }
    
    }
    public void BolaDeFuego(GameObject particulasFuego, float danio, Magia.TipoMagia _tipoMagia)
    {
        //Instancia la bola
        GameObject clonBola = Instantiate(particulasFuego, GameController.instancia.playerController.posicionMagia.position, GameController.instancia.playerController.transform.rotation);
        if(clonBola.TryGetComponent(out Control_Danio control_Danio))
        {
            //inyectamos el danio al control de Danio
            control_Danio.SetDanio(danio);
            control_Danio.SetTipoMagia(_tipoMagia);
        }
        //la lanza desde la posicion del jugador hacia delante
        //  Time.timeScale = 0;
       // Debug.Break();
    }
    public void RayoHielo(GameObject particulasHielo, float danio)
    {
        GameObject clonBola = Instantiate(particulasHielo, GameController.instancia.playerController.posicionMagia.position, GameController.instancia.playerController.transform.rotation);
        if (clonBola.TryGetComponent(out Control_Danio control_Danio))
        {
            //inyectamos el danio al control de Danio
            control_Danio.SetDanio(danio);
        }
    }
    public void MagiaGenerica(Poder poder)
    {
        if(poder.GetType()==typeof(BolaFuego))
        {
            print("Soy una bola de fuego" + poder.Nombre);
        }
        else if(poder.GetType() == typeof(RayoHielo))
        {
            print("Soy una rayo de hielo" + poder.Nombre);
        }
    }
    public void ZonaVeneno(ZonaVeneno zonaVeneno)
    {
        GameObject ZonaVeneno = Instantiate(zonaVeneno.zonaVenenoObjeto, GameController.instancia.playerController.posicionMagia.position+ zonaVeneno.offPosicion, GameController.instancia.playerController.transform.rotation);
        if (ZonaVeneno.TryGetComponent(out Control_Danio control_Danio))
        {
            //inyectamos el danio al control de Danio
            control_Danio.SetDanio(zonaVeneno.danio);
            control_Danio.SetTipoMagia(zonaVeneno.tipoMagia);
        }

    }
}
