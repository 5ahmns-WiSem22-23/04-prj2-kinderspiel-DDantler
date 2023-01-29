using UnityEngine;

public class Board : MonoBehaviour
{
    public Color color;
    public int fillCount = 0;

    public void Fill()
    {
        fillCount++;
    }
}
