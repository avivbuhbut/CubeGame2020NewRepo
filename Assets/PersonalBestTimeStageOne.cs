using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.IO;

public class PersonalBestTimeStageOne : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro NewBestScore;
    public TextAsset ScoreFile;
    public TextMeshPro PeronalBest;
    int Min;
    Color lerpedColor;
    bool newBestScore;
    public static float TotalTime;
               int counter = 0;
    private string theWholeFileAsOneLongString;
    private List<string> eachLine;
    bool PresetTimer;
    void Start()
    {
        NewBestScore.gameObject.SetActive(false);
        PeronalBest.gameObject.SetActive(false);
        theWholeFileAsOneLongString = ScoreFile.text;

        eachLine = new List<string>();
        eachLine.AddRange(
                    theWholeFileAsOneLongString.Split("\n"[0]));
  //      PeronalBest.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
   

        Min = (int)TotalTime / 60;
        TotalTime +=0.4f * Time.deltaTime;
       if (OpenDoorStageOne.PlayerFinishLevel)
       {
            PeronalBest.gameObject.SetActive(true);
            if (TotalTime % 60 > 10 && TotalTime > 0)
                PeronalBest.text = Min + ":" + (int)TotalTime % 60;
            else if (TotalTime % 60 < 10 && TotalTime > 0)
            {
                PeronalBest.text = +Min + ":" + "0" + (int)TotalTime % 60;
                //  PeronalBest.text = TotalTime + "";
            }

            if (counter == 0)
         {

                if (int.Parse(eachLine[0]) > TotalTime)
                {
                    NewBestScore.gameObject.SetActive(true);
                    NewBestScore.text = "New Best Score!";
                    //eachLine[0] = TotalTime +"";
                    newBestScore = true;
                    WriteData(TotalTime);

                }
             counter = 1;
         }

            if (newBestScore)
            {
                lerpedColor = Color.Lerp(Color.black, NewBestScore.transform.GetComponent<Renderer>().material.color, Mathf.PingPong(Time.time, 1));
                NewBestScore.transform.GetComponent<Renderer>().material.color = lerpedColor;
            }

        }
    //    Debug.Log("eachLine[0]:" + eachLine[0]);
   //     Debug.Log("theWholeFileAsOneLongString:" + theWholeFileAsOneLongString);
    }




        // Read
        /*
        StreamReader reader = new StreamReader("MyPath.txt");
        string lineA = reader.ReadLine();
        string[] splitA = lineA.Split(',');
        scoreA = int.Parse(splitA[1]);

        string lineB = reader.ReadLine();
        string[] splitB = lineB.Split(',');
        scoreB = int.Parse(splitB[1]);*/
        //asset = Resources.Load(FileName + ".txt") as TextAsset;

    


    void WriteData(float TotalTime)
    {
        File.WriteAllText("MyPath.txt", "");
        StreamWriter writer = new StreamWriter("MyPath.txt", true);
  
       // File.WriteAllText("MyPath.txt", TotalTime + "");
        writer.Write(TotalTime);
        writer.Close();
    }


    
}
