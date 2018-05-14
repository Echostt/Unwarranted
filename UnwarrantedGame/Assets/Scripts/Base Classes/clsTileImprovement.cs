using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clsTileImprovement : MonoBehaviour {
    public int defChange = 2;
    public int hpRestoredPerTurn = 5;
    public int moveChange;
    ///Every turn, finds the object above the improvement and applies the effect.
    public void idleAction (clsUnitBase unitToAffect) {
        unitToAffect.currentHP += hpRestoredPerTurn;
    }
}
