using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveReader : MonoBehaviour
{
    public AnimationCurve curve;
    float tiempoAcumulado = 0;
    Transform posicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial=transform;
   // StartCoroutine(ReadCurve());    
    }

    // Update is called once per frame
    void Update()
    {
        tiempoAcumulado += Time.deltaTime;
        transform.position = new Vector3(curve.Evaluate(tiempoAcumulado), 0, 0);
    }
    IEnumerator ReadCurve()
    {
        for (float i = 0; i < curve.keys[curve.length - 1].time; i += 0.01f)
        {
            Debug.Log(curve.Evaluate(i));
            yield return new WaitForSeconds(0.01f);
            transform.Translate(Vector3.right * curve.Evaluate(i));
            }
    }
    //Create canvas text and set text with the time initial in 0 seconds
    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 10, 100, 100), "Time: " + tiempoAcumulado, style);
    }
}
