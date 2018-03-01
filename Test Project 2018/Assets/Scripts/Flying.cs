using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//optional class implementing flying ability
public class Flying : PlayerAbility{

	protected override void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Flying");
        }
    }
}
