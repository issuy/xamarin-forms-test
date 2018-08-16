using System;
using System.Threading.Tasks;

using client.Services.Api;

namespace client.ViewModels.Helpers
{
    public interface IDialogs
    {
        Task<bool> IsRetry(ApiErrorCode errorCode);
    }
}
