using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnitState
{
    protected SignalBus signal;
    protected Unit currentUnit;
    protected UnitSettings unitSettings;

    public UnitState(Unit currentUnit, UnitSettings unitSettings, SignalBus signal)
    {
        this.currentUnit = currentUnit;
        this.unitSettings = unitSettings;
        this.signal = signal;
    }

    public virtual void Start()
    {     
    }

    public virtual void Update()
    {
        CheckPosition();
    }

    public void OnMouseDown()
    {
        if (unitSettings.isClickable)
        {
            currentUnit.SetState(State.Dead);
        }
    }

    private void CheckPosition()
    {
        if (currentUnit.transform.position.y < unitSettings.deathZone)
        {
            currentUnit.SetState(State.Dead);
        }
    }

    public UnitState Set()
    {
        Start();
        return this;
    }
}
