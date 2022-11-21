using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTrap : MonoBehaviour
{
    GameObject lightningTrap;
    BigBad bigBad;
    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        lightningTrap = GameObject.Find("LightningTrap");
        lightningTrap.SetActive(false);
        bigBad = GameObject.Find("BigBad").GetComponent<BigBad>();
    }

    private void Update()
    {
        if(audioData.time > 2f)
        {
            audioData.Stop();
        }
    }

    void onCollisionEnter(Collider other)
    {
        if(other.CompareTag("BigBad"))
        {
            Debug.Log("Trap hit biggie!");
            bigBad.animator.SetTrigger("Idle");
            Invoke("SetTrapTime", 3f);
            audioData.Play(0);
            Destroy(this);
        }    

    }

    private void SetTrapTime()
    {
        Debug.Log("Trap triggered!");
        bigBad.trapped = true;
    }
}
