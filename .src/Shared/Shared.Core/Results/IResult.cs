namespace Shared.Backend.Core.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
