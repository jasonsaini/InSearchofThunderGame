using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemy : MonoBehaviour
{
    public GameObject tryText;
    [SerializeField] public GameObject enemy;

    private void OnCollisionEnter(Collision collision) {
        showInfoAndSpawn();
    }

    private void showInfoAndSpawn()
    {
        tryText.SetActive(true);
        enemy.SetActive(true);
        //Destroy(false);
    }
}
