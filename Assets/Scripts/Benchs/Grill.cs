using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : GridToBanch
{
    public Material BackedColor;
    public override void UseBench()
    {
        base.UseBench();
        IntercatingObject.GetComponent<MeshRenderer>().material = BackedColor;
        IntercatingObject.GetComponent<DragSystem>().ObjectNames = "Grilled-" + IntercatingObject.GetComponent<DragSystem>().ObjectNames;
        IntercatingObject.name = IntercatingObject.GetComponent<DragSystem>().ObjectNames;
        IntercatingObject = null;
    }

    public override IEnumerator CoolDownCounter(float f)
    {
        f = 15;
        TimeTillFinish = f;
        yield return new WaitForSecondsRealtime(f);
        UseBench();
    }
}
