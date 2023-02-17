using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridToBanch : MonoBehaviour
{
    public int itemAmount = 1; //itme Amount

    [SerializeField]
    private List<EatObject> ItemObj;
    public List<Transform> StorePlace, FinishedPlace;
    public List<GameObject> InteractObject;

    public float time, workingTime;
    public bool isAlreadyworking; //später auf Private
    public TextMeshProUGUI TimerText;

    #if UNITY_EDITOR

    private void OnGUI()
    {
        InteractObject = new List<GameObject>(itemAmount);
        StorePlace = new List<Transform>(itemAmount);
        FinishedPlace = new List<Transform>(itemAmount);
    }
    #endif

    void Start()
    {
        if(TimerText != null)
            TimerText.text = " ";
    }

    public void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < ItemObj.Count; i++)
        {
            //Objekt zum Interagieren ist auf z.b auf Waschbecken
            if (other.GetComponent<DragSystem>().eatObject == ItemObj[i])
            {
                for (int j = 0; j < itemAmount; j++)
                {
                    if (isAlreadyworking == false && ItemObj[i])
                    {
                        //z.b. Dann Teller Waschen
                        other.gameObject.GetComponent<DragSystem>().Allowed = false;
                        other.transform.position = StorePlace[j].position;
                        InteractObject[j] = other.gameObject;
                        if (InteractObject[itemAmount - 1])
                        {
                            time = workingTime;
                            isAlreadyworking = true;
                            StartCoroutine(CoolDownCounter(ItemObj[i].time));
                        }
                    }
                }
            }
        }
    }


    public void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            float x = Mathf.Round(time * 10f) / 10f;
            TimerText.text = x.ToString();       
        }
    }

    public virtual IEnumerator CoolDownCounter(float f)
    {
        yield return new WaitForSecondsRealtime(f);
        UseBench();
    }

    public virtual void UseBench()
    {
        time = 0;
        for (int j = 0; j < itemAmount; j++)
        {
            InteractObject[j].transform.position = FinishedPlace[j].position;
            InteractObject[j].GetComponent<DragSystem>().Allowed = true;
        }
        TimerText.text = null;
        isAlreadyworking = false;
    }
}
