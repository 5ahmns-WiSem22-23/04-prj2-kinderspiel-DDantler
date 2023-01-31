using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int redCount, greenCount, blueCount, yellowCount;
    public int turnCount;
    public TextMeshProUGUI turnDisplay;
    public Button button;
    public GameObject retryButton, menuButton;
    public GameObject redPrefab, greenPrefab, bluePrefab, yellowPrefab;
    public Transform redSpawn, greenSpawn, blueSpawn, yellowSpawn;
    public AudioSource audioSource;
    public AudioClip retryButtonSound;
    public AudioClip buttonClickSound;

    public Vector2 spawnSpread = new Vector2(2, 2);
    private GameObject[] prefabs;
    private Transform[] spawns;

    void Start()
    {
        prefabs = new GameObject[] { redPrefab, greenPrefab, bluePrefab, yellowPrefab };
        spawns = new Transform[] { redSpawn, greenSpawn, blueSpawn, yellowSpawn };
        retryButton.SetActive(false);
        menuButton.SetActive(false);
        turnCount = 0;
        turnDisplay.text = "Turn: " + prefabs[turnCount].name;
    }

    public void ButtonClicked()
    {
        int randomIndex = Random.Range(0, 4);
        GameObject chosenPrefab = prefabs[randomIndex];
        Transform chosenSpawn = spawns[randomIndex];

        SpawnPrefab(chosenPrefab, chosenSpawn);

        audioSource.PlayOneShot(buttonClickSound);

        if (chosenPrefab == redPrefab)
        {
            redCount++;
        }
        else if (chosenPrefab == greenPrefab)
        {
            greenCount++;
        }
        else if (chosenPrefab == bluePrefab)
        {
            blueCount++;
        }
        else if (chosenPrefab == yellowPrefab)
        {
            yellowCount++;
        }

        if (redCount == 6 || greenCount == 6 || blueCount == 6 || yellowCount == 6)
        {
            turnDisplay.text = "Game Over";
            button.interactable = false;
            retryButton.SetActive(true);
            menuButton.SetActive(true);
            audioSource.PlayOneShot(retryButtonSound);
            return;
        }

        if (chosenPrefab == prefabs[turnCount])
        {
            turnCount = (turnCount + 1) % 4;
            turnDisplay.text = "Turn: " + prefabs[turnCount].name;
        }
    }

    private void SpawnPrefab(GameObject prefab, Transform spawnPoint)
    {
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.x += Random.Range(-spawnSpread.x, spawnSpread.x);
        spawnPosition.y += Random.Range(-spawnSpread.y, spawnSpread.y);

        GameObject newPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
        newPrefab.transform.SetParent(spawnPoint);
    }


    public void RetryButtonClicked()
    {
        retryButton.SetActive(true);
        retryButton.GetComponent<Button>().interactable = true;
        redCount = 0;
        greenCount = 0;
        blueCount = 0;
        yellowCount = 0;
        turnDisplay.text = "Turn: " + prefabs[turnCount].name;
        turnCount = 0;
        button.interactable = true;
        foreach (Transform child in redSpawn)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in greenSpawn)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in blueSpawn)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in yellowSpawn)
        {
            Destroy(child.gameObject);
        }

        retryButton.SetActive(false);
        menuButton.SetActive(false);
    }

}
