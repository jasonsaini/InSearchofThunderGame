using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    [SerializeField] private GameObject characterScript;
    [SerializeField] private GameObject tutCamera;
    void Start() {
        characterScript.GetComponent<PlayerController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return)){
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable() {
        tutCamera.SetActive(false);
        characterScript.GetComponent<PlayerController>().enabled = true;
    }
}
