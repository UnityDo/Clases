using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Impactos : MonoBehaviour
{
    //Los impactos
    public GameObject impactoCarne, impactoMetal, impactoPiedra, impactoMadera, impactoArena;
    const string tagCarne = "Carne", tagPiedra = "Piedra", tagMadera = "Madera",tagArena="Arena", tagMetal = "Metal";
    //poner los impactos
    //Recibira donde los pone
    //El tipo de objeto para saber que tipo de impacto pone

    // Start is called before the first frame update
    void Start()
    {
      //  PoneImpacto(new Vector3(12.4379997f, 1.77383351f, 5.30200005f), Quaternion.identity, "Carne", null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PoneImpacto(Vector3 posicionImpacto,Quaternion rotacion, GameObject objeto)
    {
        //Crear un agujero de impacto segun el tag

        switch (objeto.tag)
        {
            case tagCarne:
              GameObject clon_impacto=  Instantiate(impactoCarne, posicionImpacto, rotacion);
                //Para que se mueva con el objeto
                //Emparentar el objeto
                //Dame a mi padre
                clon_impacto.transform.parent = objeto.transform;
          
                break;
            case tagPiedra:
                GameObject clon_impacto2 = Instantiate(impactoPiedra, posicionImpacto, rotacion);
                clon_impacto2.transform.parent = objeto.transform;
                break;
            case tagMadera:
                GameObject clon_impacto3 = Instantiate(impactoMadera, posicionImpacto, rotacion);
                clon_impacto3.transform.parent = objeto.transform;
                break;
            case tagArena:
                GameObject clon_impacto4 = Instantiate(impactoArena, posicionImpacto, rotacion);
                clon_impacto4.transform.parent = objeto.transform;
                break;
            case tagMetal:
                GameObject clon_impacto5 = Instantiate(impactoMetal, posicionImpacto, rotacion);
                clon_impacto5.transform.parent = objeto.transform;
                break;
            default:
                GameObject clon_impacto6 = Instantiate(impactoPiedra, posicionImpacto, rotacion);
                clon_impacto6.transform.parent = objeto.transform;
                break;
        }
           
        
      

    }
}
