using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private RunData run;
    [SerializeField] private float timer;
    [SerializeField] private float sceneTransitionTime;
    [SerializeField] private Slider slider;

    private float _actualTime;
    private bool _isFinished;

    private int point = 0;
    public int Points => point;

    [SerializeField] private uiScript uiScript;

    private void Start()
    {
        if(slider==null) return;
        slider.value = 1;
        _actualTime = timer;
        _isFinished = false;
    }

    private void Update()
    {
        if(slider==null) return;

        _actualTime -= Time.deltaTime;
        slider.value = _actualTime/timer;

        if (_actualTime <= 0 && !_isFinished)
        {
            _isFinished = true;
            run.gamesLost++;

            //PlayBombAnimation

            StartCoroutine(ChangeMiniGame());
        }

        if( _isFinished)
        {
            run.gamesWon++;

            //YeeyAnimation

            StartCoroutine(ChangeMiniGame());
        }

        Debug.Log("Is Finished?: "+_isFinished);
    }

    private IEnumerator ChangeMiniGame()
    {
        Debug.Log("Cabou");
        yield return null;

        SceneManager.LoadScene(run.GetScene());
    }

    public void GameFinished()
    {
        _isFinished = true;
    }

    public void Death()
    {
        gameObject.SetActive(false);
        uiScript.ShowEndUI();
        Time.timeScale = 0f; 
    }

    public void PointUp()
    {
        if (gameObject.activeSelf == false)
        {
            return;
        }
        point++;
    }
}
