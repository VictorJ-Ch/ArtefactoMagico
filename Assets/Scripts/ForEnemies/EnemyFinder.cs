using UnityEngine;
using System.Collections.Generic;

public class EnemyFinder : MonoBehaviour
{
    private HashSet<GameObject> enemies = new HashSet<GameObject>();

    private void Start()
    {
        UpdateEnemyList();
    }

    private void UpdateEnemyList()
    {
        enemies.Clear();
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
        }
    }

    private void OnEnable()
    {
        UpdateEnemyList();
    }

    private void Update()
    {
        Debug.Log($"Cantidad de enemigos: {enemies.Count}");
        
        bool needsUpdate = false;
        foreach (var enemy in enemies)
        {
            if (enemy == null)
            {
                needsUpdate = true;
                break;
            }
        }

        if (needsUpdate || enemies.Count < GameObject.FindGameObjectsWithTag("Enemy").Length)
        {
            UpdateEnemyList();
        }
    }
}
