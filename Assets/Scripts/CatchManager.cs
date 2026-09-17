using UnityEngine;
using System.Collections;

public class CatchManager : MonoBehaviour
{
    [SerializeField] private Vector2 timeBreak;
    [SerializeField] private GameObject[] balls;
    private void Start()
    {
        StartCoroutine(SpawnRoutine());    
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            YieldInstruction wfs = new WaitForSeconds(Random.Range(timeBreak.x, timeBreak.y));

            yield return wfs;

            GameObject ball = balls[Random.Range(0,balls.Length)];
            bool isActive = ball.activeSelf;

            if(!isActive) ball.SetActive(true);
        }
    }
}