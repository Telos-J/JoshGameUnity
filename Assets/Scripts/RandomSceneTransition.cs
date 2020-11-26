using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSceneTransition : MonoBehaviour
{
    public string[] scenesToLoad;
    public PlayerState stateToLoad;
    public Vector2 positionToLoad;
    private int sceneNumber;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            stateToLoad.position = positionToLoad;
            sceneNumber =  Random.Range(0, scenesToLoad.Length);
            
            SceneManager.LoadScene(scenesToLoad[sceneNumber]);
        }
    }
}
