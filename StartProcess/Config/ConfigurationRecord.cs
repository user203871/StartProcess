namespace StartProcess.Config
{
    public record ConfigurationRecord(
        string SourceProcess,
        string SourceFiles,
        string LogFile,
        int ScreenPositionX,
        int ScreenPositionY,
        int WindowWidth,
        int WindowHeight);
}
