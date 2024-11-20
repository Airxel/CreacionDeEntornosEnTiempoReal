using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaCrearState : MesaBaseState
{
    public override void EnterState(MesaStateManager mesa)
    {
        Debug.Log("I'm in pain");
    }

    public override void UpdateState(MesaStateManager mesa)
    {

    }

    public override void OnClick(MesaStateManager mesa)
    {

    }
}
