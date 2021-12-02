namespace Advent_of_Code_2021
{
    public class Day02
    {
        public static int Execute(IEnumerable<(string, int)> directions, bool advanced = false)
        {
            // While the puzzle says depth is positive, we'll use normal cartographal coords and 
            // convert back at the end.
            (int x, int y) position = new ();

            if (advanced)
            {
                int aim = 0;

                foreach (var (direction, distance) in directions)
                {
                    switch (direction)
                    {
                        case "forward":
                            position.x += distance;
                            position.y += distance * aim;
                            break;

                        case "up":
                            aim += distance;
                            break;

                        case "down":
                            aim -= distance;
                            break;
                    }
                }
            }
            else
            {
                foreach (var (direction, distance) in directions)
                {
                    switch (direction)
                    {
                        case "forward":
                            position.x += distance;
                            break;

                        case "up":
                            position.y += distance;
                            break;

                        case "down":
                            position.y -= distance;
                            break;
                    }
                }
            }

            return position.x * Math.Abs(position.y);
        }
    }
}