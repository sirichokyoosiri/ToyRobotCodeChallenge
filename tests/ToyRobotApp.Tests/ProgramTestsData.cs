namespace ToyRobotApp.Tests
{
    public class ProgramTestsData
    {
        public static TheoryData<string[], string> TestData => new TheoryData<string[], string>
        {
            {
                [
                    "PLACE 0,0,NORTH",
                    "MOVE",
                    "REPORT"
                ],
                "Output: 0,1,NORTH"
            },
            {
                [
                    "PLACE 0,0,NORTH",
                    "LEFT",
                    "REPORT"
                ],
                "Output: 0,0,WEST"
            },
            {
                [
                    "PLACE 1,2,EAST",
                    "MOVE",
                    "MOVE",
                    "LEFT",
                    "MOVE",
                    "REPORT"
                ],
                "Output: 3,3,NORTH"
            },
            {
                [
                    "PLACE 0,0,NORTH",
                    "PLACE 1,2,EAST",
                    "MOVE",
                    "RIGHT",
                    "REPORT"
                ],
                "Output: 2,2,SOUTH"
            },
            {
                [
                    "MOVE",
                    "LEFT",
                    "RIGHT",
                    "REPORT",
                    "PLACE 1,2,EAST",
                    "REPORT"
                ],
                "Output: 1,2,EAST"
            },
            {
                [
                    "PLACE 4,1,SOUTH",
                    "MOVE",
                    "MOVE",
                    "MOVE",
                    "REPORT"
                ],
                "Output: 4,0,SOUTH"
            }
        };
    }
}
