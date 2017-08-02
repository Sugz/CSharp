// example for an article on www.codeproject.com
// by Yury.Vetyukov@tuwien.ac.at

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeViewInPlaceEdit
{
class TreeViewDocument : ObservableCollection<TreeViewParentItem>
{
    public TreeViewDocument()
    {
        Add(new TreeViewParentItem("First parent item"));
        Add(new TreeViewParentItem("Second parent item"));
        Add(new TreeViewParentItem("Third parent item"));
    }
}

class TreeViewParentItem : NotifyPropertyChanged
{
    // this is a name for the parent item - shall be displayed as a header and be editable
    string name;
    public string Name
    {
        get { return name; }
        set { SetField(ref name, value); }
    }

    // child items are just strings
    public ObservableCollection<string> TreeViewChildrenItems { get; set; }

    public TreeViewParentItem(string name)
    {
        Name = name;
        TreeViewChildrenItems = new ObservableCollection<string>();
        TreeViewChildrenItems.Add("first child");
        TreeViewChildrenItems.Add("second child");
    }
}
}
