using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ametralladora : Arma
{
    public Transform posDisparo;
    public Transform posCaquillo;

    public LayerMask layerMask;

    public Control_Impactos control_Impactos;
    public Animator animator;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Dispara()
    {
        animator.SetTrigger("Dispara");
        audioSource.PlayOneShot(dataArma.sonidoDisparo);
    }
    public override void Recarga()
    {
        animator.SetTrigger("Recarga");
        audioSource.PlayOneShot(dataArma.sonidoRecarga);
    }
    public void CreaCasquillo()
    {
        print("Casquillo");
        //Crear un casquillo,  posCaquillo, rotacioncasquillo -> propio casquillo
        GameObject clonCasquillo = Instantiate(dataArma.casquillo, posCaquillo.position, dataArma.casquillo.transform.rotation);
        clonCasquillo.GetComponent<Rigidbody>().AddForce((posCaquillo.right) * dataArma.fuerzaCasquillo, ForceMode.Impulse);
        clonCasquillo.GetComponent<Rigidbody>().AddRelativeTorque(Random.Range(200, 500), 20, Random.Range(200, 800));
    }
}
