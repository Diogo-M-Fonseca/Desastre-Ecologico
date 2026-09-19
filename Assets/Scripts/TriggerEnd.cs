using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.transform.name);
        if(collision.TryGetComponent(out PlayerCollider limb))
        {
            PlayerLogic player = limb.Player;

            player.Death();
            gameObject.SetActive(false);
        }
    }
}
