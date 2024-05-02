using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour //enemy aggro script. This script will make the enemy aggressive when near and when gunshots are heard.
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
            GetComponent<MeshRenderer>().material = aggroMat; //this was for testing and debugging without a sprite.
        }
    }
}
