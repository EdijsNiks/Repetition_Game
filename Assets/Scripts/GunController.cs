using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GunController : MonoBehaviour
{


    [SerializeField] public GameObject gunOnPlayer;
    [SerializeField] public GameObject fakeGun;


    public void Start()
    {
        gunOnPlayer.SetActive(false);
        fakeGun.SetActive(true);
    }
    private void onTriggerStay(Collider other)
    {
    if (other.gameObject.tag == "Player")
    {

        if (Input.GetKey(KeyCode.E))
        {
        Debug.Log("Trigger e is triggered");
        gunOnPlayer.SetActive(true);
        fakeGun.SetActive(false);

        }
    }
    }
}
