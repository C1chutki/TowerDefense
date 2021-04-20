using UnityEngine;

class ScrollAndPinch : MonoBehaviour
{
#if UNITY_IOS || UNITY_ANDROID
    public Camera Camera;
    public bool Rotate;
    protected Plane Plane;
    public float DecreaseCameraPanSpeed = 1; //Default speed is 1
    public float CameraUpperHeightBound; //Zoom out
    public float CameraLowerHeightBound; //Zoom in

    public float maxleft = 2f;
    public float maxright = 100f;
    public float maxtop = 130f;
    public float maxbottom = 30f;
    public float maxHorizontal = 100f;
    public float maxVertical= 40f;

    private Vector3 cameraStartPosition;
    private void Awake()
    {
        if (Camera == null)
            Camera = Camera.main;

        cameraStartPosition = Camera.transform.position;
    }

    private void Update()
    {

        //Update Plane
        if (Input.touchCount >= 1)
            Plane.SetNormalAndPosition(transform.up, transform.position);

        var Delta1 = Vector3.zero;
        var Delta2 = Vector3.zero;

        //Scroll (Pan function)
        if (Input.touchCount >= 1 )
        {
            //Get distance camera should travel
            Delta1 = PlanePositionDelta(Input.GetTouch(0)) / DecreaseCameraPanSpeed;
            if (Input.GetTouch(0).phase == TouchPhase.Moved && Delta1.x < 0f && Camera.transform.position.x > maxleft) { 
                Camera.transform.Translate(new Vector3(Delta1.x, 0 , 0), Space.World);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved && Delta1.x > 0f && Camera.transform.position.x < maxright)
            {
                Camera.transform.Translate(new Vector3(Delta1.x, 0, 0), Space.World);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved && Delta1.z < 0f && Camera.transform.position.z > maxbottom)
            {
                Camera.transform.Translate(new Vector3(0, 0, Delta1.z), Space.World);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved && Delta1.z > 0f && Camera.transform.position.z < maxtop)
            {
                Camera.transform.Translate(new Vector3(0, 0, Delta1.z), Space.World);
            }
        }

        //Pinch (Zoom Function)
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
            if (zoom == 0 || zoom > 25)
                return;

            //Move cam amount the mid ray
            Vector3 camPositionBeforeAdjustment = Camera.transform.position;
            Camera.transform.position = Vector3.LerpUnclamped(pos1, Camera.transform.position, 1 / zoom);

            //Restricts zoom height 

            ////Upper (ZoomOut)
            if (Camera.transform.position.y > (cameraStartPosition.y + CameraUpperHeightBound))
            {
                Camera.transform.position = camPositionBeforeAdjustment;
            }
            //Lower (Zoom in)
            if (Camera.transform.position.y < (cameraStartPosition.y - CameraLowerHeightBound) || Camera.transform.position.y <= 1)
            {
                Camera.transform.position = camPositionBeforeAdjustment;
            }


            //Rotation Function
            if (Rotate && pos2b != pos2)
                Camera.transform.RotateAround(pos1, Plane.normal, Vector3.SignedAngle(pos2 - pos1, pos2b - pos1b, Plane.normal));
        }

    }

    //Returns the point between first and final finger position
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
#endif
}