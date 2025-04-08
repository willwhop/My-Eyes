using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavStartUp : MonoBehaviour
{
    public NavMeshSurface nav;
    // Start is called before the first frame update
    void Start()
    {
        nav.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
