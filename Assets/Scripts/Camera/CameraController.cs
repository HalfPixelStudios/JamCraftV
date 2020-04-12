using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody pRb;
    private Vector3 offset;
    private float shakeAmt;

    // Start is called before the first frame update
    private void Start()
    {
        pRb = player.GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
        

    }

    //copied directly from internet
    

    
    private void Update()
    {
        transform.position = player.transform.position + offset;






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

