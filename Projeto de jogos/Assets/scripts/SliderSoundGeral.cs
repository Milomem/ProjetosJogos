using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public Image muteButtonImage; // Referência para a imagem do botão de mute
    public Sprite speakerOnSprite; // Ícone do som ativado
    public Sprite speakerOffSprite; // Ícone do som desativado
    private bool isMuted = false; // Indica se o som está mutado

    void Start()
    {
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    void AdjustVolume(float volume)
    {
        AudioListener.volume = volume;

        if (volume == 0 && !isMuted)
        {
            // Se o volume foi ajustado para zero, atualiza o ícone para mutado
            muteButtonImage.sprite = speakerOffSprite;
            isMuted = true;
        }
        else if (volume > 0 && isMuted)
        {
            // Se o volume foi ajustado para mais de zero, atualiza o ícone para não mutado
            muteButtonImage.sprite = speakerOnSprite;
            isMuted = false;
        }
    }
}
