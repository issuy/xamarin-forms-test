using System;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

using client.Services.Api;

namespace client.ViewModels
{
    public class TodoViewModel : BaseViewModel
    {
        public Command LoadTodosCommand { get; set; }

        public TodoViewModel()
        {
            LoadTodosCommand = new Command(async () => await ExecuteLoadTodosCommand());
        }

        private async Task ExecuteLoadTodosCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var requester = new TodoIndexRequester();
                var req = new TodoIndexRequest();
                if(!await requester.Call(req, dialogs.IsRetry)){
                    return;
                }

                var res = requester.Response;
                Debug.WriteLine("*----*");
                Debug.WriteLine(res.Todos.Count);
                Debug.WriteLine("*----*");
                foreach (var todo in res.Todos)
                {
                    Debug.WriteLine("*----*");
                    Debug.WriteLine(todo.Id);
                    Debug.WriteLine(todo.Name);
                    Debug.WriteLine(todo.Completed);
                    Debug.WriteLine(todo.Due);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

            return;
        }
    }
}
