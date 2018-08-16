using System;
using System.Diagnostics;

using Xamarin.Forms;

using client.Services.Api;
using client.ViewModels;

namespace client.Views
{
    public partial class TodoPage : ContentPage
    {
        TodoViewModel viewModel;

        public TodoPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new TodoViewModel();

            var dialogs = new Dialogs(this);
            viewModel.dialogs = dialogs;
        }

        void OnTodoIndex(object sender, EventArgs e)
        {
            viewModel.LoadTodosCommand.Execute(null);
        }

        async void OnTodoShow(object sender, EventArgs e)
        {
            var requester = new TodoShowRequester();
            var req = new TodoShowRequest { Id = 5066549580791808 };
            if (!await requester.Call(req, viewModel.dialogs.IsRetry))
            {
                Debug.WriteLine("Api Error");
                return;
            }

            var res = requester.Response;
            if (res.Todo == null)
            {
                Debug.WriteLine("----");
                return;
            }
            var todo = res.Todo;
            Debug.WriteLine("*----*");
            Debug.WriteLine(todo.Id);
            Debug.WriteLine(todo.Name);
            Debug.WriteLine(todo.Completed);
            Debug.WriteLine(todo.Due);
        }

        async void OnTodoCreate(object sender, EventArgs e)
        {
            var requester = new TodoCreateRequester();
            var req = new TodoCreateRequest { Name = "New todo!!!!" };
            if (!await requester.Call(req, viewModel.dialogs.IsRetry))
            {
                Debug.WriteLine("Api Error");
                return;
            }

            var res = requester.Response;
            var todo = res.Todo;
            Debug.WriteLine("*----*");
            Debug.WriteLine(todo.Id);
            Debug.WriteLine(todo.Name);
            Debug.WriteLine(todo.Completed);
            Debug.WriteLine(todo.Due);
        }
    }
}
