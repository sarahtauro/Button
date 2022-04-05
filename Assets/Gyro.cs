using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Gyro : MonoBehaviour
{

    Gyroscope gyro;
    StreamWriter streamWriter = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Method");
        gyro = Input.gyro;

        if(SystemInfo.supportsGyroscope)
        {
            gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(streamWriter != null)
        {
            streamWriter.WriteLine(Input.acceleration.x + ", " + Input.acceleration.y + ", " + Input.acceleration.z);
        }
    }

    public void handleRecording()
    {
        if(streamWriter == null)
        { // Start recording
            Debug.Log(Application.dataPath + "/GryoData.csv");
            streamWriter = new StreamWriter(Application.dataPath + "/GryoData"+Time.time+".csv");
            streamWriter.WriteLine("Attitude-X, Attitude-Y, Attitude-Z");
            Debug.Log("Recording...");
        }
        else
        { // Stop recording
            streamWriter.Close();
            streamWriter = null;
            Debug.Log("Stop...");
        }
    }

}
