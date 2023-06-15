/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IG2STranquille : FSMState<IG2StateInfo>
{
    public float PeriodIdle = 5;
    private float TempoIdle = 0;
    private bool Init = true;

    public override void doState(ref IG2StateInfo infos)
    {
        TempoIdle += infos.PeriodUpdate;

        if (TempoIdle > PeriodIdle || Init)
        {
            TempoIdle = 0;
            Init = false;
            if (isActiveSubstate<IG2SIdle>())
            {
                addAndActivateSubState<IG2SPatrouille>();
            }
            else
            {
                addAndActivateSubState<IG2SIdle>();
            }
        }

        KeepMeAlive = true; //Sinon on perds la tempo, l'init etc...
    }
}
*/