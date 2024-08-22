using UnityEngine;
using UnityEngine.SceneManagement; 

public class AnyKeyToLoadScene : MonoBehaviour
{
    public string sceneName; 

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}