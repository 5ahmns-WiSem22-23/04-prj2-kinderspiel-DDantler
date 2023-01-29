using UnityEngine;
using TMPro;

public class RetryButton : MonoBehaviour
{
    public TMP_Text retryText;

    void Start()
    {
        retryText.gameObject.SetActive(false);
    }

    public void ShowRetryButton()
    {
        retryText.gameObject.SetActive(true);
    }
}
