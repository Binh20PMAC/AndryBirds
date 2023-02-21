using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Vector3 InitialPos;  // Vi tri ban dau
    public Rigidbody2D bird; // Lay Rigidbody 2D tu Unity
    public float springRange; // Luc lo xo (do dai cho phep)

    private void Start()
    {
        InitialPos= transform.position; // Vi tri ban dau khi chay game
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Tim toi Main Camera, chinh toa do screen sang WorldPoin
        mousePos.z = 0; // Chinh lai toa do Z trong vector 3 vi no tinh luon Z

        float distance = (InitialPos - mousePos).magnitude; // Lay do dai ban dau - diem tai diem con chuot
        Debug.Log(distance);

        if(distance < springRange) // Neu be hon luc lo xo thi co the keo tiep
        {
            transform.position = new Vector3(mousePos.x, mousePos.y); // Vi tri tai con chuot
        }    

        //Vector3 VectorForce = InitialPos - Camera.main.ScreenToWorldPoint(Input.mousePosition); // Diem ban dau den diem con chuot


        
    }

    private void OnMouseUp()
    {
        Vector3 VectorForce = InitialPos - transform.position; // Vi tri ban dau - vi tri cua Bird
        GetComponent<Rigidbody2D>().AddForce(VectorForce * 350); // Lay component, them luc cho bird, tha bay
        GetComponent<Rigidbody2D>().gravityScale = 2; // Tra lai trong luc cho Bird
    }
}
