using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Camera thisCamera;
    public GameObject player1, player2;
    private float zoomFactor = 1;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 != null && player2 != null)
        {
            FixedCameraFollowSmooth(thisCamera, player1.transform, player2.transform);
        }
    }

    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        
        float followTimeDelta = 0.8f;

        Vector3 midpoint = (t1.position + t2.position) / 2f;

        distance = (t1.position - t2.position).magnitude/3;

        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        if (cam.orthographic)
        {
            if (distance > 10)
            {
                cam.orthographicSize = distance;
            }
            else
            {
                cam.orthographicSize = 10;
            }
        }
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
        {
            cam.transform.position = cameraDestination;
        }
    }
}
