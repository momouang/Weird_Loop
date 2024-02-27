using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGameManagerState : MonoBehaviour
{
    [Tooltip("State to change to")]
    public State TargetState;

    // Start is called before the first frame update
    public void UpdateState()
    {
        GameManager.Instance.UpdateState(TargetState);
    }
}
