using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;
    [SerializeField]
    [Tooltip("The event which invoked when a new round start, including summon player, reset mechanism")]
    private UnityEvent OnNewRoundStart;
    [SerializeField]
    [Tooltip("The event invoked when player win")]
    private UnityEvent OnPlayerWin;
    [SerializeField]
    [Tooltip("The duration of each round in second")]
    private float roundDuration;
    private IEnumerator loop;

    void Start()
    {
        if(_instance)
        {
            Destroy(this);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        // start game loop
        this.loop = this.gameLoop();
        StartCoroutine(this.loop);
        // add event listener
        this.OnPlayerWin.AddListener(this.gameEnd);
    }

    private IEnumerator gameLoop()
    {
        while(true)
        {
            Debug.Log("A new round start!");
            this.OnNewRoundStart.Invoke();
            yield return new WaitForSeconds(this.roundDuration);
        }
    }

    private void gameEnd()
    {
        StopCoroutine(this.loop);
    }
}