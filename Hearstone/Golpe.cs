using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golpe : MonoBehaviour
{
    public Image golpe;
    public TMPro.TextMeshProUGUI danioText;
    // Start is called before the first frame update
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PintaDanio(int danio)
    {
        golpe.gameObject.SetActive(true);
        danioText.text = danio.ToString();
    }
    public void AcabaGolpe()
    {
        //Llamar al animator  y cambiar un parametro, q en este caso es un trigger
        animator.SetTrigger("Salida");
        
    }
    public void IniciaGolpe()
    {
        animator.SetTrigger("Entra");
    }
}
