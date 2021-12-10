namespace Advent_of_Code_2021
{
    public class Day09
    {
        public class Node
        {
            public short X { get; private set; }

            public short Y { get; private set; }

            public byte Height { get; private set; }

            public Node West { get; internal set; }

            public Node East { get; internal set; }

            public Node North { get; internal set; }

            public Node South { get; internal set; }

            public IEnumerable<Node> Neighbours
            {
                get
                {
                    if (West != null)
                    {
                        yield return West;
                    }

                    if (East != null)
                    {
                        yield return East;
                    }

                    if (North != null)
                    {
                        yield return North;
                    }

                    if (South != null)
                    {
                        yield return South;
                    }
                }
            }

            public Node(short x, short y, byte height)
            {
                X = x;
                Y = y;
                Height = height;
            }
        }

        public class Grid
        {
            private readonly Dictionary<(short x, short y), Node> _nodes = new ();

            public Grid(IEnumerable<IEnumerable<byte>> heights)
            {
                _nodes = heights.Select((row, y) => (row, y))
                                .SelectMany(row => row.row.Select((height, x) => (x: Convert.ToInt16(x), y: Convert.ToInt16(row.y), height)))
                                .ToDictionary(node => (node.x, node.y), node => new Node(node.x, node.y, node.height));

                CalculateLinks();
            }

            private void CalculateLinks()
            {
                foreach (var ((x, y), node) in _nodes)
                {
                    (short x, short y) key;
                    Node neighbour;

                    // West
                    key = (Convert.ToInt16(x - 1), y);
                    if (_nodes.TryGetValue(key, out neighbour))
                    {
                        node.West = neighbour;
                    }

                    // East
                    key = (Convert.ToInt16(x + 1), y);
                    if (_nodes.TryGetValue(key, out neighbour))
                    {
                        node.East = neighbour;
                    }

                    // North
                    key = (x, Convert.ToInt16(y - 1));
                    if (_nodes.TryGetValue(key, out neighbour))
                    {
                        node.North = neighbour;
                    }

                    // South
                    key = (x, Convert.ToInt16(y + 1));
                    if (_nodes.TryGetValue(key, out neighbour))
                    {
                        node.South = neighbour;
                    }
                }
            }

            public IEnumerable<Node> LowPoints => _nodes.Values
                                                        .Where(node => node.Neighbours.All(adj => adj.Height > node.Height))
                                                        .ToList();

            public static int CalculateBasinSize(Node origin)
            {
                Queue<Node> nodesToProcess = new ();
                HashSet<Node> foundNodes = new ();

                nodesToProcess.Enqueue(origin);

                Node nextNode;
                while (nodesToProcess.TryDequeue(out nextNode))
                {
                    foundNodes.Add(nextNode);

                    foreach (Node higherNeighbour in nextNode.Neighbours
                                                             .Where(n => n.Height < 9 && n.Height >= nextNode.Height && !foundNodes.Contains(n)))
                    {
                        nodesToProcess.Enqueue(higherNeighbour);
                    }
                }

                return foundNodes.Count;
            }
        }

        public static int Execute(IEnumerable<IEnumerable<byte>> heights, bool floodFill = false)
        {
            Grid grid = new (heights);

            if (!floodFill)
            {
                return grid.LowPoints.Sum(node => node.Height + 1);
            }

            return grid.LowPoints
                       .Select(lp => Grid.CalculateBasinSize(lp))
                       .OrderByDescending(size => size)
                       .Take(3)
                       .Aggregate((x, y) => x * y);
        }
    }
}