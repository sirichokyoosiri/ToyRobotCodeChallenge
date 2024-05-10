namespace ToyRobotApp.Interfaces
{
    public interface ITableTop
    {
        /// <summary>
        /// Checks if the specified position is valid within the table top's boundaries.
        /// </summary>
        /// <param name="x">The X-coordinate of the position.</param>
        /// <param name="y">The Y-coordinate of the position.</param>
        /// <returns><see langword="true"/> if the position is valid; otherwise, <see langword="true"/>.</returns>
        bool IsValidPosition(int x, int y);
    }
}
