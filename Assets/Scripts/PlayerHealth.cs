using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public static int currentHealth = 10;
    public int internalHealth; 
    void Update()
    {
        internalHealth = currentHealth;
        if(currentHealth <= 0){
            ResetHealth();
            SceneManager.LoadScene(2);
        }
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
    }
    public void ResetHealth(){
        currentHealth = 10;
    }
}
