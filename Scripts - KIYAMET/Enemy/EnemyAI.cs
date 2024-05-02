using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = System.Object;

public class EnemyAI : MonoBehaviour //enemy ai behavior and how they can move to update on set destination of the player.
{
    private EnemyAggro enemyAggro;
    private Transform playersTransform;
    private NavMeshAgent enemyNavMeshAgent;

    private void Start() //Starting and finding the scripts to interact with.
    {
        enemyAggro = GetComponent<EnemyAggro>();
        playersTransform = FindObjectOfType<PlayerMove>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() //Updating for enemy and making enemy agressive.
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
