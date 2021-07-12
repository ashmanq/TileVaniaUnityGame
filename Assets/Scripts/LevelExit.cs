using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] float LevelExitSloMoFactor = 0.2f;
    // Start is called before the first frame update    
    private void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene() {
        Time.timeScale = LevelExitSloMoFactor;
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
