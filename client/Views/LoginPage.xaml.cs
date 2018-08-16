using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using client.Services.Api;

namespace client.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.Appearing += LoginAsync;
        }
        async void LoginAsync(object sender, EventArgs e)
        {
            await Login();
        }

        async void OnLogin(object sender, EventArgs e)
        {
            await Login();
        }

        async Task Login()
        {
            var requester = new LoginRequester();
            var req = new LoginRequest();
            if (!await requester.Call(req, new Dialogs(this).IsRetry))
            {
                Debug.WriteLine("Api Error");
                return;
            }
            var res = requester.Response;

            var person = res.Person;
            Debug.WriteLine("*----*");
            Debug.WriteLine(person.Id);
            Debug.WriteLine("*----*");
        }
    }
}
