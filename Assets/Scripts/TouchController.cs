using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TouchController : MonoBehaviour
{
    [SerializeField] GameObject[] objeto;
    [SerializeField] private Camera camera;
    private int index=0;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) 
            {
                Vector2 pos = camera.ScreenToWorldPoint(touch.position);
                Instantiate(objeto[index], pos, Quaternion.identity);
                if(Physics.Raycast(new Vector3(pos.x, pos.y, -5), Vector3.forward, out hit, 1000f))
                {
                    if (hit.collider != null)
                    {
                        Debug.Log(hit.collider.gameObject.name);
                    }
                };
                
            }
        }

    }
    public void CircleFigure()
    {
        index = 0;
    }
    public void TriangleFigure()
    {
        index = 1;
    }
    public void SquareFigure()
    {
        index = 2;
    }
}
