using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaStateManager : MonoBehaviour
{

    MesaBaseState currentState;
    MesaCrearState CrearState = new MesaCrearState();
    MesaMoverState MoverState = new MesaMoverState();
    MesaRotarState RotarState = new MesaRotarState();
    MesaEliminarState EliminarState = new MesaEliminarState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = CrearState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
}
