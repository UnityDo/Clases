using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizaEstados : MonoBehaviour
{
    public GameObject bolaEstado;
    public Material materialPatrulla, materialMueve,materialAtaca;
    // Start is called before the first frame update
    void Start()
    {
        CambiaMaterialMueve();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiaMaterialAtaque()
    {
        bolaEstado.GetComponent<Renderer>().material = materialAtaca;
    }
    public void CambiaMaterialPatrulla()
    {
        bolaEstado.GetComponent<Renderer>().material = materialPatrulla;
    }
    public void CambiaMaterialMueve()
    {
        bolaEstado.GetComponent<Renderer>().material = materialMueve;
    }
}
