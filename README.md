# Access ListView inside DataTemplate in NET MAUI
You can access a named [SfListView](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.SfListView.html) defined inside a [DataTemplate](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/datatemplate?view=net-maui-8.0) of [SfPopup](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Popup.SfPopup.html) by using [Behavior](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/behaviors?view=net-maui-8.0).

**XAML**

In SfPopup's [ContentTemplate](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Popup.SfPopup.html#Syncfusion_Maui_Popup_SfPopup_ContentTemplate), add a behavior to the parent Grid of ListView.

```
<popup:SfPopup x:Name="popupLayout">
    <popup:SfPopup.ContentTemplate>
        <DataTemplate>
            <Grid>
                <Grid.Behaviors>
                    <local:GridBehavior/>
                </Grid.Behaviors>
                <Grid.RowDefinitions>
                    <RowDefinition Height="50"/>
                    <RowDefinition Height="*"/>
                </Grid.RowDefinitions>
                <Button Text="Find ListView" x:Name="listviewButton" BackgroundColor="LightGray"/>
                <sfListView:SfListView x:Name="listView" ItemSpacing="5" ItemsSource="{Binding Items}" SelectionMode="Single" Grid.Row="1">
                    <sfListView:SfListView.ItemTemplate>
                        <DataTemplate>
                            <Grid x:Name="grid" RowSpacing="1">
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="*" />
                                </Grid.RowDefinitions>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="50" />
                                    <ColumnDefinition Width="*" />
                                </Grid.ColumnDefinitions>
                                <Image Source="{Binding ContactImage}" VerticalOptions="Center" HorizontalOptions="Center" HeightRequest="50"/>
                                <Label Grid.Column="1" VerticalOptions="Center" HorizontalOptions="StartAndExpand" LineBreakMode="NoWrap" Text="{Binding ContactName}" FontSize="Medium" />
                            </Grid>
                        </DataTemplate>
                    </sfListView:SfListView.ItemTemplate>
                </sfListView:SfListView>
            </Grid>
        </DataTemplate>
    </popup:SfPopup.ContentTemplate>
</popup:SfPopup>
```

**C#**

You can access the ListView instance using the ChildAdded event or the FindByName method in behavior.

```
public class GridBehavior : Behavior<Grid>
{
    Grid grid;
    SfListView listView;
    Button button;
    
    protected override void OnAttachedTo(BindableObject bindable)
    {
        grid = bindable as Grid;
        grid.ChildAdded += Grid_ChildAdded;
    }
    
   //Method 1 : Get SfListView reference using Grid.ChildAdded Event
    private void Grid_ChildAdded(object sender, ElementEventArgs e)
    {
        if (e.Element is SfListView)
        {
            listView = e.Element as SfListView;
            listView.RefreshView();
        }
    }

    protected override void OnDetachingFrom(BindableObject bindable)
    {
        grid.ChildAdded -= Grid_ChildAdded;
        listView = null;
        grid = null;
        base.OnDetachingFrom(bindable);
    }
}
```

**C#**

You can also get the ListView using [FindByName](https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.element.findbyname?view=net-maui-8.0) method from the Parent element.
```
public class GridBehavior : Behavior<Grid>
{
    Grid grid;
    SfListView listView;
    Button button;
    
    protected override void OnAttachedTo(BindableObject bindable)
    {
        grid = bindable as Grid;
        grid.ChildAdded += Grid_ChildAdded;
    }
    
    //Method 1 : Get SfListView reference using Grid.ChildAdded Event
    private void Grid_ChildAdded(object sender, ElementEventArgs e)
    {
        if (e.Element is Button)
        {
            button = e.Element as Button;
            button.Clicked += Button_Clicked;
        }
    }
    
    //Method 2 : Get SfListView reference using FindByName
    private void Button_Clicked(object sender, EventArgs e)
    {
        listView = grid.FindByName<SfListView>("listView");
        App.Current.MainPage.DisplayAlert("Information", "ListView instance obtained", "Ok");
        listView.ItemTapped += ListView_ItemTapped;
    }

    private void ListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Information", "ListView ItemTapped", "Ok");
    }

    protected override void OnDetachingFrom(BindableObject bindable)
    {
        button.Clicked -= Button_Clicked;
        grid.ChildAdded -= Grid_ChildAdded;
        listView.ItemTapped -= ListView_ItemTapped;
        listView = null;
        button = null;
        grid = null;
        base.OnDetachingFrom(bindable);
    }
}
```

**Conclusion**

I hope you enjoyed learning how to access a named ListView inside a XAML DataTemplate in .NET MAUI ListView.

You can refer to our [.NET MAUI ListView feature tour](https://www.syncfusion.com/maui-controls/maui-listview) page to know about its other groundbreaking feature representations and [documentation](https://help.syncfusion.com/maui/listview/getting-started), and how to quickly get started with configuration specifications. You can also explore our [.NET MAUI ListView example](https://github.com/syncfusion/maui-demos/tree/master/MAUI/ListView) to understand how to create and manipulate data.

You can check out our components from the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page for current customers. If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui/confirm) to check out our other controls.

Please let us know in the comments section below if you have any queries or require clarification. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
