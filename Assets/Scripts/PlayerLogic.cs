using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private int point =0;
    public int Points => point;

    [SerializeField] private uiScript uiScript;

    public void Death()
    {
        gameObject.SetActive(false);
        uiScript.ShowEndUI();
        uiScript.PointingPoints(Points);
        Time.timeScale = 0f; 
    }

    public void PointUp()
    {
        if (gameObject.activeSelf == false)
        {
            return;
        }
        point++;
        uiScript.PointingPoints(Points);
    }

}
