using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frezzer : GridToBanch
{
    public override void UseBench()
    {
        IntercatingObject.GetComponent<DragSystem>().inFrezzer = true;
    }

    public override IEnumerator CoolDownCounter(float f)
    {
        UseBench();
        yield return new WaitForSecondsRealtime(3f);
        IntercatingObject.GetComponent<DragSystem>().Allowed = true;
        isAlreadyworking = false;
        IntercatingObject = null;
    }
}
