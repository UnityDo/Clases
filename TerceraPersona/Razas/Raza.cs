using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Razas", menuName = "Razas/Raza", order = 1)]
public class Raza : ScriptableObject
{
    public float FuerzaMod;
    public float ConstitucionMod;
    public float PericiaMod;
    public float InteligenciaMod;
    public float MemoriaMod;
    public float IngenioMod;

    public string nombre;
}
