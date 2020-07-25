using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameConfig config;

    private Unit.Factory unitFactory;
    private SignalBus signal;
    private int score;

    [Inject]
    public void Construct(Unit.Factory unitFactory, SignalBus signal)
    {
        this.unitFactory = unitFactory;
        this.signal = signal;
    }

    private void Start()
    {
        SpawnUnits(config.unitsAmount);

        signal.Subscribe<UnitDestroyedSignal>(UpdateScore);
    }

    private void UpdateScore()
    {
        score++;

        CheckScore();
    }

    private void CheckScore()
    {
        if (score >= config.scoreToWin)
        {
            signal.Fire<GameOverSignal>();
        }
    }

    public void SpawnUnits(int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            var unit = unitFactory.Create();
            unit.Init(config.unitSettings[i]);
            unit.transform.position = config.unitSettings[i].startPosition;
            unit.name = "Unit " + i;
        }
    }

    public void RestartLevel()
    {
        var scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void OnDisable()
    {
        signal.Unsubscribe<UnitDestroyedSignal>(UpdateScore);
    }
}

