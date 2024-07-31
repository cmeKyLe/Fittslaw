using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCenter : MonoBehaviour
{
    public enum dataType { mouse, touchpad }
    [SerializeField] public dataType input;

    public enum distance { _5, _10, _15 }
    [SerializeField] public distance distances;
    public enum width { _05, _10, _15 }
    [SerializeField] public width widths;
    public float distanceValue;
    public float widthchosen;
    public float widthValue;
    public int distancechosen;
    public SpriteRenderer[] circles;
    DataLogger logger;
    // Start is called before the first frame update
    void Start()
    {
        distances = distance._5;
        logger = GameObject.FindObjectOfType<DataLogger>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (distances) {

            case distance._5:
                distanceValue = 2;
                distancechosen = 5;
                break;

            case distance._10:
                distanceValue = 3;
                distancechosen = 10;
                break; 
                
            case distance._15:
                distanceValue = 4;
                distancechosen = 15;
                break;
        
        }
        switch (widths)
        {

            case width._05:
                widthValue = 0.5f;
                widthchosen = 0.5f;
                break;

            case width._10:
                widthValue = 1;
                widthchosen = 1;
                break;

            case width._15:
                widthValue = 1.5f;
                widthchosen = 1.5f;
                break;

        }
        for (int i = 0; i < circles.Length; i++)
        {
            Vector3 correctDistance = new Vector3(distanceValue * Mathf.Cos((2 * Mathf.PI * i) / 9), distanceValue * Mathf.Sin((2 * Mathf.PI * i) / 9), 0);
            circles[i].transform.position = correctDistance;   

        }
        for (int i = 0; i < circles.Length; i++)
        {
            Vector3 correctWidth = new Vector3(widthValue, widthValue, 1);
            circles[i].transform.localScale = correctWidth;
            

        }
        logger.savedData(widthchosen, distancechosen);
    }
}
