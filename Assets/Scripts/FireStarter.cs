using UnityEngine;

public class FireStarter : MonoBehaviour
{
    [SerializeField] private GameObject[] fires;


    public void StartFire()
    {
        foreach (GameObject fire in fires)
        {
            fire.SetActive(true);
        }
    }
}
