using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

    public void AddEnemy(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (enemiesInTrigger.Contains(enemy))
        {
            enemiesInTrigger.Remove(enemy);
            Debug.Log("Enemy removed from the list.");
        }
        else
        {
            Debug.LogWarning("Trying to remove an enemy that is not in the list.");
        }
    }
}
