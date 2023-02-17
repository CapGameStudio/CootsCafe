using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridToBanch : MonoBehaviour
{
    public GameObject Bench;

    public GameObject FinishedBenchPlace;

    [SerializeField]
    private string InteractibleObj;

    public float TimeTillFinish;

    public GameObject IntercatingObject;

    public TextMeshProUGUI TimerText;

    void Start()
    {
        TimerText.text = "";
    }

    public void OnTriggerEnter(Collider other)
    {
            //Objekt zum Interagieren ist auf z.b auf Waschbecken
            if (other.name == other.GetComponent<DragSystem>().ObjectNames && other.GetComponent<DragSystem>().ObjectNames == InteractibleObj)
            {
                //z.b. Dann Teller Waschen
                other.gameObject.GetComponent<DragSystem>().Allowed = false;
                other.transform.position = Bench.transform.position;
                IntercatingObject = other.gameObject;
                TimeTillFinish = IntercatingObject.GetComponent<DragSystem>().Cooldown;
                StartCoroutine(CoolDownCounter(IntercatingObject.GetComponent<DragSystem>().Cooldown));
            }
    }


    public void Update()
    {
        if(TimeTillFinish >= 0)
        {
            TimeTillFinish -= Time.deltaTime;
            float x = Mathf.Round(TimeTillFinish * 10f) / 10f;
            TimerText.text = x.ToString();       
        }
    }

    public virtual IEnumerator CoolDownCounter(float f)
    {
        yield return new WaitForSecondsRealtime(0.01f);
        TimeTillFinish = f;
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
    }
}
