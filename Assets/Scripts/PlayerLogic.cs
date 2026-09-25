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
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip victory;
    [SerializeField] private AudioClip loss;

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

            StartCoroutine(PlaySoundThenChangeMiniGame(loss));
        }

        if(_isFinished && !_isChanging)
        {
            _isChanging = true;

            run.gamesWon++;

            

            StartCoroutine(PlaySoundThenChangeMiniGame(victory));
        }
    }
    private IEnumerator PlaySoundThenChangeMiniGame(AudioClip audioclip)
    {
        audioSource.PlayOneShot(audioclip);
        yield return new WaitForSeconds(audioclip.length);
        StartCoroutine(ChangeMiniGame());
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
