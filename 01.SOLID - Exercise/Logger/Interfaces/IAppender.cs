using Logger.Enums;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel ErrorLevel { get; }
        
        void Append(IError error);
    }
}
