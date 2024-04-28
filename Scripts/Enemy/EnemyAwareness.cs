using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    public float awarenessRadius = 8f;
    public bool isAggro;
    public Material aggroMat;
    private Transform playersTransform;

    private void Start()
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playersTransform.position);

        if(dist < awarenessRadius)
        {
            isAggro = true;
        }

        if(isAggro)
        {
            GetComponent<MeshRenderer>().material = aggroMat;
        }
    }
}
