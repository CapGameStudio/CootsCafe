using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DragSystem : MonoBehaviour
{

    public RaycastHit hit;

    public bool Allowed;

    public string ObjectNames;

    public float Cooldown;

    public float TimeTillDecay;

    public TextMeshProUGUI DecayTime;

    public bool inFrezzer;

    private void Start()
    {
        DecayTime.text = " ";

    }

    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
                if(hit.transform.name != ObjectNames && Allowed)
                {
                    if (inFrezzer)
                    {
                        inFrezzer = false;
                    }
                    Debug.Log(hit.transform.position + " Name: " + hit.transform.name);
                    Vector3 curScreenPoint = new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z);

                    transform.position = curScreenPoint;
                }
        }

    }

    private void Update()
    {
        //Vorhanden
        if(TimeTillDecay > 0 && !inFrezzer)
        {
            TimeTillDecay -= Time.deltaTime;
            float x = Mathf.Round(TimeTillDecay * 10f) / 10f;
            DecayTime.text = x.ToString();
        }
    }

}
