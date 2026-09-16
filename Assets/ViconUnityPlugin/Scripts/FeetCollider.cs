using UnityEngine;

public class FeetCollider : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObject;

    private void OnCollisionEnter(Collision collision)
    {
       if (System.Array.Exists(_gameObject, element => element == collision.gameObject))
       {
            Debug.Log("Collision detected with: " + collision.gameObject.name);
        }
    }

}
