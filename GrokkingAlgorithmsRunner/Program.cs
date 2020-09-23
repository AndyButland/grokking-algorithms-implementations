using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GrokkingAlgorithms;

namespace GrokkingAlgorithmsRunner
{
    class Program
    {
        private static readonly string Cities = "ABCDEFGHIJKLMNO";
        private static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Travelling salesman.");

            var graph = new Dictionary<string, Dictionary<string, int>>();
            AddCity(graph);

            var stopwatch = new Stopwatch();
            for (var i = 1; i <= 10; i++)
            {
                AddCity(graph);

                stopwatch.Restart();
                var result = TravellingSalesman.GetCheapestPathThroughAllPoints(graph);
                stopwatch.Stop();
                Console.WriteLine($"Result with {graph.Count} cities: {result}.  Time taken: {stopwatch.ElapsedMilliseconds}");
            }

            Console.ReadLine();
        }

        private static void AddCity(Dictionary<string, Dictionary<string, int>> graph)
        {
            var existingCount = graph.Count;
            var city = Cities[existingCount].ToString();
            graph.Add(city, new Dictionary<string, int>());

            var otherCities = graph.Keys.Where(x => x != city).ToList();

            graph[city] = otherCities
                .ToDictionary(x => x, x => GetRandomScore());

            foreach (var otherCity in otherCities)
            {
                graph[otherCity].Add(city, graph[city][otherCity]);
            }
        }

        private static int GetRandomScore()
        {
            return Random.Next(1, 10);
        }


    }
}
