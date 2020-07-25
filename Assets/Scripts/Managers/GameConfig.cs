using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    public GameObject unitPrefab;
    public int unitsAmount;
    public int scoreToWin;
    public UnitSettings[] unitSettings;
}
