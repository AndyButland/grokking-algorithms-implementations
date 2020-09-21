using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms
{
    public static class RadioStationOptimizer
    {
        public static string[] SelectStations(string[] states, Dictionary<string, HashSet<string>> stations)
        {
            // Create data structures to track the states we need to cover and the stations we've selected.
            var statesNeeded = new HashSet<string>(states);
            var selectedStations = new HashSet<string>();

            // Loop while we've still got at least one state to cover.
            while (statesNeeded.Any())
            {
                var statesCovered = new HashSet<string>();
                string bestStation = null;
                foreach (var station in stations)
                {
                    // Find the states that we still need to cover that are covered by this station.
                    var statesNeededCoveredByStation = new HashSet<string>(statesNeeded.Intersect(station.Value));

                    // If the number of states covered is more than we've found so far, it's the best station to use.
                    if (statesNeededCoveredByStation.Count > statesCovered.Count)
                    {
                        bestStation = station.Key;
                        statesCovered = statesNeededCoveredByStation;
                    }
                }

                // Include the best station we've found in the results.
                selectedStations.Add(bestStation);

                // Update the states we need to cover.
                statesNeeded = new HashSet<string>(statesNeeded.Except(statesCovered));
            }

            return selectedStations.OrderBy(x => x).ToArray();
        }
    }
}
