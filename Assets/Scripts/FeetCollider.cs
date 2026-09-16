using UnityEngine;

public class FeetCollider : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;

    private void OnCollisionEnter(Collision collision)
    {
        playerLogic.Death();
    }

}
