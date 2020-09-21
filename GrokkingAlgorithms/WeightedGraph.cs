using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms
{
    public static class WeightedGraph
    {
        public static Result GetCheapestPath(Dictionary<string, Dictionary<string, int>> graph)
        {
            // Create the costs and parents tracking data structures and populate
            // with the nodes from the graph.
            var costs = new Dictionary<string, int>();
            var parents = new Dictionary<string, string>();
            foreach (var key in graph.Keys.Where(x => x != "Start"))
            {
                costs.Add(key, int.MaxValue);
                parents.Add(key, null);
            }

            // Initialise the costs and parents for the neighbours of the start node.
            foreach (var item in graph["Start"])
            {
                costs[item.Key] = item.Value;
                parents[item.Key] = "Start";
            }

            // Create a structure to track what nodes we've processed.
            var processed = new HashSet<string>();

            // Find the lowest-cost node we haven't yet processed.
            var node = FindUnprocessedNodeWithLowestCost(costs, processed);
            
            // Loop while we have a node to process.
            while (node != null)
            {
                var cost = costs[node];
                var neighbours = graph[node];

                // Loop through all neighbours of the node.
                foreach (var neighbour in neighbours)
                {
                    // Figure out the cost to get to the neighbour, which will be
                    // the cost to get to the current node, plus to cost to get from
                    // there to the neighbour.
                    var newCost = cost + neighbour.Value;

                    // If this new cost is less than what we're tracking...
                    if (costs[neighbour.Key] > newCost)
                    {
                        // ... update the cost for the new node...
                        costs[neighbour.Key] = newCost;

                        // ... and track the current node as being the parent for this neighbour.
                        parents[neighbour.Key] = node;
                    }
                }

                // Track that we've processed this node.
                processed.Add(node);

                // And see if we have another.
                node = FindUnprocessedNodeWithLowestCost(costs, processed);
            }

            return new Result
            {
                Path = DescribePath(parents),
                Weight = costs["Finish"]
            };
        }

        private static string FindUnprocessedNodeWithLowestCost(Dictionary<string, int> costs, HashSet<string> processed)
        {
            var lowestCost = int.MaxValue;
            string lowestCostNode = null;

            // Loop through all the nodes we haven't processed.
            foreach (var node in costs.Where(x => !processed.Contains(x.Key)))
            {
                // If it's the lowest cost so far, set it as the one to return.
                var cost = node.Value;
                if (cost < lowestCost)
                {
                    lowestCost = cost;
                    lowestCostNode = node.Key;
                }
            }

            // Return the lowest cost, unprocessed node that we've found.
            return lowestCostNode;
        }

        private static string DescribePath(Dictionary<string, string> parents)
        {
            var pathParts = new HashSet<string>();

            var pathPart = "Finish";
            while (pathPart != "Start")
            {
                pathParts.Add(pathPart);
                pathPart = parents[pathPart];
            }

            pathParts.Add("Start");
            return string.Join(",", pathParts.Reverse());
        }

        public class Result
        {
            public string Path { get; set; }

            public int Weight { get; set; }
        }
    }
}
