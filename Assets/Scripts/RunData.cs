using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RunData", menuName = "Scriptable Objects/RunData")]
public class RunData : ScriptableObject
{
    public float gamesWon, gamesLost, timeTaken;
    [SerializeField] private List<string> scenes;
    [SerializeField] private string finalScene;
    private List<string> runScenes;

    public void CopyScenes()
    {
        runScenes = new (scenes);
    }

    public void ResetGames()
    {
        gamesWon = 0;
        gamesLost = 0;
        timeTaken = 0;
    }

    public string GetScene()
    {
        if (runScenes.Count <= 0)
            return finalScene;

        Debug.Log("I occurred!");

        int index = Random.Range(0, runScenes.Count);
        string scene = runScenes[index];

        runScenes.RemoveAt(index);

        return scene;
    }

    public double CalculateScore()
    {
        float totalGames = gamesWon + gamesLost;

        // Avoid division by zero
        if (totalGames == 0)
            return 0.0;

        double avgTime = timeTaken / totalGames;
        double timeRatio = avgTime / 10.0;          // 10s window per game
        double winRate = (double)gamesWon / totalGames;
        double timeAdjustment = 1.0 / (1.0 + timeRatio);

        return winRate * timeAdjustment;
    }
}