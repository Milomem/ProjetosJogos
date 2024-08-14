using UnityEngine;

public class GameExit : MonoBehaviour
{
    void Update()
    {
        // Verifica se o jogador pressionou a tecla de saída (por exemplo, ESC ou QUIT)
        if (Input.GetKeyUp(KeyCode.Escape)) // Pode ser qualquer tecla desejada
        {
            // Sai do jogo
            Application.Quit();
        }
    }
}
