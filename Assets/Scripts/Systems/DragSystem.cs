using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DragSystem : MonoBehaviour
{

    public RaycastHit hit;

    public bool Allowed, inFrezzer;
    private float time;

    public EatObject eatObject;

    //public string ObjectNames;
    //public float TimeTillDecay;

    public TextMeshProUGUI DecayTime;

    private void Start()
    {
        if(DecayTime)
            DecayTime.text = " ";
        time = eatObject.deltime;
    }

    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if(hit.transform.name != eatObject.nickname && Allowed)
            {
                if (inFrezzer)
                    inFrezzer = false;
                Debug.Log(hit.transform.position + " Name: " + hit.transform.name);
                Vector3 curScreenPoint = new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z);

                transform.position = curScreenPoint;
            }
        }

    }

    private void Update()
    {
        //Vorhanden
        if(time > 0 && !inFrezzer)
        {
            time -= Time.deltaTime;
            float x = Mathf.Round(time * 10f) / 10f;
            DecayTime.text = x.ToString();
        }
    }

}
