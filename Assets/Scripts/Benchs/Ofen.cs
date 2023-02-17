using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ofen : GridToBanch
{
    public Material BackedColor;
   public override void UseBench()
    {
        base.UseBench();
        InteractObject.GetComponent<MeshRenderer>().material = BackedColor;
        InteractObject.GetComponent<DragSystem>().ObjectNames = "Baked-" + InteractObject.GetComponent<DragSystem>().ObjectNames;
        InteractObject.name = InteractObject.GetComponent<DragSystem>().ObjectNames;
        InteractObject = null;
    }

    public override IEnumerator CoolDownCounter(float f)
    {
        f = 20;
        TimeTillFinish = f;
        yield return new WaitForSecondsRealtime(f);
        UseBench();
    }
}
