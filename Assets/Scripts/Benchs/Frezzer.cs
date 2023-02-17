using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frezzer : GridToBanch
{
    public override void UseBench()
    {
        InteractObject.GetComponent<DragSystem>().inFrezzer = true;
    }

    public override IEnumerator CoolDownCounter(float f)
    {
        UseBench();
        yield return new WaitForSecondsRealtime(3f);
        InteractObject.GetComponent<DragSystem>().Allowed = true;
        isAlreadyworking = false;
        InteractObject = null;
    }
}
