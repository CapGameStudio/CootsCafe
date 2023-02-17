using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Eat", menuName = "ScriptableObjects/Eat", order = 1)]
public class EatObject : ScriptableObject
{
    public string nickname;
    public GameObject obj;
    public float deltime;
    public float time; //timetofinish
    public float eattime;
}
