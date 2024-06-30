using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public static GameControllerScript instance = null;

    public int currentLevel = 0;

    public int robotsLeft = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartLevel() {
        robotsLeft--;
        if (robotsLeft > 0) {
            SceneManager.LoadScene(currentLevel);
        } else {
            currentLevel = 0;
            robotsLeft = 3;
            SceneManager.LoadScene(currentLevel);
        }
    }

    public void levelSucceeded() {
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    }
}
