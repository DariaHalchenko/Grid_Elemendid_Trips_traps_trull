namespace Grid_Elemendid_Trips_traps_trull;

public partial class TripsTrapsTrullPage : ContentPage
{
    Grid gr3x3;
    Button btnrandom, btn_uusmang;
    Frame[,] frames = new Frame[3, 3];
    Label[,] labels = new Label[3, 3];
    string mangija = "X";
    Random rnd = new Random();

    public TripsTrapsTrullPage()
    {
        gr3x3 = new Grid
        {
            BackgroundColor = Color.FromArgb("#FFF0F5"), 
            Padding = 20
        };
        for (int i = 0; i < 3; i++)
        {
            gr3x3.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gr3x3.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                labels[i, j] = new Label
                {
                    Text = "",
                    FontSize = 20,
                    FontFamily = "Luismi Murder 400.ttf",
                    FontAttributes = FontAttributes.Bold,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                frames[i, j] = new Frame
                {
                    BorderColor = Color.FromArgb("#F08080"),
                    BackgroundColor = Color.FromArgb("#FFF0F5"),
                    Content = labels[i, j]
                };

                gr3x3.Add(frames[i, j], j, i);
            }
        }

        btnrandom = new Button
        {
            Text = "Kes on esimene?",
            BackgroundColor = Color.FromArgb("#FFE4E1"),
            TextColor = Color.FromArgb("#FF0000"),
            FontFamily = "Luismi Murder 400.ttf",
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            BorderWidth = 2,
            BorderColor = Color.FromArgb("#CD5C5C"),
            HorizontalOptions = LayoutOptions.Center
        };
        btnrandom.Clicked += Btnrandom_Clicked;

        btn_uusmang = new Button
        {
            Text = "Uus mäng",
            BackgroundColor = Color.FromArgb("#FFE4E1"),
            TextColor = Color.FromArgb("#FF0000"),
            FontFamily = "Luismi Murder 400.ttf",
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            BorderWidth = 2,
            BorderColor = Color.FromArgb("#CD5C5C"),
            HorizontalOptions = LayoutOptions.Center
        };
        btn_uusmang.Clicked += Btn_uusmang_Clicked;

        Content = new VerticalStackLayout
        {
            Children =
            {
                gr3x3,
                new HorizontalStackLayout
                {
                    Children =
                    {
                        btnrandom,
                        btn_uusmang
                    }
                }
            }
        };
    }

    private void Btn_uusmang_Clicked(object sender, EventArgs e)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                labels[i, j].Text = "";
            }
        }
        mangija = "X";
    }

    private void Btnrandom_Clicked(object sender, EventArgs e)
    {
        mangija = rnd.Next(2) == 0 ? "X" : "O";
    }
}
