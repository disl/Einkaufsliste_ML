﻿
// This file was auto-generated by ML.NET Model Builder. 

using MLModel1_ConsoleApp1;

// Create single instance of sample data from first line of dataset for model input
MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
{
    Col0 = @"Apfel",
};



Console.WriteLine("Using model to make single prediction -- Comparing actual Col1 with predicted Col1 from sample data...\n\n");


Console.WriteLine($"Col0: {@"Apfel"}");
Console.WriteLine($"Col1: {@"Obst"}");


var sortedScoresWithLabel = MLModel1.PredictAllLabels(sampleData);
Console.WriteLine($"{"Class",-40}{"Score",-20}");
Console.WriteLine($"{"-----",-40}{"-----",-20}");

foreach (var score in sortedScoresWithLabel)
{
    Console.WriteLine($"{score.Key,-40}{score.Value,-20}");
}

Console.WriteLine("=============== End of process, hit any key to finish ===============");
Console.ReadKey();

