using System.Net;

namespace TutorLog.Handlers.Requests
{
    public interface IRequestHandler<T, U>
    {
        T MakeRequest(string url, U data);
    }

    public interface IRequestHandler<T>
    {
        T MakeRequest(string url);
    }
}
