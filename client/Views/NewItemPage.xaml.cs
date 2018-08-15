using System;

using Xamarin.Forms;

namespace client.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Models.Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Models.Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
