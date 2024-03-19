using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public float minXRot;
    public float maxXRot;       // rotation i�in

    private float curXRot;

    public float minZoom;
    public float maxZoom;

    public float zoomSpeed;
    public float rotateSpeed;

    private float curZoom;

    private Camera cam;



    private void Start()
    {
        cam = Camera.main;
        curZoom = cam.transform.localPosition.y;
        curXRot = -50;

    }


    private void Update()
    {
        curZoom += Input.GetAxis("Mouse ScrollWheel") *- zoomSpeed;     // mousun topunu oynatt�k�a zoom in - out yapacak
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);       // minimum ve maximum zoom aras�nda de�erlerde tutsun!!

        cam.transform.localPosition = Vector3.up * curZoom;


        if (Input.GetMouseButton(1))        // kameray� d�nd�rme i�lemi i�in yaz�yorum!!!  g�r�� a��s�n� ayarl�yoruz!! sa� tu�a bas�l� oldu�u zaman hareket olacak
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            curXRot += -y * rotateSpeed;
            curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);

            transform.eulerAngles = new Vector3(curXRot, transform.eulerAngles.y + (x * rotateSpeed), 0.0f);
        }

        // MOvement

        Vector3 forward = cam.transform.forward;
        forward.y = 0.0f;
        forward.Normalize();

        Vector3 right = cam.transform.right;


        float moveX = Input.GetAxisRaw("Horizontal");       // klavye hareketerli i�in yazd�k!!
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 dir = forward*moveZ + right*moveX;          // direction de�i�keni tan�mlad�m
        dir.Normalize();

        dir *= moveSpeed*Time.deltaTime;

        transform.position += dir;



    }

    

}
