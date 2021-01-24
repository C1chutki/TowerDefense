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
        if (GameManager.GameIsOver)
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


        MoveCamera();
        
        
    }

    public void MoveCamera()
    {
        if (top && transform.position.z < maxtop)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
    }
}

/* if(Input.GetMouseButtonDown(0)){
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);

        } 
        else if (Input.GetMouseButtonDown(0)){
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));

        void zoom(float increment){
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, minY, maxY);
        }
       */    