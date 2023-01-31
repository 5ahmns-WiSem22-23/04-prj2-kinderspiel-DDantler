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
    private int[] spawnCount = { 0, 0, 0, 0 };

    private void Start()
    {
        turnText.text = "Turn: " + turnOrder[turnIndex];
    }

    public void OnBagButtonClick()
    {
        int monkeyIndex = 0;
        for (int i = 0; i < turnOrder.Length; i++)
        {
            if (turnOrder[turnIndex] == monkeyPrefabs[i].name)
            {
                monkeyIndex = i;
                break;
            }
        }

        int randomLocationIndex = -1;
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            if (spawnLocations[i].name.Contains(turnOrder[turnIndex]) && spawnCount[monkeyIndex] < 6)
            {
                randomLocationIndex = i;
                spawnCount[monkeyIndex]++;
                break;
            }
        }

        if (randomLocationIndex == -1) return;

        Vector3 offset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
        GameObject spawnedMonkey = Instantiate(monkeyPrefabs[monkeyIndex],
                                                spawnLocations[randomLocationIndex].position + offset,
                                                Quaternion.identity);

        if (spawnCount[monkeyIndex] == 6)
        {
            turnText.text = turnOrder[turnIndex] + " has won!";
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            turnIndex = (turnIndex + 1) % turnOrder.Length;
            turnText.text = "Turn: " + turnOrder[turnIndex];
        }
    }
}