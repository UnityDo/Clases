using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quiero que enemigo se pueda dañar, le doy la propiedad de Daniable
public class Enemigo : MonoBehaviour, IDaniable,IQuemable
{
    public float vida;

    MeshRenderer renderer;

    bool seQuema = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    //El interface IDaniable permite tener una definicion diferente en cada clase
    public void RecibeDanio(float danio)
    {
        vida -= danio;
        if (vida <= 0)
        {
            print("Estas muerto");
        }
    }

    public void Quemo(float danioFuego)
    {
        RecibeDanio(danioFuego);
        print("Crear particulas de fuego");
        //Coger desde Resources
        if (!seQuema)
        {
            GameObject particulasFuego = Instantiate(Resources.Load("TinyFlames2"), transform) as GameObject;
            ParticleSystem.ShapeModule shapeModule = new ParticleSystem.ShapeModule();
            shapeModule = particulasFuego.GetComponent<ParticleSystem>().shape;
            shapeModule.meshRenderer = renderer;

            particulasFuego.GetComponent<ParticleSystem>().Play();
            seQuema = true;
        }
    }
}
