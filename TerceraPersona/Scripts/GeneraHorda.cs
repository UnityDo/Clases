using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneraHorda : MonoBehaviour
{
    public GameObject enemigo;
    public List<Stats_Enemigo> stats_Enemigos;
    // Start is called before the first frame update
    public float range = 10.0f;
    public int numeroEnemigos;

   
    void Start()
    {
        for (int i = 0; i < numeroEnemigos; i++)
        {
            ConstruyeEnemigo();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    void ConstruyeEnemigo()
    {
        if(RandomPoint(transform.position,10,out Vector3 posicionEnemigo)){
            GameObject Clon_Enemigo = Instantiate(enemigo, posicionEnemigo, transform.rotation);
            if (Clon_Enemigo.TryGetComponent(out Goblin goblinClase))
            {
                goblinClase.stats_Enemigo = stats_Enemigos[Random.Range(0, stats_Enemigos.Count)];
            }
            else if(Clon_Enemigo.TryGetComponent(out Skeleton skeletonClase))
            {
                skeletonClase.stats_Enemigo = stats_Enemigos[Random.Range(0, stats_Enemigos.Count)];
            }
           
        }
       
    }
}
