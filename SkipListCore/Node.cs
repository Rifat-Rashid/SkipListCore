namespace SkipListCore
{
    public class Node
    {
        public int Value { get; set; }
        public int Level { get; set; }
        public Node[] Next { get; set; }

        public Node(int value, int level)
        {
            Value = value;
            Level = level;
            Next = new Node[level];
        }
    }
}
