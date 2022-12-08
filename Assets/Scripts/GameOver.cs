using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    public void Setup()
    {
        gameObject.SetActive(true);
    }


    public void restartButton()
    {
        SceneManager.LoadScene("BigArena1");
    }

    public void exitButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    // Update is called once per frame
    public void Update()
    {
        
    }
}
