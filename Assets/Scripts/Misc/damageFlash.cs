using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageFlash : MonoBehaviour
{

    MeshRenderer mRenderer;
    Color origColor;
    float flashTime = .15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        FlashStart();
    }
    void FlashStart()
    {
        mRenderer.material.color = Color.red;
    
    }
}
