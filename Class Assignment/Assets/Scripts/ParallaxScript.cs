using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public Vector2 parallaxSpeed;
    public GameObject ghostCamera;
    private Vector3 startPosition;
    Vector3 startCameraPos;

    void Start()
    {
        startCameraPos = ghostCamera.transform.position;
        startPosition = transform.position;
    }

    void LateUpdate()
    {
        transform.position = startPosition + new Vector3(
            (ghostCamera.transform.position.x - startCameraPos.x) * parallaxSpeed.x, 
            (ghostCamera.transform.position.y - startCameraPos.y) * parallaxSpeed.y, 
            0);
    }
}
