using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnitStateDead : UnitState
{
    public UnitStateDead(Unit currentUnit, UnitSettings unitSettings, SignalBus signal) : base(currentUnit, unitSettings, signal)
    {
    }

    public override void Start()
    {
        base.Start();

        RespawnUnit();
    }

    private void RespawnUnit()
    {
        if (unitSettings.isCountable)
        {
            SetStartPosition();

            signal.Fire<UnitDestroyedSignal>();

            currentUnit.SetState(State.Moving);
        }
        else
        {
            SetStartPosition();

            currentUnit.SetState(State.Moving);
        }           
    }

    private void SetStartPosition()
    {
        currentUnit.transform.position = new Vector3(
                   currentUnit.transform.position.x,
                   unitSettings.startPosition.y,
                   currentUnit.transform.position.z);
    }
}
