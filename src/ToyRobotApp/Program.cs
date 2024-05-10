using ToyRobotApp.Interfaces;
using ToyRobotApp.Models;

namespace ToyRobotApp
{
    public class Program
    {
        private static ITableTop _tableTop;
        private static IRobot _robot;

        public static void Main()
        {
            Initialize();

            Console.WriteLine("You can control the toy robot using commands of the following form:\n");
            Console.WriteLine("- PLACE X,Y,F : Places the toy robot on the table at position (X,Y) and facing 'NORTH', 'SOUTH', 'EAST', or 'WEST'.");
            Console.WriteLine("- MOVE        : Moves the toy robot one unit forward in the direction it is currently facing.");
            Console.WriteLine("- LEFT        : Rotates the robot 90 degrees to the left without changing its position.");
            Console.WriteLine("- RIGHT       : Rotates the robot 90 degrees to the right without changing its position.");
            Console.WriteLine("- REPORT      : Displays the current position (X,Y) and facing direction of the robot.\n");
            Console.WriteLine("Enter command:");

            while (true)
            {
                if (!TryParseCommand(Console.ReadLine(), out Command command, out string[] inputParts))
                {
                    Console.WriteLine("Invalid command. Please try again.");
                    continue;
                }

                if (command == Command.Exit)
                    break;

                ProcessCommand(command, inputParts);
            }
        }

        private static void Initialize()
        {
            _tableTop = new TableTop(5, 5);
            _robot = new ToyRobot(_tableTop);
        }

        private static bool TryParseCommand(string input, out Command command, out string[] inputParts)
        {
            input = input?.Trim();
            command = default;
            inputParts = default;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            inputParts = input.Split(' ');
            if (!Enum.TryParse(inputParts[0], ignoreCase: true, out Command parsedCommand))
                return false;

            command = parsedCommand;
            return true;
        }

        private static void ProcessCommand(Command command, string[] inputParts)
        {
            switch (command)
            {
                case Command.Place:
                    if (inputParts.Length != 2 || !PlaceRobot(inputParts[1]))
                        Console.WriteLine("Invalid PLACE command. Please try again.");
                    break;
                case Command.Move:
                    _robot.Move();
                    break;
                case Command.Left:
                    _robot.TurnLeft();
                    break;
                case Command.Right:
                    _robot.TurnRight();
                    break;
                case Command.Report:
                    var output = _robot.Report();
                    if (!string.IsNullOrWhiteSpace(output))
                        Console.WriteLine(output);
                    break;
            }
        }

        private static bool PlaceRobot(string parametersString)
        {
            var parameters = parametersString.Split(',');
            if (parameters.Length != 3
                || !int.TryParse(parameters[0], out int x)
                || !int.TryParse(parameters[1], out int y)
                || !Enum.TryParse(parameters[2], ignoreCase: true, out Direction direction))
                return false;

            _robot.Place(x, y, direction);
            return true;
        }
    }
}
