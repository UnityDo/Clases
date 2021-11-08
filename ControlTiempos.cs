using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTiempos : MonoBehaviour
{
    //temporizador
    public float tiempo;
    public float cadaXsegundos;
   
    // Start is called before the first frame update
    void Start()
    {
       // InvocarDespuesDeTiempo("Saludar",2);
       /// InvocarYRepetir("Saludar",2,2);
       // StartCoroutine(SaludarCorutine());
        Coroutine   corutina = StartCoroutine(SaludarCorutine());
       // StopCoroutine(corutina);
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if(tiempo>=cadaXsegundos)
        {
            Saludar();
            tiempo = 0;
        }
    }
     public void InvocarDespuesDeTiempo( string NombreFuncion,float tiempo)
    {
        Invoke(NombreFuncion, tiempo);
    }
    void Saludar()
    {
       print("Hola");
    }
    public void InvocarYRepetir(string NombreFuncion, float tiempo,float cada)
    {
        InvokeRepeating(NombreFuncion, tiempo, cada);
    }
    IEnumerator SaludarCorutine()
    {
        print("Ejeucta 1");
        yield return new WaitForSeconds(2);
        print("Ejecuta 2");
    }
}
