using UnityEngine;
using System.Collections;
using System.Linq;

public class CatchManager : MonoBehaviour
{
    [SerializeField] private Vector2 timeBreak;
    [SerializeField] private GameObject[] balls;
    [SerializeField] private PlayerLogic player;
    [SerializeField] private SwordSlicer sword;

    private int ballsAwake;
    private void Start()
    {
        StartCoroutine(SpawnRoutine());    
        sword.EnemyCut += CheckDummies;
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

    private void CheckDummies()
    {
        ballsAwake++;

        if (ballsAwake == balls.Count())
            player.GameFinished();
    }
}