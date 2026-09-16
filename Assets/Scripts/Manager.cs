using UnityEngine;

public class Manager : MonoBehaviour
{
    private int _score;
    public int Score => _score;

    public void IncreasePoint(int value = 1) { _score+=value; }
}
