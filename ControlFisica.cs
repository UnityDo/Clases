using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFisica : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mismil;
    public float fuerza;
    void Start()
    {
        Physics.autoSimulation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DibujaFisica()
    {
      GameObject clon_misil=  Instantiate(mismil, transform);
        clon_misil.GetComponent<Rigidbody>().AddForce(mismil.transform.forward* fuerza, ForceMode.Impulse);
      float Tiempo = 0;
        for (int i = 0; i < 200; i++)
        {
            Physics.Simulate(Tiempo);
            Tiempo += 0.01f;
          GameObject sphere=  GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(.2f, .2f, .2f);
            Destroy(sphere.GetComponent<Collider>());
            sphere.transform.position = clon_misil.transform.position;
            yield return new WaitForSeconds(.2f);
        }
        
    }
    public void VisualizaFisicaEnTiempo(float tiempo)
    {
        GameObject clon_misil = Instantiate(mismil, transform);
        clon_misil.GetComponent<Rigidbody>().AddForce(mismil.transform.forward * fuerza, ForceMode.Impulse);
        float Tiempo = 0;
        while (Tiempo < tiempo )
        {
          
            Physics.Simulate(Tiempo);
            Tiempo += Time.fixedDeltaTime;


            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(.2f, .2f, .2f);
            Destroy(sphere.GetComponent<Collider>());
            sphere.transform.position = clon_misil.transform.position;
        }
      
      
           
        
    }

    public void FisicaPrevia()
    {
        //StartCoroutine(DibujaFisica());
        VisualizaFisicaEnTiempo(3f);
    }
}
