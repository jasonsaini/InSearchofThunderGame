using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : StateMachineBehaviour
{
    GameManager manager;
    GameObject gameOverScreen;
    [SerializeField] GameOver gameOver;
    private void OnEnable()
    {
        //gameOver = GameObject.Find("GameOver");
    }
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            Destroy(animator.gameObject, stateInfo.length);
            //gameOver.Setup();
    }
}
