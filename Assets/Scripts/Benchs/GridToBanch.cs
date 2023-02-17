using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridToBanch : MonoBehaviour
{
    public GameObject Bench;

    public GameObject FinishedBenchPlace;

    [SerializeField]
    private List<string> InteractibleObj;

    public float TimeTillFinish;

    public GameObject IntercatingObject;

    public TextMeshProUGUI TimerText;

    public bool isAlreadyworking;

    void Start()
    {
        if(TimerText != null)
        {
            TimerText.text = " ";
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < InteractibleObj.Count; i++)
        {
            //Objekt zum Interagieren ist auf z.b auf Waschbecken
            if (other.name == other.GetComponent<DragSystem>().ObjectNames && other.GetComponent<DragSystem>().ObjectNames == InteractibleObj[i] && isAlreadyworking == false)
            {
                //z.b. Dann Teller Waschen
                isAlreadyworking = true;
                other.gameObject.GetComponent<DragSystem>().Allowed = false;
                other.transform.position = Bench.transform.position;
                IntercatingObject = other.gameObject;
                if(TimerText != null)
                {
                    TimeTillFinish = IntercatingObject.GetComponent<DragSystem>().Cooldown;
                }
                StartCoroutine(CoolDownCounter(IntercatingObject.GetComponent<DragSystem>().Cooldown));
            }
        }
    }


    public void Update()
    {
        if(TimeTillFinish > 0)
        {
            TimeTillFinish -= Time.deltaTime;
            float x = Mathf.Round(TimeTillFinish * 10f) / 10f;
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
        TimeTillFinish = 0;
        Debug.Log(" ist 0");
        IntercatingObject.transform.position = FinishedBenchPlace.transform.position;
        IntercatingObject.GetComponent<DragSystem>().Allowed = true;
        TimerText.text = null;
        isAlreadyworking = false;
    }
}
