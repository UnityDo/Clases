using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ControlRigidbody2D : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float fuerza;
    public float valorGiro;
    public enum TiposFuerza { Impulso,FuerzaDirecta,FuerzaRelativa,FuerzaPunto,Giro}
    public TiposFuerza tiposFuerza;
    public Transform puntoRelativo;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        switch (tiposFuerza)
        {
            case TiposFuerza.Impulso:
                FuerzaImpulso();
                break;
            case TiposFuerza.FuerzaDirecta:
                FuerzaDirecta();
                break;
            case TiposFuerza.FuerzaRelativa:
                FuerzaRelativa();
                break;
            case TiposFuerza.FuerzaPunto:
                FuerzaPunto();
                break;
            case TiposFuerza.Giro:
                Giro();
                break;
        } 
    }

        // Update is called once per frame
        void Update()
    {
        
    }
    public void FuerzaImpulso()
    {
        rigidbody2D.AddForce(Vector2.right*fuerza, ForceMode2D.Impulse);
       
    }
    public void FuerzaDirecta()
    {
        rigidbody2D.AddForce(Vector2.right * fuerza, ForceMode2D.Force);

    }
    public void FuerzaRelativa()
    {
        rigidbody2D.AddRelativeForce(Vector2.right * fuerza, ForceMode2D.Impulse);

    }
    public void FuerzaPunto()
    {
        rigidbody2D.AddForceAtPosition(Vector2.right * fuerza,puntoRelativo.position,ForceMode2D.Impulse);
    }
    public void Giro()
    {
        rigidbody2D.AddTorque(valorGiro);
    }
}