using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded;
    [SerializeField] public GameOver gameOver; 
    private void Start()
    {
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
