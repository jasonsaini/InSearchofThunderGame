using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public void EndGame()
    {

        if (!gameEnded)
        {
            gameEnded = true;

        }
    }
}
