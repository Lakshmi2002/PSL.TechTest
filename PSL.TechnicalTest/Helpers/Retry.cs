using Polly;
using Polly.Retry;

namespace PSL.TechnicalTest.Helpers;

public static class Retry
{

    private static RetryPolicy _instance;

    public static RetryPolicy RetryPolicy
    {
        get
        {
            _instance ??= ConfigureRetryPolicy();
            return _instance;
        }
    }

    private static RetryPolicy ConfigureRetryPolicy()
    {
        var delays = new List<TimeSpan>
        {
            // Add a short half second wait to allow for near real time processes to complete
            TimeSpan.FromMilliseconds(500),
            // Add some one second waits to allow for quick processes to complete
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(1),
        };
        
        return Policy.Handle<Exception>()
            .WaitAndRetry(delays);
    }
}