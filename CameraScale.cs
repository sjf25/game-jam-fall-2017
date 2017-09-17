
using UnityEngine;

public class CameraScale : MonoBehaviour {

    public float panSpeed = 20f;
    public float borderThickness = 10f;
    public bool sidescroll = false;
    public Vector2 panLimit = new Vector2(40,40);
    public float scrollSpeed = 1f;
    public Vector2 zoomLimit = new Vector2(2, 25);
    
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;


        if (Input.GetAxis("Horizontal") > 0 || (Input.mousePosition.x >= Screen.width - borderThickness && sidescroll))
        {
            pos.x += (panSpeed * Time.deltaTime) * Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Horizontal") < 0 || (Input.mousePosition.x <= borderThickness && sidescroll))
        {
            pos.x += (panSpeed * Time.deltaTime) * Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Vertical") > 0 || (Input.mousePosition.x >= Screen.height - borderThickness && sidescroll))
        {
            pos.y += (panSpeed * Time.deltaTime) * Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Vertical") < 0 || (Input.mousePosition.x <= borderThickness && sidescroll))
        {
            pos.y += (panSpeed * Time.deltaTime) * Input.GetAxis("Vertical");
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float scrollSize = GetComponent<Camera>().orthographicSize;

        if (scroll > 0)
        {
            scrollSize -= scrollSpeed;
        }
        if (scroll < 0)
        {
            scrollSize += scrollSpeed;
        }

        if (scrollSize > zoomLimit.x && scrollSize < zoomLimit.y)
        {
            GetComponent<Camera>().orthographicSize = scrollSize ;
        }

        transform.position = pos;

		
	}
}
