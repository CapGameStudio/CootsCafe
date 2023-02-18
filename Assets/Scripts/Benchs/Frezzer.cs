using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frezzer : GridToBanch
{
    public override void UseBench()
    {
        for (int j = 0; j < itemAmount; j++)
            InteractObject[j].GetComponent<DragSystem>().inFrezzer = true;
    }

    public override IEnumerator CoolDownCounter(float f)
    {
        UseBench();
        yield return new WaitForSecondsRealtime(3f);
        for (int j = 0; j < itemAmount; j++)
            InteractObject[j].GetComponent<DragSystem>().Allowed = true;
        isAlreadyworking = false;
        InteractObject = null;
    }
}
