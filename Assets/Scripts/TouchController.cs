using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
public class TouchController : MonoBehaviour
{
    [SerializeField] GameObject[] objeto;
    private Camera camera;
    private int index=0;
    private float lastTapTime;
    private float doubleTapTime = 0.3f;
    bool doubleTapDetected=false;
    // Start is called before the first frame update
    void Start()
    {
        camera=FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime < doubleTapTime)
                {
                    Debug.Log("DobleToque");
                    doubleTapDetected = true;
                }

                else
                {
                    Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
                    if (!doubleTapDetected)
                    {
                        RaycastDetected(pos);

                    }
                }
                lastTapTime = Time.time;
                StartCoroutine(ResetDoubleTap());
            }
            Vector2 pos2=Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Moved)
            {
                MoveFigure(pos2);
            }
        }
    }
    IEnumerator ResetDoubleTap()
    {
        yield return new WaitForSeconds(0.5f); 
        doubleTapDetected = false;
    }
    void MoveFigure(Vector2 pos2)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos2, Vector2.zero);
        if (hit.collider != null)
        {
            hit.collider.gameObject.transform.position = new Vector2(pos2.x, pos2.y);
        }
    }
    void RaycastDetected(Vector2 pos)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.collider ==null)
        {
            Instantiate(objeto[index], pos, Quaternion.identity);
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
