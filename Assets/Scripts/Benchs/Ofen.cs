using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ofen : GridToBanch
{
    public Material BackedColor;
   public override void UseBench()
    {
        base.UseBench();
        IntercatingObject.GetComponent<MeshRenderer>().material = BackedColor;
        IntercatingObject.GetComponent<DragSystem>().ObjectNames = "Baked-" + IntercatingObject.GetComponent<DragSystem>().ObjectNames;
        IntercatingObject.name = IntercatingObject.GetComponent<DragSystem>().ObjectNames;
        IntercatingObject = null;
    }

    public override IEnumerator CoolDownCounter(float f)
    {
        f = 20;
        TimeTillFinish = f;
        yield return new WaitForSecondsRealtime(f);
        UseBench();
    }
}
