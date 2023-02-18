using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingTable : GridToBanch
{
    public List<Recipe> AllRecipes;
    public List<EatObject> UsedIngredients;

    public override void UseBench()
    {
        Debug.Log(" ist 0");
        for (int i = 0; i < AllRecipes.Count; i++)
        {
            for (int s = 0; s < AllRecipes[i].Ingredients.Count; s++)
            {
                //Zutat Vorhanden und ist letzte Zutat
                if (UsedIngredients[s] == AllRecipes[i].Ingredients[s] && s == AllRecipes[i].Ingredients.Count)
                {
                    //Mixxen
                    StartCoroutine(CoolDownCounter(AllRecipes[i].MixingTime));

                    //Fertigstellen
                    for(int j = 0; j < itemAmount; j++)
                    {
                        Instantiate(AllRecipes[i].newObject.obj, InteractObject[j].transform.position, Quaternion.identity);
                        Destroy(InteractObject[j]);
                    }
                }
            }
        }
    }

    public override IEnumerator CoolDownCounter(float f)
    {
        f = 15;
        yield return new WaitForSecondsRealtime(f);
        UseBench();
    }
}
