using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Control_Armas : MonoBehaviour
{
    //Me centro en q sea un Arma sin importar el tipo
    public Arma armaActual;
    //Cambios de arma, todas las armas son Arma
    public List<Arma> Armas;
    int indiceArma = 0;
    public GameObject hub_sniper;

    // Start is called before the first frame update
    void Start()
    {
        armaActual = Armas[indiceArma];
        //desactivo todas
        foreach (Arma a in Armas)
        {
            a.gameObject.SetActive(false);
        }
        //activa el arma principal
        armaActual.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnFire()
    {
        if (!enabled)
        {
            return;
        }
        //
        armaActual.Dispara();
       
    }
    public void OnRecarga()
    {
        if (!enabled)
        {
            return;
        }
        //
        armaActual.Recarga();
    }

    public void OnApuntarPress()
    {
        StopAllCoroutines();
        StartCoroutine(MueveArmaApunta());
    }
    public void OnApuntarRelease()
    {

        StopAllCoroutines();
        StartCoroutine(MueveArmaInicial());
    }
    void CambiaArma(float mouseWheel)
    {
        //Ahora seria el colt
       
        if (mouseWheel > 0)
        {
            indiceArma++;
            //controlar los limites de la matriz o lista
            if(indiceArma> Armas.Count-1)
            {
                indiceArma = 0;
            }
            print("Para arriba");
        }else if (mouseWheel < 0)
        {
            indiceArma--;
            //controlar el limite de la matriz
            if (indiceArma < 0)
            {
                indiceArma = Armas.Count - 1;
            }
            print("Para abajo");
        }
        armaActual = Armas[indiceArma];
        //desactivo todas
        foreach (Arma a in Armas)
        {
            a.gameObject.SetActive(false);
        }
        //activa el arma principal
        armaActual.gameObject.SetActive(true);
    }
    public void OnCambiaArma(InputValue value)
    {
        if (!enabled)
        {
            return;
        }
        //
       // print(value.Get());
        CambiaArma((float)value.Get());
       
     
    }

    IEnumerator MueveArmaApunta()
    {
        float t = 0;
        for (int i = 0; i < 50; i++)
        {
            t += 0.02f;
            armaActual.transform.localPosition = Vector3.Lerp(armaActual.transform.localPosition, armaActual.dataArma.posApuntar, t);
           //Forma de controlar excepcion
            if (armaActual.dataArma.tipoArma == DataArma.TipoArma.francotirador)
            {
                hub_sniper.SetActive(true);
                hub_sniper.GetComponent<CanvasGroup>().alpha = t*2;
            }
            
            yield return null;
        }
   
    }
    IEnumerator MueveArmaInicial()
    {
        float t = 0;
        for (int i = 0; i < 50; i++)
        {
            t += 0.02f;
            armaActual.transform.localPosition = Vector3.Lerp(armaActual.dataArma.posApuntar, armaActual.dataArma.posInicial, t);
            if (armaActual is Francotirador)
            {
                hub_sniper.SetActive(true);
                hub_sniper.GetComponent<CanvasGroup>().alpha = 1-(t*2);
            }
            yield return null;
        }
        hub_sniper.SetActive(false);

    }
}
