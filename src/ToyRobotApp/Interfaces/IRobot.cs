using ToyRobotApp.Models;

namespace ToyRobotApp.Interfaces
{
    public interface IRobot
    {
        /// <summary>
        /// Places the robot at the specified coordinates facing the given direction.
        /// </summary>
        /// <param name="x">The X-coordinate on the table top.</param>
        /// <param name="y">The Y-coordinate on the table top.</param>
        /// <param name="facing">The direction the robot is facing (North, South, East, or West).</param>
        void Place(int x, int y, Direction facing);

        /// <summary>
        /// Moves the robot forward in the direction it is currently facing.
        /// </summary>
        void Move();

        /// <summary>
        /// Rotates the robot 90 degrees to the left without changing its position.
        /// </summary>
        void TurnLeft();

        /// <summary>
        /// Rotates the robot 90 degrees to the right without changing its position.
        /// </summary>
        void TurnRight();

        /// <summary>
        /// Reports the current position and facing direction of the robot.
        /// </summary>
        /// <returns>A string representing the current position and facing direction of the robot.</returns>
        string Report();
    }
}
