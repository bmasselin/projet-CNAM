/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IG2SBonneSante : FSMState<IG2StateInfo>
{
    public override void doState(ref IG2StateInfo infos)
    {
        if (infos.CanSeeTarget || infos.CanHearTarget)
            addAndActivateSubState<IG2SAgressif>();
        else
            addAndActivateSubState<IG2STranquille>();
    }
}*/