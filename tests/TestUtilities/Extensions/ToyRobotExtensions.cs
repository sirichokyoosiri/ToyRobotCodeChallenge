using TestUtilities.Helpers;
using ToyRobotApp.Models;

namespace TestUtilities.Extensions
{
    public static class ToyRobotExtensions
    {
        public static int GetX(this ToyRobot toyRobot)
        {
            return (int)FieldHelper.GetPrivateFieldValue(toyRobot, "_x");
        }

        public static int GetY(this ToyRobot toyRobot)
        {
            return (int)FieldHelper.GetPrivateFieldValue(toyRobot, "_y");
        }

        public static Direction? GetFacing(this ToyRobot toyRobot)
        {
            return (Direction?)FieldHelper.GetPrivateFieldValue(toyRobot, "_facing");
        }
    }
}
