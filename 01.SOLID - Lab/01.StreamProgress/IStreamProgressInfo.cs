namespace P01.Stream_Progress
{
    public interface IStreamProgressInfo
    {
        int Length { get; }
        int BytesSent { get; }
    }
}