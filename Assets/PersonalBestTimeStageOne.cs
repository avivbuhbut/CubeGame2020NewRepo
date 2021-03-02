using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.IO;
public class PersonalBestTimeStageOne : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro PeronalBest;
    int Min;
    public static float TotalTime;
               int counter = 0;
    void Start()
    {
        PeronalBest.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
   

        Min = (int)TotalTime / 60;
        TotalTime +=0.4f * Time.deltaTime;
       if (OpenDoorStageOne.PlayerFinishLevel)
       {
            if (TotalTime % 60 > 10 && TotalTime > 0)
                PeronalBest.text =  Min + ":" + (int)TotalTime % 60;
            else if (TotalTime % 60 < 10 && TotalTime > 0)
            {
                PeronalBest.text =+ Min + ":" + "0" + (int)TotalTime % 60;
                //  PeronalBest.text = TotalTime + "";
            }

            if (counter == 0)
         {
             WriteData(TotalTime);
             counter = 1;
         }

        }

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
        StreamWriter writer = new StreamWriter("MyPath.txt", true);
        writer.Write(TotalTime);
        writer.Close();
    }
}
