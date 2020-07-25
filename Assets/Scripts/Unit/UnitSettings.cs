using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitSettings
{
    public Vector3 startPosition;
    public MovementType movementType;
    public bool isClickable;
    public bool isCountable;
    public float deathZone;
}
