using ToyRobotApp.Interfaces;

namespace ToyRobotApp.Models
{
    public class TableTop : ITableTop
    {
        private readonly int _width;
        private readonly int _height;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableTop"/> class with the specified dimensions.
        /// </summary>
        /// <param name="width">The width of the table top (must be a positive value).</param>
        /// <param name="height">The height of the table top (must be a positive value).</param>
        /// <exception cref="ArgumentException">Thrown when either width or height is not a positive value.</exception>
        public TableTop(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("TableTop dimensions must be positive values.");

            _width = width;
            _height = height;
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < _width && y >= 0 && y < _height;
        }
    }
}
