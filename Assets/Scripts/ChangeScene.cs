using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private RunData run;
    [SerializeField] private string nextScene = "";
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCollider _))
        {
            if (nextScene == "")
            {
                SceneManager.LoadScene(run.GetScene());
            }
            else Application.Quit();
        }
    }
}
