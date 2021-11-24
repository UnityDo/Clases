using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorGemas : MonoBehaviour
{
    public TMPro.TextMeshProUGUI gemasText;
    // Start is called before the first frame update
    void Start()
    {
        //PintaGemas(10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PintaGemas(int gemas, int maxgemas)
    {
        gemasText.text = gemas.ToString() + "/" + maxgemas;
    }
}
