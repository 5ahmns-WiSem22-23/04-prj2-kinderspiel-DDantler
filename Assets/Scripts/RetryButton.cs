using UnityEngine;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    public void Enable()
    {
        button.interactable = true;
    }

    public void Disable()
    {
        button.interactable = false;
    }
}
