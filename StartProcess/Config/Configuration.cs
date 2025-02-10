namespace StartProcess.Config
{
    public record Configuration(
        string SourceProcess,
        string SourceFiles,
        string LogFile,
        List<string> ExcludedFileTypes,
        int ScreenPositionX,
        int ScreenPositionY,
        int WindowWidth,
        int WindowHeight,
        int ExecutionLoops,
        int ExecutionSeconds,
        string Arguments);
}
