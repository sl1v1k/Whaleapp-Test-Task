using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Button restartButton;

    private SignalBus signalBus;
    private GameManager gameManager;

    [Inject]
    private void Construct(SignalBus signalBus, GameManager gameManager)
    {
        this.signalBus = signalBus;
        this.gameManager = gameManager;
    }

    private void OnEnable()
    {
        restartButton.onClick.AddListener(Restart);
        signalBus.Subscribe<GameOverSignal>(ShowLoseScreen);
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(Restart);
        signalBus.Unsubscribe<GameOverSignal>(ShowLoseScreen);
    }

    private void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    private void Restart()
    {
        gameManager.RestartLevel();
    }
}