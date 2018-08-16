using System;
using System.Threading.Tasks;

using Xamarin.Forms;

using client.ViewModels.Helpers;
using client.Services.Api;

namespace client.Views
{
    public class Dialogs : IDialogs
    {
        ContentPage page;

        public Dialogs(ContentPage p)
        {
            page = p;
        }

        public async Task<bool> IsRetry(ApiErrorCode errorCode)
        {
            switch (errorCode)
            {
                case ApiErrorCode.ConnectionFailure:
                    return await page.DisplayAlert("通信エラー", "通信に失敗しました。リトライしますか?", "リトライ", "戻る");
            }

            return false;
        }
    }
}
