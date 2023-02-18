using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : GridToBanch
{
    public override IEnumerator CoolDownCounter(float f)
    {
        yield return new WaitForSecondsRealtime(f);
        UseBench();
    }
}
