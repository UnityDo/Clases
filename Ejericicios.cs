using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejericicios : MonoBehaviour
{
//Para rebote
 float x, y;
   public float velocidadX,velocidadY;
    float AltoPantalla, AnchoPantalla;
    float anchoSprite,altoSprite;
    float direccionX=1,direccionY = 1;


    bool meVe=false, enRago=false;
    // Start is called before the first frame update
    void Start()
    {
         AltoPantalla = Camera.main.orthographicSize * 2;
        AnchoPantalla = AltoPantalla * Screen.width / Screen.height;
        

        anchoSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        altoSprite = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool EvaluaPar(float numero)
    {
        if (numero % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool PuedeAtacar(){
    //recuerda una funcion que devuelve valor siempre devuelve valor, en cualquier caso
        if(meVe&&enRango){
        //solo es true si los dos son true
            return true;
           }else{
        return false;
        }
    }
     void Rebote(){
        float limiteDer = AnchoPantalla / 2 - anchoSprite / 2;
        float limireIzq = -limiteDer;
        float limiteSup = AltoPantalla / 2 - altoSprite / 2;
        float limiteInf = -limiteSup;

        x += velocidadX*direccionX;
        y += velocidadY*direccionY;

        transform.position = new Vector2(x, y);
        // || or logico me interesa que se cumpla alguno
        if (x >= limiteDer || x<= limireIzq)
        {
            //la primera vez es negativo, positivo,negativo...
            direccionX *= -1;
        }
        if(y>=limiteSup || y <= limiteInf)
        {
            direccionY *= -1;
        }
    }
    
}
