using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    
    private Camera _maincamera;
    public SpriteRenderer[] circles;
    [SerializeField] private int which = 1;
    public float time = 0;
    private DataLogger logger;
    public int counter = 0;
    public void Start()
    {
        circles[0].color = Color.red;
        logger = GameObject.FindAnyObjectByType<DataLogger>();
    }
    private void Awake()
    {
        _maincamera = Camera.main;
    }
    public void Update()
    {
       
        for (int i = 1; i < which; i++)
        {

            circles[i].color = Color.red;
            circles[i - 1].color = Color.white;

        }
        if (which >= 10)
        {

            which = 1;
        }
        time = time + Time.deltaTime;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_maincamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        
        if (!rayHit.collider) return;
        Debug.Log(rayHit.collider.gameObject.name);
        

        if (rayHit.collider.GetComponent<SpriteRenderer>().color == Color.red)
        {
            which++;
            counter++;
            if (logger.error != 1)
            {
                logger.error = 0;
            }
            logger.time = time;
            logger.WriteData(counter);
            logger.error = 2;
            time = 0;
            
        }else
        {

            logger.error = 1;
        }
    }

   






}
