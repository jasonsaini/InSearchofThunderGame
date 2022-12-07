using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : StateMachineBehaviour
{
    GameManager manager;
    GameObject gameOverScreen;
    GameOver gameOver;
   private void OnEnable()
   {
        manager = FindObjectOfType<GameManager>();
        gameOverScreen =  GameObject.FindWithTag("GameOver");
        gameOver = gameOverScreen.GetComponent<GameOver>();
    }
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            Destroy(animator.gameObject, stateInfo.length);
            gameOver.Setup();
    }
}
