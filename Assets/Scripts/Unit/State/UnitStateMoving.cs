using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum MovementType
{
    Straight,
    Diagonally
}

public class UnitStateMoving : UnitState
{
    public UnitStateMoving(Unit currentUnit, UnitSettings unitSettings, SignalBus signal) : base(currentUnit, unitSettings, signal)
    {
    }

    public override void Update()
    {
        base.Update();

        Move(unitSettings.movementType);
    }

    private void Move(MovementType type)
    {
        switch (type)
        {
            case MovementType.Straight:
                MoveStraight();
                break;
            case MovementType.Diagonally:
                MoveDiagonally();
                break;
        }
    }

    private void MoveStraight()
    {
        currentUnit.transform.position -= Vector3.up * Time.deltaTime;
    }

    private void MoveDiagonally()
    {
        var ping = Mathf.PingPong(Time.time, 1);
        var vect = currentUnit.transform.position - Vector3.up * Time.deltaTime;
        var moveTrajectory = ping > 0.5f ? Mathf.Sin(ping) : 0;

        currentUnit.transform.position = new Vector3(moveTrajectory + unitSettings.startPosition.x, vect.y, vect.z);
    }
}
