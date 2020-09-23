using System.Collections.Generic;
using System.Linq;
using GrokkingAlgorithms.Extensions;

namespace GrokkingAlgorithms
{
    public static class TravellingSalesman
    {
    public static WeightedGraphResult GetCheapestPathThroughAllPoints(Dictionary<string, Dictionary<string, int>> graph)
    {
        var routes = graph.Keys.Permute()
            .Select(x => new RouteDetail { Route = x.ToArray() })
            .ToList();

        ApplyCostsToRoutes(graph, routes);

        var cheapestRoute = routes.OrderBy(x => x.Weight).First();

        return new WeightedGraphResult
        {
            Path = string.Join(",", cheapestRoute.Route),
            Weight = cheapestRoute.Weight,
        };
    }

    private static void ApplyCostsToRoutes(Dictionary<string, Dictionary<string, int>> graph, IList<RouteDetail> routes)
    {
        foreach (var route in routes)
        {
            for (var i = 0; i < route.Route.Length - 1; i++)
            {
                route.Weight += graph[route.Route[i]][route.Route[i + 1]];
            }
        }
    }

    private class RouteDetail
    {
        public string[] Route { get; set; }

        public int Weight { get; set; }
    }
    }
}
