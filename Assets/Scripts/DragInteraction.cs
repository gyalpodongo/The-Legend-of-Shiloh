using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInteraction : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 startPosition;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        startPosition = this.gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

    }

    void OnMouseDrag() 
    {
        Debug.Log("can drag");
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        this.transform.position = curPosition;
    }

}
