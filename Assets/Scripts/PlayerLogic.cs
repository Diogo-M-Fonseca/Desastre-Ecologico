using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private int point =0;
    public int Points => point;

    public void Death()
    {
       Debug.Log("Player has died.");
       gameObject.SetActive(false);
    }

    public void Respawn()
    {
        Debug.Log("Player has respawned.");
        gameObject.SetActive(true);
    }

    public void PointUp()
    {
        if (gameObject.activeSelf == false)
        {
            Debug.Log("Player is dead. Cannot point up.");
            return;
        }
        point++;
        Debug.Log("Player has pointed up." + Points);
    }
}
