using UnityEngine;

public class CameraMovement : MonoBehaviour {



    public Transform player, cam, centerPoint;
    public Vector3 offset;

    public RaycastHit hit;

    Camera cams;

    private float mouseX, mouseY;

    private const float Y_MAX = 75f;
    private const float Y_MIN = -5f;


    public float sensX = 1f;
    public float sensY = 1f;


    public float zoomSpeed = 0.01f;
    public float zoomSpeedY = 0.005f;

    void Start()
    {
        cams = Camera.main;
    }


    void Update()
    {



        //mouseY = Mathf.Clamp(mouseY, Y_MIN, Y_MAX);
        Cursor.visible = true;

        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            Cursor.visible = false;

            mouseX += Input.GetAxis("Mouse X") * sensX;
            mouseY -= Input.GetAxis("Mouse Y") *sensY;

            player.rotation = Quaternion.Euler(0f, mouseX, 0f);
            centerPoint.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
            //centerPoint.rotation = player.rotation;
            //cam.localRotation = player.localRotation;


        }

        if (Input.GetMouseButton(0))
        {

            mouseX += Input.GetAxis("Mouse X") * sensX;
            mouseY -= Input.GetAxis("Mouse Y") * sensY;

            centerPoint.rotation = Quaternion.Euler(mouseY, mouseX, 0f);

        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = cams.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name + hit.point);
            }
        }

        //mouseX += Input.GetAxis("Mouse X");
        //mouseY -= Input.GetAxis("Mouse Y");

        cam.position = centerPoint.position - centerPoint.rotation * offset;

        cam.LookAt(centerPoint);


    }


    void FixedUpdate ()
    {

        Cursor.lockState = CursorLockMode.Confined;
        Vector3 endPosition = player.position;
        //Vector3 smooth = Vector3.Lerp(transform.position, endPosition, smoothSpeed * Time.deltaTime);
        transform.position = endPosition + offset;
        centerPoint.position = player.position;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
                offset.z -= zoomSpeed;
                //offset.y -= zoomSpeedY;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {   
          
                offset.z += zoomSpeed;
                //offset.y += zoomSpeedY;       
        }
    }


}
