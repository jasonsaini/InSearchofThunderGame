using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded;
    GameOver gameOver; 
    private void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
        gameEnded = false;
    }
    public void EndGame()
    {

        if (!gameEnded)
        {
            gameEnded = true;
            gameOver.Setup();
        }
    }
}
