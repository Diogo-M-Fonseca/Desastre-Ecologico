using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private RunData run;
    [SerializeField] private string nextScene = "";
    
    private bool isActive;

    private void Start()
    {
        isActive = false;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive) return;

        if (other.TryGetComponent(out PlayerCollider _))
        {
            if (nextScene == "")
            {
                isActive = true;
                SceneManager.LoadScene(run.GetScene());
            }
            else if (nextScene == SceneManager.GetSceneByBuildIndex(0).name)
            {
                SceneManager.LoadScene(0);
            }
            else Application.Quit();
        }
    }
}
