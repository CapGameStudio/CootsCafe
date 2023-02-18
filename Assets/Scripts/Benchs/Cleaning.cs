using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : GridToBanch
{
    public override IEnumerator CoolDownCounter(float f)
    {
        yield return new WaitForSecondsRealtime(f);
        UseBench();
    }
}
