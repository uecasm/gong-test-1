using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using GongSolutions.Wpf.DragDrop;

namespace GongDragTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            LayoutRoot.DataContext = new MainWindowPresenter();
        }
    }

    public class MainWindowPresenter : Observable, IDropTarget
    {
        public MainWindowPresenter()
        {
            Group1 = new ObservableCollection<ItemModel>()
            {
                new ItemModel("one"),
                new ItemModel("two"),
                new ItemModel("three"),
            };
            Group2 = new ObservableCollection<ItemModel>()
            {
                new ItemModel("A"),
                new ItemModel("B"),
                new ItemModel("C"),
            };
        }

        public ObservableCollection<ItemModel> Group1 { get; }
        public ObservableCollection<ItemModel> Group2 { get; }

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.DragInfo.SourceItem is ItemModel)
            {
                if (dropInfo.VisualTarget is Rectangle)
                {
                    // move item to red rectangle (delete)
                    dropInfo.Effects = DragDropEffects.Move;
                    dropInfo.EffectText = "Delete";
                }
                else if (ReferenceEquals(dropInfo.DragInfo.SourceCollection, Group1))
                {
                    if (dropInfo.VisualTarget is TabItem)
                    {
                        // move item from Group 1 tab to Group 2 tab
                        dropInfo.Effects = DragDropEffects.Move;
                        dropInfo.DestinationText = "Group 2";
                    }
                    else if (dropInfo.DragInfo.VisualSource == dropInfo.VisualTarget)
                    {
                        // reorder item in Group 1 within its own list
                        dropInfo.Effects = DragDropEffects.Move;
                        dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
                    }
                }
            }
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            // do nothing for this test case
        }
    }
}
