using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Danio : MonoBehaviour
{
    private float danio;
    Magia.TipoMagia tipoMagia;

    private void Start()
    {
       
        
    }
    void OnCollisionEnter(Collision colision)
    {
        print("Soy la colisionde la particuka" + colision.collider.name);
        //Vamos a dañar todo lo que sea dañable
        if (colision.gameObject.TryGetComponent(out IDaniable daniable))
        {
            daniable.RecibeDanio(danio);
        }
        switch (tipoMagia)
        {
            case Magia.TipoMagia.Fuego:
                if (colision.gameObject.TryGetComponent(out IQuemable quemable))
                {
                    quemable.Quema();
                }
                break;
            case Magia.TipoMagia.Hielo:
                break;
            case Magia.TipoMagia.Veneno:
                break;
            case Magia.TipoMagia.Oscuridad:
                break;
                case Magia.TipoMagia.Neutra:

                break;
        } 
    }
    //Crear zonas, donde entre el enemigo, se queme, se congele, se envenene etc
   
    private void OnTriggerStay(Collider other)
    {
        switch (tipoMagia)
        {
            case Magia.TipoMagia.Fuego:
                if (other.gameObject.TryGetComponent(out IQuemable quemable))
                {
                   // quemable.Quema();
                }
                break;
            case Magia.TipoMagia.Hielo:
                break;
            case Magia.TipoMagia.Veneno:
                if (other.gameObject.TryGetComponent(out IEnvenenable envenenable))
                {
                    envenenable.Envenena(danio);
                }
                break;
            case Magia.TipoMagia.Oscuridad:
                break;
            case Magia.TipoMagia.Neutra:

                break;
        }
    }

    public void SetDanio(float _danio){
        danio = _danio;
    }
    public void SetTipoMagia(Magia.TipoMagia _tipoMagia)
    {
        tipoMagia = _tipoMagia;
    }
    //Para pruebas
    [ContextMenu("Cambia Tipo Magia")]
    public void CambiaTipoyDanio()
    {
        tipoMagia = Magia.TipoMagia.Veneno;
        danio = 1;

    }
    
}