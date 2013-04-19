# Pivot content demo
A short demo on how to dynamically load content in a Windows Phone `Pivot` control, where the contents of each `PivotItem` have been extracted into a user control.

## Implementation
First we define the `Pivot` control in [MainPage.xaml](PivotContentDemo/MainPage.xaml.cs):

    <Grid x:Name="LayoutRoot" Background="Transparent">
        <phone:Pivot Title="pivot demo" LoadingPivotItem="OnLoadingPivotItem">
            <phone:PivotItem Header="pivot 1" Margin="0,0,-12,0" />
            <phone:PivotItem Header="pivot 2" Margin="0,0,-12,0" />
            <phone:PivotItem Header="pivot 3" Margin="0,0,-12,0" />
        </phone:Pivot> 
    </Grid>

You can see that we just define regular `Pivot` control with three `PivotItem` entries. The entries themselves will be 

## License
[Apache License 2.0](LICENSE.md)