using System.Collections.Generic;
using Xamarin.Forms;

namespace client.Views
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            var children = new List<ContentPage>{
                new TimelinePage()
                {
                    Title = "timeline"
                },
                new ItemsPage(){
                    Title = "items"
                },
                new TodoPage(){
                    Title = "todo"
                },
            };

            foreach (var child in children){
                Children.Add(child);
            }

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
