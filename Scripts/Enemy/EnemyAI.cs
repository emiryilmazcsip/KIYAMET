using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = System.Object;

public class EnemyAI : MonoBehaviour
{
    private EnemyAggro enemyAggro;
    private Transform playersTransform;
    private NavMeshAgent enemyNavMeshAgent;

    private void Start()
    {
        enemyAggro = GetComponent<EnemyAggro>();
        playersTransform = FindObjectOfType<PlayerMove>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(enemyAggro.isAggro)
        {
            enemyNavMeshAgent.SetDestination(playersTransform.position);
        }
        else
        {
            enemyNavMeshAgent.SetDestination(transform.position);
        }

    }
}
