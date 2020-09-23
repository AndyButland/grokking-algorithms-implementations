namespace GrokkingAlgorithms
{
    public class WeightedGraphResult
    {
        public string Path { get; set; }

        public int Weight { get; set; }

        public override string ToString() => $"{Path} ({Weight})";
    }
}
