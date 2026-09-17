using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;

    private void Awake()
    {
        playerLogic = FindAnyObjectByType<PlayerLogic>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerLogic>() != null)
        {
            playerLogic.Death();
        }
    }
}
