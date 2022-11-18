using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public GameObject Thor;
    private Collider ThorCollider;
    private Collider Blackness;
    // Start is called before the first frame update
    void Start()
    {
        Blackness = GetComponent<Collider>();
        ThorCollider = Thor.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
