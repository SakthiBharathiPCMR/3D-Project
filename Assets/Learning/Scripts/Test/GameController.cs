using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public LayerMask trainLayer;
    public float dragSpeed;

    internal Vector3 startPos;
    internal Train train;

    private Plane plane;

    private void Start()
    {
        plane = new Plane(Vector3.forward, Vector3.zero);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, Mathf.Infinity, trainLayer))
            {
                train = hitInfo.collider.GetComponent<Train>();

               startPos = GetMousePos();
            }
        }

        if (Input.GetMouseButton(0) && train != null)
        {
            Vector3 endPos;
            endPos = GetMousePos();
            Vector3 dir = (endPos - startPos).normalized;
            train.transform.position = Vector3.Lerp(train.transform.position, train.transform.position + dir, Time.deltaTime * dragSpeed);
            startPos = endPos;
        }

        if (Input.GetMouseButtonUp(0) && train != null)
        {
            train = null;
        }
    }

    private Vector3 GetMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            return hitPoint;
        }
        return Vector3.zero;
    }
}
