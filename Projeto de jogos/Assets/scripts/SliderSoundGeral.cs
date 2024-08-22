using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    public Image muteButtonImage; // Refer�ncia para a imagem do bot�o de mute
    public Sprite speakerOnSprite; // �cone do som ativado
    public Sprite speakerOffSprite; // �cone do som desativado
    private bool isMuted = false; // Indica se o som est� mutado

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
            // Se o volume foi ajustado para zero, atualiza o �cone para mutado
            muteButtonImage.sprite = speakerOffSprite;
            isMuted = true;
        }
        else if (volume > 0 && isMuted)
        {
            // Se o volume foi ajustado para mais de zero, atualiza o �cone para n�o mutado
            muteButtonImage.sprite = speakerOnSprite;
            isMuted = false;
        }
    }
}
