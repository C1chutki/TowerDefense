using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraControler : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 20f;

    public float scrollSpeed = 3f;
    public float minY = 10f;
    public float maxY = 80f;
    public float maxleft = 2f;
    public float maxright = 100f;
    public float maxtop = 130f;
    public float maxbottom = 80f;


    private bool top;

    public Camera Camera;
    public bool Rotate;
    protected Plane Plane;

    private void Awake()
    {
        if (Camera == null)
            Camera = Camera.main;
    }

    public void PointerDownTop()
    {
        top = true;
    }
    public void PointerUpTop()
    {
        top = false;
    }


    void Start()
    {
        top = false;
    }

    void Update()
    {
        //Update Plane
        if (Input.touchCount >= 1)
            Plane.SetNormalAndPosition(transform.up, transform.position);

        var Delta1 = Vector3.zero;
        var Delta2 = Vector3.zero;

        //Scroll
        if (Input.touchCount >= 1)
        {
            Delta1 = PlanePositionDelta(Input.GetTouch(0));
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
                Camera.transform.Translate(Delta1, Space.World);
        }

        //Pinch
        if (Input.touchCount >= 2)
        {
            var pos1 = PlanePosition(Input.GetTouch(0).position);
            var pos2 = PlanePosition(Input.GetTouch(1).position);
            var pos1b = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
            var pos2b = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

            //calc zoom
            var zoom = Vector3.Distance(pos1, pos2) /
                       Vector3.Distance(pos1b, pos2b);

            //edge case
            if (zoom == 0 || zoom > 10)
                return;

            //Move cam amount the mid ray
            Camera.transform.position = Vector3.LerpUnclamped(pos1, Camera.transform.position, 1 / zoom);

            if (Rotate && pos2b != pos2)
                Camera.transform.RotateAround(pos1, Plane.normal, Vector3.SignedAngle(pos2 - pos1, pos2b - pos1b, Plane.normal));
        }








        /*if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if ((Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) && transform.position.z < maxtop)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if ((Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) && transform.position.z >= maxbottom)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if ((Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) && transform.position.x < maxright)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if ((Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) && transform.position.x > maxleft)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;


        MoveCamera();*/
        
        
    }
    protected Vector3 PlanePositionDelta(Touch touch)
    {
        //not moved
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        //delta
        var rayBefore = Camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = Camera.ScreenPointToRay(touch.position);
        if (Plane.Raycast(rayBefore, out var enterBefore) && Plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

        //not on plane
        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
        //position
        var rayNow = Camera.ScreenPointToRay(screenPos);
        if (Plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }

    /*public void MoveCamera()
    {
        if (top && transform.position.z < maxtop)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
    }*/
} 