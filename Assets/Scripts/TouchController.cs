using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TouchController : MonoBehaviour
{
    [SerializeField] GameObject[] objeto;
    [SerializeField] private Camera camera;
    private int index=0;
    RaycastHit hit;
    private float lastTapTime;
    private float doubleTapTime = 0.3f;
    bool doubleTapDetected=false;
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
                if (Time.time - lastTapTime < doubleTapTime && !doubleTapDetected)
                {
                    Debug.Log("Doble toque");
                    doubleTapDetected = true;
                }
                else if (doubleTapDetected)
                {
                    Debug.Log("Objeto creado después de un double tap");
                    Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
                    Instantiate(objeto[index], pos, Quaternion.identity);
                    doubleTapDetected = false; // Restablecer doubleTapDetected
                }
                else
                {
                    Debug.Log("Objeto creado después de un toque sencillo");
                    Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
                    Instantiate(objeto[index], pos, Quaternion.identity);
                }
                lastTapTime = Time.time;
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
