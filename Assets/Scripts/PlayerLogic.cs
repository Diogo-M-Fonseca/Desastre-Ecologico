using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private int point =0;
    public int Points => point;

    [SerializeField] private uiScript uiScript;

    public void Death()
    {
       Debug.Log("Player has died.");
       gameObject.SetActive(false);
       uiScript.ShowEndUI();
        uiScript.PointingPoints(Points);
        Time.timeScale = 0f; 
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
        uiScript.PointingPoints(Points);
    }

}
