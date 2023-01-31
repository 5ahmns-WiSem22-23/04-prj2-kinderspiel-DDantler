using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string sceneName;
    public AudioClip hoverSound;
    private AudioSource audioSource;

    private void Start()
    {

        Button button = GetComponent<Button>();

        button.onClick.AddListener(() => {

            SceneManager.LoadScene(sceneName);
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
}