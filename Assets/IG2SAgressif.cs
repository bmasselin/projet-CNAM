/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IG2SAgressif : FSMState<IG2StateInfo>
{
    float closeToTargetDistance = 4;
    public override void doState(ref IG2StateInfo infos)
    {
        bool closeToTarget = (infos.LastPlayerPosition - infos.Controller.transform.position).sqrMagnitude < closeToTargetDistance * closeToTargetDistance;
        if (closeToTarget)
            addAndActivateSubState<IG2SAttaque>();
        else
            addAndActivateSubState<IG2SPoursuite>();
    }
}
*/