using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : GridToBanch
{
    public override void UseBench()
    {
        base.UseBench();
        InteractObject.GetComponent<DragSystem>().ObjectNames = "Wasched";
        InteractObject.name = "Wasched";
        InteractObject = null;
    }

    public override IEnumerator CoolDownCounter(float f)
    {
        f = 7;
        TimeTillFinish = f;
        yield return new WaitForSecondsRealtime(f);
        UseBench();
    }
}
