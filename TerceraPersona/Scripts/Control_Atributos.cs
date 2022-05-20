using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Control_Atributos : MonoBehaviour
{
    public TextMeshProUGUI fuerza_n, pericia_n, inteligencia_n, constitucion_n, memoria_n, ingenio_n;
    // Start is called before the first frame update
    public GameObject panelAtributos;

    private void Start()
    {
       
    }
    public void RellenaAtributos(float fuerza,float pericia,float inteligencia,float constistitucion,float memoria,float ingenio)
    {
        fuerza_n.text = fuerza.ToString();
        pericia_n.text = pericia.ToString();
        inteligencia_n.text = inteligencia.ToString();
        constitucion_n.text = constistitucion.ToString();
        memoria_n.text = memoria.ToString();
        ingenio_n.text = ingenio.ToString();

    }
    public void ActivaYDesactivaPanelAtributos(bool activo)
    {
        panelAtributos.SetActive(activo);
    }
  
}
