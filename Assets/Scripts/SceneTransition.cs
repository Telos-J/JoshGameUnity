using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public PlayerState stateToLoad;
    public Vector2 positionToLoad;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            stateToLoad.position = positionToLoad;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
