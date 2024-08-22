using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage;
    public Sprite normalSprite;
    public Sprite hoverSprite;
    public Vector3 normalScale = new Vector3(1f, 1f, 1f);
    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1.1f);
    private AudioSource hoverButton;

    private void Awake()
    {
        hoverButton = GetComponent<AudioSource>();
    }

    // Quando o mouse entra no botão
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverButton != null && hoverButton.clip != null)
        {
            hoverButton.Play();
        }
        buttonImage.sprite = hoverSprite;
        transform.localScale = hoverScale;
    }

    // Quando o mouse sai do botão
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;
        transform.localScale = normalScale;
    }
}
