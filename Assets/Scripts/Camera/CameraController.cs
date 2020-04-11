using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour {

    [SerializeField] [Range(0f, 10f)] private float cameraSpeed;
    public GameObject target;
    public float shakeAmt;
    public float shakeTime;
    public float shakeInterval;
    private float _intervalDelta=0;
    [SerializeField] private float shakeDelta = 0;
    

    void Start() {

    }

    void Update()
    {
        transform.LookAt(target.transform);
        if (GetComponent<Camera>().orthographicSize < 2||target==null)
        {
            return;
        }
        
        float t = cameraSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.transform.position.x,t),transform.position.y,Mathf.Lerp(transform.position.z, target.transform.position.z,t));

        //Camera pans towards mouse
        //Vector2 mouse_pos = Input.mousePosition;
        //transform.position = new Vector3(Mathf.Lerp(transform.position.x, mouse_pos.x, t), Mathf.Lerp(transform.position.y, mouse_pos.y, t), transform.position.z);

        if (shakeDelta > 0)
        {
            if (_intervalDelta >=shakeInterval)
            {
                shake();
                _intervalDelta= 0;
            }

            _intervalDelta += Time.deltaTime;
            shakeDelta -= Time.deltaTime;

        }
        else
        {
            _intervalDelta = 0;
        }


    }

    public void startShake(float shake,float shakeTime)
    {
        shakeAmt = shake;
        shakeDelta = shakeTime;

    }

    void shake()
    {
        if(shakeAmt>0) 
        {
            float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
            Vector3 pp = transform.position;
            pp.y+= quakeAmt; // can also add to x and/or z
            pp.x += quakeAmt;
            transform.position = pp;
        }
    }
}