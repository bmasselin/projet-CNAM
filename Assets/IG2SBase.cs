/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IG2SBase : FSMState<IG2StateInfo>
{
    public float SeuilBonneSante = 30;
    public override void doState(ref IG2StateInfo infos)
    {
        if (infos.PcentLife > SeuilBonneSante)
            addAndActivateSubState<IG2SBonneSante>();
        else
            addAndActivateSubState<IG2SFuite>();

        KeepMeAlive = true;
    }
}*/