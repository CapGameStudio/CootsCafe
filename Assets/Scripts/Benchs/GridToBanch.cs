using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridToBanch : MonoBehaviour
{
    public int itemAmount = 1; //itme Amount

    [SerializeField]
    private List<EatObject> ItemObj;
    public List<GameObject> StorePlace, FinishedPlace;
    public List<GameObject> InteractObject;

    public float time, workingTime;
    public bool isAlreadyworking; //später auf Private
    public TextMeshProUGUI TimerText;

    #if UNITY_EDITOR

    /*private void OnGUI()
    {
        InteractObject = new List<GameObject>(itemAmount);
        StorePlace = new List<Vector3>(itemAmount);
        FinishedPlace = new List<Vector3>(itemAmount);
    }*/
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
                    if (isAlreadyworking == false && ItemObj[i] && !InteractObject.Contains(other.gameObject) && !InteractObject[j])
                    {
                        //z.b. Dann Teller Waschen
                        other.gameObject.GetComponent<DragSystem>().Allowed = false;
                        other.transform.localPosition = StorePlace[j].transform.position;
                        InteractObject[j] = other.gameObject;
                        if (InteractObject[itemAmount - 1])
                        {
                            time = workingTime;
                            isAlreadyworking = true;
                            StartCoroutine(CoolDownCounter(workingTime));
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
            GameObject _g = Instantiate(InteractObject[j].GetComponent<DragSystem>().eatObject.nextobj.obj);
            _g.name = _g.GetComponent<DragSystem>().eatObject.nickname;
            _g.transform.localPosition = FinishedPlace[j].transform.position;
            _g.GetComponent<DragSystem>().Allowed = true;
            Destroy(InteractObject[j]);
            InteractObject[j] = null;
        }
        TimerText.text = null;
        isAlreadyworking = false;
    }
}
