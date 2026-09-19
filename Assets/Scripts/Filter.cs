using UnityEngine;

public class Filter : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerLogic>() == false)
        {
            playerLogic.PointUp();
            other.transform.parent.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
