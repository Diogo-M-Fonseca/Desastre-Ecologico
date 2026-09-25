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
    private bool _isChanging;

    private int point = 0;
    public int Points => point;

    [SerializeField] private uiScript uiScript;

    private void Start()
    {
        _isFinished = false;
        _isChanging = false;
        StopAllCoroutines();
        if(slider==null) return;
        slider.value = 1;
        _actualTime = timer;
    }

    private void Update()
    {
        if(slider==null) return;

        _actualTime -= Time.deltaTime;
        slider.value = _actualTime/timer;

        if (_actualTime <= 0 && !_isFinished && !_isChanging)
        {
            _isChanging = true;
            _isFinished = true;
            run.gamesLost++;

            //PlayBombAnimation

            StartCoroutine(ChangeMiniGame());
        }

        if(_isFinished && !_isChanging)
        {
            _isChanging = true;

            run.gamesWon++;

            //YeeyAnimation

            StartCoroutine(ChangeMiniGame());
        }
    }

    private IEnumerator ChangeMiniGame()
    {
        run.timeTaken += - (_actualTime - timer);

        YieldInstruction wfs = new WaitForSeconds(sceneTransitionTime);

        yield return wfs;

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
