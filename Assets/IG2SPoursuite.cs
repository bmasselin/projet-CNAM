/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IG2SPoursuite : FSMState<IG2StateInfo>
{
    private float PoursuiteSpeed = 3.0f;
    public override void doState(ref IG2StateInfo infos)
    {
        infos.Controller.Attack(infos.LastPlayerPosition, infos.LastPlayerVelocity);
        infos.Controller.Speed = PoursuiteSpeed;
        infos.Controller.FindPathTo(infos.LastPlayerPosition);
    }
}*/