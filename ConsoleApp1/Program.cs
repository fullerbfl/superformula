// See https://aka.ms/new-console-template for more information
using BuildingLibrary.Tests;


Console.WriteLine("Calcualte Building Volumes 1.0");
var test = new UnitTest();

// Run a series of tests to validate the various room calculations
Console.WriteLine("... running tests ...");


Console.WriteLine("    greenhouse room");
test.TestGreenhouseRoom();

Console.WriteLine("    triangular room"); 
test.TestTriangularRoom();

Console.WriteLine("    cubical room"); 
test.TestCubicalRoom();


// test a full building calculation
Console.WriteLine("    multiple buildings");
test.TestBuildingsVolume();


Console.WriteLine("Done");
Console.ReadLine();
