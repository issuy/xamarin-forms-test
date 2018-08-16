using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace client.ViewModels
{
    public class TimelineViewModel : BaseViewModel
    {
        public Command LoadCommand { get; set; }

        public ObservableCollection<MyModel> AllModels { get; set; }

        public ObservableCollection<ModelPair> ModelPairs { get; set; }


        public TimelineViewModel()
        {
            AllModels = new ObservableCollection<MyModel>{
                new MyModel{ Id=1 },
                new MyModel{ Id=2 },
                new MyModel{ Id=3 },
                new MyModel{ Id=4 },
                new MyModel{ Id=5 },
                new MyModel{ Id=6 },
                new MyModel{ Id=7 },
                new MyModel{ Id=8 },
                new MyModel{ Id=9 },
            };
            ModelPairs = new ObservableCollection<ModelPair>();
            CreateModelPairs();
        }

        private void CreateModelPairs()
        {
            for (int i = 0; i < AllModels.Count; i += 2)
            {
                MyModel item1 = AllModels[i];
                MyModel item2 = i + 1 < AllModels.Count ? AllModels[i + 1] : null;

                ModelPairs.Add(new ModelPair(item1, item2));
            }
        }
    }

    public class ModelPair : Tuple<MyModel, MyModel>
    {
        public ModelPair(MyModel item1, MyModel item2)
            : base(item1, item2 ?? CreateEmptyModel()) { }

        private static MyModel CreateEmptyModel()
        {
            return new MyModel
            {
                Id = -1 // -1 indicates that view should not be rendered
            };
        }
    }

    public class MyModel
    {
        public int Id { get; set; }
    }
}
