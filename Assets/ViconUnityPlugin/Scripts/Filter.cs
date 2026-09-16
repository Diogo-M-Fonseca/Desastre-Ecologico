using UnityEngine;

public class Filter : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerLogic>() == false)
        {
            playerLogic.PointUp();
            other.gameObject.SetActive(false);
        }
    }
}