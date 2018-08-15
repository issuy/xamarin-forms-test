using System;

namespace client.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Models.Item Item { get; set; }
        public ItemDetailViewModel(Models.Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
