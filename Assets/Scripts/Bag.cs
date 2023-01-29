using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bag : MonoBehaviour
{
    public GameObject[] monkeyPrefabs;
    public Transform[] spawnLocations;
    public TextMeshProUGUI turnText;

    private int turnIndex = 0;
    private string[] turnOrder = { "Red", "Green", "Blue", "Yellow" };
    private bool[] monkeySpawned = { false, false, false, false };

    private void Start()
    {
        turnText.text = "Turn: " + turnOrder[turnIndex];
    }

    public void OnBagButtonClick()
    {
        int randomMonkeyIndex = -1;
        for (int i = 0; i < monkeyPrefabs.Length; i++)
        {
            if (monkeyPrefabs[i].name == turnOrder[turnIndex] && !monkeySpawned[i])
            {
                randomMonkeyIndex = i;
                break;
            }
        }

        if (randomMonkeyIndex == -1)
        {
            randomMonkeyIndex = Random.Range(0, monkeyPrefabs.Length);
        }

        int randomLocationIndex = Random.Range(0, spawnLocations.Length);

        GameObject spawnedMonkey = Instantiate(monkeyPrefabs[randomMonkeyIndex],
                                                spawnLocations[randomLocationIndex].position,
                                                Quaternion.identity);

        monkeySpawned[randomMonkeyIndex] = true;

        if (turnOrder[turnIndex] == spawnedMonkey.name)
        {
            turnIndex = (turnIndex + 1) % turnOrder.Length;
            turnText.text = "Turn: " + turnOrder[turnIndex];
        }
    }
}
