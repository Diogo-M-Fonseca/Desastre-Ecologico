using UnityEngine;

public class FireStarter : MonoBehaviour
{
    [SerializeField] private GameObject[] fires;

    private void Start()
    {
        foreach (GameObject fire in fires)
        {
            fire.SetActive(true);
        }
    }
}
