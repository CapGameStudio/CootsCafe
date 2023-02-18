using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeSO", menuName = "ScriptableObjects/RecipeSO", order = 2)]

public class Recipe : ScriptableObject
{
    public List<EatObject> Ingredients;
    public float MixingTime;
    public EatObject newObject;
}
