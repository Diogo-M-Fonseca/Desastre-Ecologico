using UnityEngine;

public class InitScript : MonoBehaviour
{
    [SerializeField] private RunData run;

    private void Start()
    {
        run.CopyScenes();
        run.ResetGames();
    }
}
