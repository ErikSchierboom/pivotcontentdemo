namespace PivotContentDemo
{
    using System;
    using System.Windows.Controls;

    using Microsoft.Phone.Controls;

    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

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
    }
}