using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerCam : MonoBehaviour {

    public GameObject target;
    public float size = 10;
    //public float scrollSpeed = 30;

    Vector3 pos;
    private Camera cam;

    // Use this for initialization
    void Start () {
        this.cam = (Camera)this.gameObject.GetComponent("Camera");
        this.cam.orthographic = true;
        this.cam.transform.rotation = Quaternion.Euler(30, 45, 0);

        pos = target.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        //this.cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;

        float distance = 30;

        transform.position = Vector3.Lerp(transform.position, target.transform.position + new Vector3(-distance, distance, -distance), 0.5f * Time.deltaTime);
        this.cam.transform.LookAt(target.transform);
    }
}
