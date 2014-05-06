# Pivot content demo
A short demo on how to dynamically load content in a Windows Phone `Pivot` control, where the contents of each `PivotItem` have been extracted into a user control.

## Implementation
First we define the `Pivot` control in [MainPage.xaml](PivotContentDemo/MainPage.xaml.cs):

```xml
<phone:Pivot Title="pivot demo" LoadingPivotItem="OnLoadingPivotItem">
    <phone:PivotItem Header="pivot 1" Margin="0,0,-12,0" />
    <phone:PivotItem Header="pivot 2" Margin="0,0,-12,0" />
    <phone:PivotItem Header="pivot 3" Margin="0,0,-12,0" />
</phone:Pivot> 
```

You can see that we just define regular `Pivot` control with three `PivotItem` entries. The entries at the moment do not contain any content. We will be dynamically setting the content of the pivot items in the `OnLoadingPivotItem` method that is fired when the `Pivot` control requests a pivot item to be loaded. This method is implemented as follows:

```c#
private void OnLoadingPivotItem(object sender, PivotItemEventArgs e)
{
    // Do not set the content of the pivot item if the content has already been set
    if (e.Item.Content != null)
    {
        return;
    }

    // Create the user control for the selected pivot item
    var pivotItemContentControl = CreateUserControlForPivotItem(((Pivot)sender).SelectedIndex);

    // Update the content of the pivot item
    e.Item.Content = pivotItemContentControl;
}

private static UserControl CreateUserControlForPivotItem(int selectedIndex)
{
    switch (selectedIndex)
    {
        case 0:
            return new PivotItem1Content();
        case 1:
            return new PivotItem2Content();
        case 2:
            return new PivotItem3Content();
        default:
            throw new ArgumentOutOfRangeException("selectedIndex");
    }
}
```

We can see that the first check in the `OnLoadingPivotItem` is whether the pivot item already has its content set. If so, we can immediately return. If not, we need to create the correct content control. We do this in the `CreateUserControlForPivotItem`, which uses the selected index of the pivot control to determine the corresponding content control. The final step is to set the content of the pivot item to the created control. The pivot item content controls are very simple. The content contrel for the first pivot item looks as follows:

```c#
using System.Windows.Controls;

public partial class PivotItem1Content : UserControl
{
    public PivotItem1Content()
    {
        this.InitializeComponent();
    }
}
```

```xml
<UserControl x:Class="PivotContentDemo.PivotItem1Content"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                                           xmlns:phoneApp4="clr-namespace:PivotContentDemo"
                                  xmlns:phone="clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone"
                                  mc:Ignorable="d"
    d:DesignHeight="480" d:DesignWidth="480">

    <Grid x:Name="LayoutRoot">
        <TextBlock>pivot item 1 content</TextBlock>
    </Grid>
</UserControl>
```

We have now achieved lazy-loading of pivot items, where the pivot items have been extracted into their own controls.

## License
[Apache License 2.0](LICENSE.md)
