using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golpe : MonoBehaviour
{
    public Image golpe;
    public TMPro.TextMeshProUGUI danioText;
    // Start is called before the first frame update
  
    public void PintaDanio(int danio)
    {
        golpe.gameObject.SetActive(true);
        danioText.text = danio.ToString();
    }
}
