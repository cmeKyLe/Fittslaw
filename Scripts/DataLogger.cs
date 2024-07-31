using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataLogger : MonoBehaviour
{


    public float time;
    public int wrong;
   // public int finalTime;
    public string id;
    public float distance;
    public float width;
    public int error;
    public string filename = "D:\\Unity\\My project\\Assets\\Data\\savedData.csv";
    StreamWriter writer;
    // Start is called before the first frame update
    void Start()
    {
       
        
            writer = new StreamWriter(new FileStream(filename, FileMode.Create));
        
            writer.WriteLine("ParticipantID,Amplitude,Width,SelectionTime,Error");
    }

    public void savedData(float width,float distance)
    {
        this.width = width;
        this.distance = distance;
 

    }
    // Update is called once per frame
    public void WriteData(int counter)
    {
        if (counter > 90)
        {
            writer.Close();
            Debug.Log("gg");
        }
        if (counter % 10 != 0)
        {
            Debug.Log(time);
            writer.WriteLine(id + "," + distance + "," + width + "," + time + "," + error);
            
        }
       
    }
}
