using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragSystem : MonoBehaviour
{

    public RaycastHit hit;

    public bool Allowed;

    public string ObjectNames;

    public float Cooldown;


    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
                if(hit.transform.name != ObjectNames && Allowed)
                {
                    Debug.Log(hit.transform.position + " Name: " + hit.transform.name);
                    Vector3 curScreenPoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);

                    transform.position = curScreenPoint;
                }
        }

    }

}
