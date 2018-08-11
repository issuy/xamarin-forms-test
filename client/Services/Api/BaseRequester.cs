using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace client.Services.Api
{
    public enum ApiErrorCode
    {
        None = 1,
        ConnectionFailure,
        Maintenance,
        ForceUpdate,
    }

    public interface IRequest { }
    public interface IResponse { }

    public delegate Task<bool> IsRetryTask(ApiErrorCode errorCode);

    public abstract class BaseGetRequester<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public abstract string Path { get; }
        public TRequest Request { get; private set; }
        public TResponse Response { get; private set; }

        public async Task<bool> Call(TRequest req, IsRetryTask isRetryTask)
        {
            Request = req;

            while (true)
            {
                await Task.Delay(1000);
                if (!CrossConnectivity.Current.IsConnected)
                {
                    if (await isRetryTask(ApiErrorCode.ConnectionFailure)) continue;
                    return false;
                }

                try
                {
                    var json = await ApiClient.Client.GetStringAsync(Path);
                    Response = await Task.Run(() => JsonConvert.DeserializeObject<TResponse>(json));
                }
                catch
                {
                    if (await isRetryTask(ApiErrorCode.ConnectionFailure)) continue;
                    return false;
                }

                break;
            }

            // 正常時true
            return true;
        }
    }

    public abstract class BasePostRequester<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public abstract string Path { get; }
        public TRequest Request;
        public TResponse Response;

        public async Task<bool> Call(TRequest req, IsRetryTask isRetryTask)
        {
            Request = req;
            while (true)
            {
                await Task.Delay(1000);
                if (!CrossConnectivity.Current.IsConnected)
                {
                    if (await isRetryTask(ApiErrorCode.ConnectionFailure)) continue;
                    return false;
                }

                try
                {
                    var serializedItem = JsonConvert.SerializeObject(req);
                    var r = await ApiClient.Client.PostAsync(Path, new StringContent(serializedItem, Encoding.UTF8, "application/json"));
                    var json = await r.Content.ReadAsStringAsync();
                    Response = await Task.Run(() => JsonConvert.DeserializeObject<TResponse>(json));
                }
                catch
                {
                    if (await isRetryTask(ApiErrorCode.ConnectionFailure)) continue;
                    return false;
                }

                break;
            }

            // 正常時true
            return true;
        }
    }
}
