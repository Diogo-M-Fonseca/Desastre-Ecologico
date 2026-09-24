using UnityEngine;

public class FireStarter : MonoBehaviour
{
    [SerializeField] private GameObject[] fires;
    [SerializeField] private PlayerLogic player;
    private int _extinguishedFires;

    private void Start()
    {
        foreach (GameObject fire in fires)
        {
            fire.SetActive(true);
            fire.GetComponent<Catch>().Extinguish += Finish;
        }
    }

    private void Finish()
    {
        _extinguishedFires++;

        if (_extinguishedFires == fires.Length)
            player.GameFinished();
    }
}
