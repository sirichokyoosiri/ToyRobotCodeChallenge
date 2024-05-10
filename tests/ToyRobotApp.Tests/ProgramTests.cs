namespace ToyRobotApp.Tests
{
    public class ProgramTests
    {
        [Theory]
        [MemberData(nameof(ProgramTestsData.TestData), MemberType = typeof(ProgramTestsData))]
        public void Main_EnterCommands_ShouldPrintCorrectOutput(string[] inputCommands, string expectedOutput)
        {
            // Arrange
            // Concatenate input commands with an EXIT command to ensure the while loop termination.
            var input = string.Join(Environment.NewLine, inputCommands)
                + Environment.NewLine
                + "EXIT" + Environment.NewLine;

            var reader = new StringReader(input);
            var writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);

            // Act
            Program.Main();

            // Assert
            var actualOutput = writer.ToString().Trim().Split(Environment.NewLine).LastOrDefault();
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
