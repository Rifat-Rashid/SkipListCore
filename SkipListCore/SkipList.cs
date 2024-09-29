using System;

namespace SkipListCore
{
    public class SkipList
    {
        private const double P = 0.5; // Probability for each node to have a higher level
        private readonly Random _random = new Random();
        private int _maxLevel;
        private int _minLevel;
        private Node _head;

        public SkipList(int minLevel, int maxLevel)
        {
            _minLevel = minLevel;
            _maxLevel = maxLevel;
            _head = new Node(int.MinValue, _maxLevel);
        }

        // Helper function to generate a random level for a node
        private int RandomLevel()
        {
            int level = 1;
            while (_random.NextDouble() < P && level < _maxLevel)
            {
                level++;
            }
            return Math.Max(level, _minLevel);
        }

        public void Insert(int value)
        {
            int level = RandomLevel();
            Node node = new Node(value, level);
            Node[] update = new Node[level];

            Node current = _head;
            for(int i = level - 1; i >= 0; i--)
            {
                while (current.Next[i] != null && current.Next[i].Value < value)
                {
                    current = current.Next[i];
                }
                update[i] = current;
            }

            for(int i = 0; i < level; i++)
            {
                node.Next[i] = update[i].Next[i];
                update[i].Next[i] = node;
            }
        }

        public bool Search(int value)
        {
            Node current = _head;
            for (int i = _maxLevel - 1; i >= 0; i--)
            {
                while (current.Next[i] != null && current.Next[i].Value < value)
                {
                    current = current.Next[i];
                }
            }

            // Check if the value is in the last level
            return current.Next[0] != null && current.Next[0].Value == value;
        }

        public void Delete(int value)
        {
            Node[] update = new Node[_maxLevel];

            Node current = _head;
            for (int i = _maxLevel - 1; i >= 0; i--)
            {
                while (current.Next[i] != null && current.Next[i].Value < value)
                {
                    current = current.Next[i];
                }
                update[i] = current;
            }

            if (current.Next[0] != null && current.Next[0].Value == value)
            {
                for (int i = 0; i < _maxLevel; i++)
                {
                    if (update[i].Next[i] != null && update[i].Next[i].Value == value)
                    {
                        update[i].Next[i] = update[i].Next[i].Next[i];
                    }
                }
            }
        }

        // Print the skip list
        public void Print()
        {
            for (int i = _maxLevel - 1; i >= 0; i--)
            {
                Console.Write($"Level {i}: ");
                Node current = _head;
                while (current.Next[i] != null)
                {
                    Console.Write($"{current.Next[i].Value} ");
                    current = current.Next[i];
                }
                Console.WriteLine();
            }
        }
    }
}
