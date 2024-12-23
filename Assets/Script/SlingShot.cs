using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SlingShot : MonoBehaviour
{

    public LineRenderer[] lineRenderers;
    public Transform[] stripPosition;
    public Transform center;
    public Transform idealPosition;

    public Vector3 currentPosition;

    public float maxLength;

    public float BottomBoundry;

    bool isMouseDown;

    public float BirdPositionOffset;


    public GameObject birdPrefab;
    Rigidbody2D Bird;
    Collider2D BirdCollider;



    public float speed;
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPosition[0].position);
        lineRenderers[1].SetPosition(0, stripPosition[1].position);

        CreateBird();
    }

    void CreateBird()
    {
        Bird = Instantiate(birdPrefab).GetComponent<Rigidbody2D>();
        BirdCollider = Bird.GetComponent<Collider2D>();

       

        BirdCollider.enabled = false;
    }


    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);

            currentPosition = ClampBoundray(currentPosition);

            SetStrips(currentPosition);

            if (BirdCollider)
            {
                BirdCollider.enabled = true;
            }

        }
        else
        {
            ResetStrip();
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
    }

    void Shoot()
    {
   
        Vector3 birdForce = (currentPosition - center.position) * speed * -1;
        Bird.velocity = birdForce;

        Bird = null;
        BirdCollider = null;
        Invoke("CreateBird", 2);
    }


    void ResetStrip()
    {
        currentPosition= idealPosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if(Bird)
        {
            Vector3 dir = position - center.position;
            Bird.transform.position = position + dir.normalized * BirdPositionOffset;
            Bird.transform.right = -dir.normalized;
        }

       

    }

    Vector3 ClampBoundray(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, BottomBoundry, 1000);
        return vector;

    }

   

}
