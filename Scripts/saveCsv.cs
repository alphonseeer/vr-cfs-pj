using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;       // DateTimeを使うために必要
using System.IO;    // CSV保存をするために必要

public class saveCsv : MonoBehaviour
{
    void Start()
    {
    		// sampleDataを作って、CSVSaveの関数に引数として渡す
          var abc = new List<int > () {0,1,2};
         int[] sampleData  ;
         sampleData = abc.ToArray();
        var abc1 = new List<int > () {0,1,2};
         int[] sampleData1  ;
         sampleData1 = abc.ToArray();

         string people = "number1 ";

        CSVSave(sampleData, sampleData1,people);
    }

		// CSV形式で保存するための関数
   public  void CSVSave(Array data1 ,Array data2 ,string fileName)
    {
        StreamWriter sw;
        FileInfo fi;
        DateTime now = DateTime.Now;

        fileName = fileName +"_"+ now.Year.ToString() + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "__" + now.Hour.ToString() + "_" + now.Minute.ToString() + "_" + now.Second.ToString();
        fi = new FileInfo(Application.dataPath + "/" + fileName + ".csv");
        sw = fi.AppendText();
        sw.WriteLine("Q1");
         foreach(int chr in data1)
         {
           sw.WriteLine(chr);
         }
         sw.WriteLine("Q2");
         foreach(int chr in data2)
         {
           sw.WriteLine(chr);
         }
        

        sw.Flush();
        sw.Close();
        Debug.Log("Save Completed");
    }
}
