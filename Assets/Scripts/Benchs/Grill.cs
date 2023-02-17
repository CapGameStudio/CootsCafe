using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : GridToBanch
{
    public Material BackedColor;
    public override void UseBench()
    {
        base.UseBench();
        InteractObject.GetComponent<MeshRenderer>().material = BackedColor;
        InteractObject.GetComponent<DragSystem>().ObjectNames = "Grilled-" + InteractObject.GetComponent<DragSystem>().ObjectNames;
        InteractObject.name = InteractObject.GetComponent<DragSystem>().ObjectNames;
        InteractObject = null;
    }

    public override IEnumerator CoolDownCounter(float f)
    {
        f = 15;
        time = f;
        yield return new WaitForSecondsRealtime(f);
        UseBench();
    }
}
