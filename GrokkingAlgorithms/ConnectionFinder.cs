using System;
using System.Collections.Generic;

namespace GrokkingAlgorithms
{
    public static class ConnectionFinder
    {
        public static Node FindConnectionWorkingFor(Node node, string company)
        {
            var searched = new HashSet<int>();
            var queue = new Queue<Node>();

            AddConnectionsToQueue(node, queue);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (searched.Contains(currentNode.Id))
                {
                    continue;
                }

                if (currentNode.Company == company)
                {
                    return currentNode;
                }

                AddConnectionsToQueue(currentNode, queue);
                searched.Add(currentNode.Id);
            }

            return null;
        }

        private static void AddConnectionsToQueue(Node node, Queue<Node> queue)
        {
            foreach (var connection in node.Connections)
            {
                queue.Enqueue(connection);
            }
        }

        public class Node
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Company { get; set; }

            public Node[] Connections { get; set; } = Array.Empty<Node>();
        }
    }
}
