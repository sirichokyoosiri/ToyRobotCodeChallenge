using ToyRobotApp.Interfaces;

namespace ToyRobotApp.Models
{
    public class ToyRobot : IRobot
    {
        private readonly ITableTop _tableTop;
        private int _x = -1;
        private int _y = -1;
        private Direction? _facing = null;

        public ToyRobot(ITableTop tableTop)
        {
            _tableTop = tableTop ?? throw new ArgumentNullException(nameof(tableTop));
        }

        public void Place(int x, int y, Direction facing)
        {
            if (!_tableTop.IsValidPosition(x, y))
                return;

            _x = x;
            _y = y;
            _facing = facing;
        }

        public void Move()
        {
            if (!IsPlaced())
                return;

            int newX = _x;
            int newY = _y;

            switch (_facing)
            {
                case Direction.North:
                    newY++;
                    break;
                case Direction.East:
                    newX++;
                    break;
                case Direction.South:
                    newY--;
                    break;
                case Direction.West:
                    newX--;
                    break;
            }

            if (!_tableTop.IsValidPosition(newX, newY))
                return;

            _x = newX;
            _y = newY;
        }

        public void TurnLeft()
        {
            if (!IsPlaced())
                return;

            switch (_facing)
            {
                case Direction.North:
                    _facing = Direction.West;
                    break;
                case Direction.East:
                    _facing = Direction.North;
                    break;
                case Direction.South:
                    _facing = Direction.East;
                    break;
                case Direction.West:
                    _facing = Direction.South;
                    break;
            }
        }

        public void TurnRight()
        {
            if (!IsPlaced())
                return;

            switch (_facing)
            {
                case Direction.North:
                    _facing = Direction.East;
                    break;
                case Direction.East:
                    _facing = Direction.South;
                    break;
                case Direction.South:
                    _facing = Direction.West;
                    break;
                case Direction.West:
                    _facing = Direction.North;
                    break;
            }
        }

        public string Report()
        {
            if (!IsPlaced())
                return string.Empty;

            return $"Output: {_x},{_y},{_facing.ToString().ToUpper()}";
        }

        private bool IsPlaced()
        {
            return _facing != null;
        }
    }
}
