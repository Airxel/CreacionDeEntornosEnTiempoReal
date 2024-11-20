using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MesaBaseState
{
   public abstract void EnterState(MesaStateManager mesa);

   public abstract void UpdateState(MesaStateManager mesa);

    public abstract void OnClick(MesaStateManager mesa);
}
