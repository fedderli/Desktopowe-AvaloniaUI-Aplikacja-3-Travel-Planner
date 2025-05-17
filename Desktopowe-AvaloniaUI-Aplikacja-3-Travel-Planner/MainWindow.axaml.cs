using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Desktopowe_AvaloniaUI_Aplikacja_3_Travel_Planner;

public partial class MainWindow : Window
{
    private string[] Cities = [];
    int attractionCount = 0;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TravelSummary(object? sender, RoutedEventArgs e)
    {
        string name = NameTextBox.Text ?? "No name";
        if (name.Trim() == "" ) name = "No name";
        
        string lastName = LastNameTextBox.Text ?? "No last name";
        if (lastName.Trim() == "" ) lastName = "No last name";
        
        string comboBoxValue = (countryComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";
        
        
        string museums = "";
        string nationalParks = "";
        string monuments = "";
        string restaurants = "";
        string artGalleries = "";
        string festivalsAndConcerts = "";

        string checkBoxy;
        
        CheckBoxHandler(MuseumsCheckBox, "Muzea,", ref museums);
        CheckBoxHandler(NationalParksCheckBox, "Parki Narodowe,", ref nationalParks);
        CheckBoxHandler(MonumentsCheckBox, "Zabytki,", ref monuments);
        CheckBoxHandler(RestaurantsCheckBox, "Restauracje,", ref restaurants);
        CheckBoxHandler(ArtGalleriesCheckBox, "Galerie sztuki,", ref artGalleries);
        CheckBoxHandler(FestivalsAndConcertsCheckBox, "Festiwale i Koncerty", ref festivalsAndConcerts);

        if (attractionCount != 0)
        {
            checkBoxy = $"{museums} {nationalParks} {monuments} {restaurants} {artGalleries} {festivalsAndConcerts}";
        }
        else
        {
            checkBoxy = "Brak atrakcji";
        }

        var selectedRadioButton = this.GetLogicalDescendants()
            .OfType<RadioButton>()
            .FirstOrDefault(rb => rb.GroupName == "BrumBrumRadioButton" && rb.IsChecked == true) ; 
        var RadioButtonValue = selectedRadioButton?.Content?.ToString() ?? "No selection"; 
         Console.WriteLine($"środek transportu: {RadioButtonValue}");

         
         
         
         string listboxcontent = "";
            
         foreach (var city in CityListBox.Items)
         {
             listboxcontent += city.ToString() + ", ";
         }
         

         var content = $"Imie : {name} \n" +
                       $"Nazwisko: {lastName}\n" +
                       $"Kraj: {comboBoxValue}\n" +
                       $"Atrakcje: {checkBoxy}\n" +
                       $"Środek transportu: {RadioButtonValue} \n" +
                       $"Miasta do odwiedzenia: {listboxcontent}"; 
                      
         
        var popupWindow = new TravelSummary(content);
        popupWindow.Show();
        attractionCount = 0;
    }
    
    public void CheckBoxHandler(CheckBox attractionValue, string atrakcje, ref string jakasAtrakcja)
    {
        if (attractionValue.IsChecked == true)
        {
            attractionCount++;
            jakasAtrakcja = atrakcje;
        }
    }
    
    private void CityInputOnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            var CityName = CityInputTextBox.Text.Trim();
            
            CityListBox.Items.Add(CityName);
            CityInputTextBox.Clear();

            
        }
    }

    private void CountryComboBoxChanged(Object sender, SelectionChangedEventArgs e)
    {
        string comboBoxValue = (countryComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "No selection";

        string? imagePath = comboBoxValue switch
        {
            "Japonia" => "avares://Desktopowe-AvaloniaUI-Aplikacja-3-Travel-Planner/Assets/Images/Japonia.png",
            "Włochy" => "avares://Desktopowe-AvaloniaUI-Aplikacja-3-Travel-Planner/Assets/Images/Włochy.png",
            "Turcja" => "avares://Desktopowe-AvaloniaUI-Aplikacja-3-Travel-Planner/Assets/Images/Turcja.png",
            "Portugalia" => "avares://Desktopowe-AvaloniaUI-Aplikacja-3-Travel-Planner/Assets/Images/Portugalia.png",
            "Norwegia" => "avares://Desktopowe-AvaloniaUI-Aplikacja-3-Travel-Planner/Assets/Images/Norwegia.png",
            "Korea południowa" => "avares://Desktopowe-AvaloniaUI-Aplikacja-3-Travel-Planner/Assets/Images/Korea.png",
            "Wielka Brytania" => "avares://Desktopowe-AvaloniaUI-Aplikacja-3-Travel-Planner/Assets/Images/WielkaBrytania.png",
            _ => null
        };

        
        if (imagePath != null)
        {
            var uri = new Uri(imagePath);
            using var stream = AssetLoader.Open(uri);
            CountryImage.Source = new Bitmap(stream);
        }
    }
}