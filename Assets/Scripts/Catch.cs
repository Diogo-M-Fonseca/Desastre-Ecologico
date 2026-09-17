using UnityEngine;

public class Catch : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out PlayerCollider limb))
        {
            PlayerLogic player = limb.Player;

            player.PointUp();
            gameObject.SetActive(false);
        }
    }
}
