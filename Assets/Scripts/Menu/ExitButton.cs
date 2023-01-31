using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip hoverSound;
    private AudioSource audioSource;

    private void Start()
    {

        Button button = GetComponent<Button>();

        button.onClick.AddListener(() => {

        });

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = hoverSound;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        audioSource.Stop();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}