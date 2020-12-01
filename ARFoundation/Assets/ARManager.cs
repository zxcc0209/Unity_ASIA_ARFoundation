using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

[RequireComponent(typeof(ARRaycastManager))]
public class ARManager : MonoBehaviour
{
    [Header("點擊要生成的物件")]
    public GameObject obj;
    [Header("ar 管理器")]
    public ARRaycastManager arManager;

    private Vector2 pointMouse;
    private List<ARRaycastHit> hit;

    private void Tap() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pointMouse = Input.mousePosition;
            print(pointMouse);
            if (arManager.Raycast(pointMouse,hit,TrackableType.PlaneWithinPolygon))
            {
                Instantiate(obj, hit[0].pose.position, Quaternion.identity);
            }
        }
    }
    private void Update()
    {
        Tap();
    }
}
