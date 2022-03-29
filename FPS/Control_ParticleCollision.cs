using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_ParticleCollision : MonoBehaviour
{
    public Lanzallamas lanzallamas;
   
    //Se llama cuando una particula colisiona
    private void OnParticleCollision(GameObject other)
    {
       //Como tenemos un interface para dar la propiedad Quemable
       //Comprobamos que tien esa propiedad
       if(other.TryGetComponent(out IQuemable quemable)){
            quemable.Quemo(lanzallamas.dataArma.dano);
        }
    }
 
}
