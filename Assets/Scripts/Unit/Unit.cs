using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum State
{
    Moving,
    Dead
}

public class Unit : MonoBehaviour
{
    [Inject] private readonly SignalBus signal;

    private UnitState unitState;
    private UnitSettings unitSettings;

    public void Init(UnitSettings unitSettings)
    {
        this.unitSettings = unitSettings;
    }

    private void OnEnable()
    {
        SetRandomColor();
    }

    private void Start()
    {
        SetState(State.Moving);
    }

    private void Update()
    {
        unitState.Update();
    }

    private void OnMouseDown()
    {
        unitState.OnMouseDown();
    }

    public void SetState(State state)
    {
        switch (state)
        {
            case State.Moving:
                unitState = new UnitStateMoving(this, unitSettings, signal);
            break;
            case State.Dead:
                unitState = new UnitStateDead(this, unitSettings, signal);
            break;
        }

        unitState.Set();
    }

    private void SetRandomColor()
    {
        var mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Random.ColorHSV();
    }

    public class Factory : PlaceholderFactory<Unit>
    {
    }
}