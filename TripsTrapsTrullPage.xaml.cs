namespace Grid_Elemendid_Trips_traps_trull;

public partial class TripsTrapsTrullPage : ContentPage
{
    Grid gr3x3;
    Button btnrandom, btn_uusmang, btn_tulemus;
    Frame[,] frames = new Frame[3, 3];
    Label[,] labels = new Label[3, 3];
    string mangija = "X";
    string bot = "O";
    bool mangulopp = false;
    string varv;
    Random rnd = new Random();
    Picker picker, pickervarv, pickermangija;

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

        btn_tulemus = new Button
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
        btn_tulemus.Clicked += Btn_tulemus_Clicked;

        picker = new Picker
        {
            Title = "Mänguvälja suuruse valimine",
            ItemsSource = new List<string> { "3x3", "4x4", "5x5", "6x6" },
            SelectedIndex = 0
        };
        picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

        pickermangija = new Picker
        {
            Title = "Mängija valik",
            ItemsSource = new List<string> { "X", "O" },
            SelectedIndex = 0
        };
        pickermangija.SelectedIndexChanged += Pickermangija_SelectedIndexChanged;

        pickervarv = new Picker
        {
            Title = "Värvide valik",
            ItemsSource = new List<string> { "Punane", "Sinine" },
            SelectedIndex = 0
        };
        pickervarv.SelectedIndexChanged += Pickervarv_SelectedIndexChanged;

        Content = new VerticalStackLayout
        {
            Children =
            {
                picker,
                pickermangija,
                pickervarv,
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

    private void Btn_tulemus_Clicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Pickervarv_SelectedIndexChanged(object? sender, EventArgs e)
    {
        varv = pickervarv.SelectedItem.ToString();
        if (varv == "Punane")
        {
            btnrandom.TextColor = Color.FromArgb("#FF0000");
        }
        else if (varv == "Sinine")
        {
            btnrandom.TextColor = Color.FromArgb("#4169E1");
        }
    }

    private void Picker_SelectedIndexChanged(object? sender, EventArgs e)
    {
        int uus_suurus = int.Parse(((Picker)sender).SelectedItem.ToString().Substring(0, 1));
        EhitadaGrid(uus_suurus);

        if (picker.SelectedItem.ToString() == "3x3")
        {
            gr3x3.BackgroundColor = Color.FromArgb("#FFF0F5"); 
        }
        else if (picker.SelectedItem.ToString() == "4x4")
        {
            gr3x3.BackgroundColor = Color.FromArgb("#CD5C5C"); 
        }
        else if (picker.SelectedItem.ToString() == "5x5")
        {
            gr3x3.BackgroundColor = Color.FromArgb("#00BFFF"); 
        }
        else if (picker.SelectedItem.ToString() == "6x6")
        {
            gr3x3.BackgroundColor = Color.FromArgb("#C71585"); 
        }
    }
    private void Pickermangija_SelectedIndexChanged(object? sender, EventArgs e)
    {
        mangija = pickermangija.SelectedItem.ToString();
    }

    private void EhitadaGrid(int suurus)
    {
        gr3x3.Clear();
        gr3x3.RowDefinitions.Clear();
        gr3x3.ColumnDefinitions.Clear();

        labels = new Label[suurus, suurus];
        frames = new Frame[suurus, suurus];

        for (int i = 0; i < suurus; i++)
        {
            gr3x3.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            gr3x3.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        for (int i = 0; i < suurus; i++)
        {
            for (int j = 0; j < suurus; j++)
            {
                labels[i, j] = new Label
                {
                    Text = "",
                    FontSize = suurus > 4 ? 16 : 20, 
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
        mangulopp = false;
    }

    private void Btnrandom_Clicked(object sender, EventArgs e)
    {
        mangija = rnd.Next(2) == 0 ? "X" : "O";
        btnrandom.Text = mangija;
        if (mangija == "X")
        {
            btnrandom.TextColor = Color.FromArgb("#FF0000");
        }
        else
        {
            btnrandom.TextColor = Color.FromArgb("#4169E1");
        }
    }
    public class MangudeAjalugu
    {
        public List<string> Tulemus { get; set; } = new List<string>();
        public void AddTulemus(string tulemus)
        {
            Tulemus.Add(tulemus);
        }
        public string Ajalugu()
        {
            if (Tulemus.Count == 0)
                return "";
            return string.Join("\n", Tulemus);
        }
    }
}
