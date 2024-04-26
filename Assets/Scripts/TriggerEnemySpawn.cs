using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemySpawn : MonoBehaviour
{
    public GameObject enemy; // Reference to the script you want to activate

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            enemy.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}