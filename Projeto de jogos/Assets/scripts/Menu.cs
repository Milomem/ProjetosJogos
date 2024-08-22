using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void Jogar(){
        SceneManager.LoadScene("Fase1");
    }

    public void Config(){
        SceneManager.LoadScene("menuConfig");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
