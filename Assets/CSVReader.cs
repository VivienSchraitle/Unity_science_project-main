using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public static List<Tuple<string, string>> csvData;

    private void Start()
    {
        // Example usage:
        string filePath = "path/to/your/file.csv";
        UpdateData(filePath);

        // Access data from other scripts using GetStructuredData
        List<Tuple<string, string>> receivedData = GetStructuredData();

        if (receivedData != null)
        {
            // Access received data as needed
            foreach (var tuple in receivedData)
            {
                Debug.Log($"Entry1: {tuple.Item1}, Entry2: {tuple.Item2}");
            }
        }
    }

    public static void UpdateData(string filePath = "path/to/your/file.csv")
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            List<Tuple<string, string>> newData = new List<Tuple<string, string>>();

            // Assuming each row contains an even number of entries
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');

                for (int i = 0; i < entries.Length; i += 2)
                {
                    if (i + 1 < entries.Length)
                    {
                        string entry1 = entries[i];
                        string entry2 = entries[i + 1];

                        newData.Add(Tuple.Create(entry1, entry2));
                    }
                    else
                    {
                        Debug.LogError("Invalid number of entries in a row. Each row must contain an even number of entries.");
                        return;
                    }
                }
            }

            // Update the static data with the new data
            csvData = newData;
        }
        catch (Exception e)
        {
            Debug.LogError($"Error reading or parsing CSV data: {e.Message}");
        }
    }

    public static List<Tuple<string, string>> GetStructuredData()
    {
        return csvData;
    }
}