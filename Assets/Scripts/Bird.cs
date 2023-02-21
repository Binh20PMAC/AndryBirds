using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector3 InitialPos;  // Vi tri ban dau
    public Rigidbody2D bird; // Lay Rigidbody 2D tu Unity
    public float springRange; // Luc lo xo (do dai cho phep)
    public float bottomBoundary;
    public float birdPositonOffset;

    public LineRenderer[] lineRenderers; 
    public Transform[] stripPosition; // Soi day
    public Transform center; // Chinh giua giua cay na
    public Transform idlePositon; // Vi tri soi day va bird
    public Vector3 currenPositon; // Vi tri con chuot
    public GameObject birdPrefab; // Them bien object cua bird
    Collider2D birdCollider; // Them 1 bien va cham cho bird

    public GameObject BirdMove;


    bool isMouseDown;

    private void Start()
    {
        lineRenderers[0].positionCount = 2; //  Set/get the number of vertices: Lay vi tri dinh cua mang[0]
        lineRenderers[1].positionCount = 2; //  Set/get the number of vertices: Lay vi tri dinh cua mang[1]
        lineRenderers[0].SetPosition(0, stripPosition[0].position); // Set the position of a vertex in the line: Đặt vị trí của một đỉnh trong dòng.
        lineRenderers[1].SetPosition(0, stripPosition[1].position); // Set the position of a vertex in the line: Đặt vị trí của một đỉnh trong dòng.
        CreateBird();
        // InitialPos = transform.position; // Vi tri ban dau khi chay game
    }

    void CreateBird()
    {
        bird = Instantiate(birdPrefab).GetComponent<Rigidbody2D>(); // Them object vao Instantiate cua Ridgidbody
        birdCollider = bird.GetComponent<Collider2D>(); // Cho bird vao collider 
        birdCollider.enabled = false; //
        bird.isKinematic = true; // Cho no dung im
        ResetStrip();
    }
    private void OnMouseDown()
    {
        isMouseDown= true;
    }

    private void OnMouseUp()
    {
        isMouseDown= false;
    }


    private void Update()
    {
        if(isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition; // Vi tri cua chuot
            mousePosition.z = 10;
            currenPositon = Camera.main.ScreenToWorldPoint(mousePosition); // Cho no vao man hinh WorldPoint tu con chuot ben ngoai
            currenPositon = center.position + Vector3.ClampMagnitude(currenPositon - center.position, springRange);
            // Vi tri giua + (Vi tri con chuot khi keo - vi tri giua) , gioi hang cua no
            currenPositon = ClampBoundary(currenPositon);

            SetStrip(currenPositon);

            if (birdCollider)
            {
                birdCollider.enabled = true;
            }
           

        }
        else
        {
            ResetStrip();
        }
    }

     void ResetStrip()
    {
        currenPositon = idlePositon.position;
        SetStrip(currenPositon);
    }

   void SetStrip(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);
        if(bird)
        {
            Vector3 dir = position - center.position;
            bird.transform.position = position + dir.normalized * birdPositonOffset;
            
        }
        
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 4000);
        return vector;
    }
    //private void OnMouseDrag()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Tim toi Main Camera, chinh toa do screen sang WorldPoin
    //    mousePos.z = 0; // Chinh lai toa do Z trong vector 3 vi no tinh luon Z

    //    float distance = (InitialPos - mousePos).magnitude; // Lay do dai ban dau - diem tai diem con chuot
    //    Debug.Log(distance);

    //    if (distance < springRange) // Neu be hon luc lo xo thi co the keo tiep
    //    {
    //        transform.position = new Vector3(mousePos.x, mousePos.y); // Vi tri tai con chuot
    //    }

    //    //Vector3 VectorForce = InitialPos - Camera.main.ScreenToWorldPoint(Input.mousePosition); // Diem ban dau den diem con chuot



    //}

    //private void OnMouseUp()
    //{
    //    Vector3 VectorForce = InitialPos - transform.position; // Vi tri ban dau - vi tri cua Bird
    //    GetComponent<Rigidbody2D>().AddForce(VectorForce * 350); // Lay component, them luc cho bird, tha bay
    //    GetComponent<Rigidbody2D>().gravityScale = 2; // Tra lai trong luc cho Bird
    //}
}
