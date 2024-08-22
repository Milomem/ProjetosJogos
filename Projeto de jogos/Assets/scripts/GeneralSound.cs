using UnityEngine;
using UnityEngine.UI;

public class GeneralSound : MonoBehaviour
{
    private bool isMuted = false;
    private float previousVolume = 1f; // Armazena o volume antes de mutar
    public Button muteButton; // Associe este botão no editor do Unity
    public Sprite speakerOnSprite; // Imagem do speaker sem barra
    public Sprite speakerOffSprite; // Imagem do speaker com barra
    public Slider volumeSlider; // Associe o slider de volume no editor
    private Image buttonImage;

    void Start()
    {
        muteButton.onClick.AddListener(ToggleMute);
        buttonImage = muteButton.GetComponent<Image>();
        buttonImage.sprite = speakerOnSprite;
    }

    void ToggleMute()
    {
        if (isMuted)
        {
            // Desmuta e restaura o volume ao valor do slider
            AudioListener.volume = previousVolume;
            buttonImage.sprite = speakerOnSprite;
            volumeSlider.value = previousVolume; // Atualiza o slider
        }
        else
        {
            // Muta e armazena o volume atual
            previousVolume = AudioListener.volume;
            AudioListener.volume = 0;
            buttonImage.sprite = speakerOffSprite;
        }

        isMuted = !isMuted;
    }
}
