using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;     //herkese duyurmak i�in bu k�t�phaneyi ekledim!!

public class Selector : MonoBehaviour
{
    private Camera cam;
    public static Selector Instance;    // heryerden ula�mak i�in bunu yaz�yoruz

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    public Vector3 GetCurTilePosition()
    {
        if(EventSystem.current.IsPointerOverGameObject())       // UI t�klanmaams� i�in yazd�k
        {
            return new Vector3(0, -99, 0);

        }

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        float rayOut = 0.0f;

        if(plane.Raycast(ray, out rayOut))
        {
            Vector3 newPos = ray.GetPoint(rayOut) - new Vector3(0.05f, 0.0f,0.5f);
            newPos = new Vector3(Mathf.CeilToInt(newPos.x), 0.0f, Mathf.CeilToInt(newPos.z));

            return newPos;

        }




        return new Vector3(0, -99, 0);
    }

}
