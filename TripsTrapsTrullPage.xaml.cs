namespace Grid_Elemendid_Trips_traps_trull;

using System.Threading.Tasks;

public partial class TripsTrapsTrullPage : ContentPage
{
    Grid gr3x3;
    Button btn, btn_uusmang, btn_tulemus, btn_mangureeglid;
    Frame[,] frames;
    Label[,] labels;
    Label lblStatistics;
    string mangija = "X";
    string bot = "O";
    bool mangulopp = false;
    Random rnd = new Random();
    int gridsuurus = 3;
    Picker picker, pickervarv, pickermangija;
    string varv;
    Color xColor, oColor;
    List<string> ManguTulemus = new List<string>(); 
    Stepper stlabipaistvus;
    int mangijaVoit = 0;
    int botVoit= 0;

    public TripsTrapsTrullPage()
    {
        xColor = Color.FromArgb("#7CFC00");  
        oColor = Color.FromArgb("#191970");  

        gr3x3 = new Grid();
        EhitadaGrid(gridsuurus);

        btn = new Button
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
        btn.Clicked += Btn_Clicked;

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
        
        picker = new Picker
        {
            Title = "Mänguvälja suuruse valimine",
            ItemsSource = new List<string> { "3x3", "4x4", "5x5", "6x6" },
            SelectedIndex = 0
        };
        picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

        pickervarv = new Picker
        {
            Title = "Värvide valik",
            ItemsSource = new List<string> { "Punane", "Sinine", "Roheline", "Kollane",
            "Oranz", "Roosa", "Pruun", "Lilla" },
            SelectedIndex = 0
        };
        pickervarv.SelectedIndexChanged += Pickervarv_SelectedIndexChanged;

        pickermangija = new Picker
        {
            Title = "Mängija valik",
            ItemsSource = new List<string> { "X", "O" },
            SelectedIndex = 0
        };
        pickermangija.SelectedIndexChanged += Pickermangija_SelectedIndexChanged;

        btn_tulemus = new Button
        {
            Text = "Tulemus",
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

        btn_mangureeglid = new Button
        {
            Text = "Mängureeglid ",
            BackgroundColor = Color.FromArgb("#FFE4E1"),
            TextColor = Color.FromArgb("#FF0000"),
            FontFamily = "Luismi Murder 400.ttf",
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            BorderWidth = 2,
            BorderColor = Color.FromArgb("#CD5C5C"),
            HorizontalOptions = LayoutOptions.Center
        };
        btn_mangureeglid.Clicked += Btn_mangureeglid_Clicked;

        stlabipaistvus = new Stepper
        {
            Minimum = 0,
            Maximum = 1,
            Increment = 0.1,
            Value = 1,
            HorizontalOptions = LayoutOptions.Center
        };
        stlabipaistvus.ValueChanged += Stlabipaistvus_ValueChanged;

        lblStatistics = new Label
        {
            Text = "Mängija: 0, Bot: 0",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        Content = new VerticalStackLayout
        {
            Children =
            {
                lblStatistics,
                picker,
                pickervarv,
                pickermangija,
                gr3x3,
                new HorizontalStackLayout
                {
                    Children = { btn, btn_uusmang, btn_tulemus }
                },
                new HorizontalStackLayout
                {
                    Children = { btn_mangureeglid, stlabipaistvus }
                }
            }
        };
    }

    //Правила игры
    private async void Btn_mangureeglid_Clicked(object? sender, EventArgs e)
    {
        string rules = "Mängureeglid 'Trips traps trull':\n\n" +
                    "1. Mängu mängitakse 3x3 väljakul (mänguvälja saab ise valida)..\n" +
                    "2. Mängijad paigutavad kordamööda oma sümboli (X või O) tühjale ruudule..\n" +
                    "3. Eesmärk on panna kolm sümbolit järjestikku horisontaalselt, vertikaalselt või diagonaalselt.\n" +
                    "4. Kui kogu väljak on täis ja võitjat ei ole, lõpeb mäng viik.\n\n" +
                    "Palju õnne mänguga!";
        
        await DisplayAlert("Mängureeglid", rules, "OK");
    }
    //Прозрачность поля
    private void Stlabipaistvus_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        float labipaistvus = (float)stlabipaistvus.Value;
        for (int i = 0; i < gridsuurus; i++)
        {
            for (int j = 0; j < gridsuurus; j++)
            {
                frames[i, j].BackgroundColor = frames[i, j].BackgroundColor.WithAlpha(labipaistvus);
            }
        }
    }

    // При нажатии на кнопку "Tulemus" показываем все результаты игр
    private void Btn_tulemus_Clicked(object? sender, EventArgs e)
    {
        string tulemus = string.Join("\n", ManguTulemus);
        DisplayAlert("Mängude tulemused", tulemus, "Ok");
    }

    //Выбор за кого играть 
    private async void Pickermangija_SelectedIndexChanged(object? sender, EventArgs e)
    {
        mangija = pickermangija.SelectedItem.ToString();  

        if (mangija == "X")
        {
            bot = "O";  
            btn.Text = "Mängija teeb oma käigu";  
        }
        else
        {
            bot = "X";  
            btn.Text = "Bot teeb oma käigu";  
            Btn_uusmang_Clicked(null, null);
            await Botiliikumine();
        }
    }
    //Меняет цвет ячеек
    private void Pickervarv_SelectedIndexChanged(object? sender, EventArgs e)
    {
        varv = pickervarv.SelectedItem.ToString();
        if (varv == "Punane")
        {
            RuudustikuTaustavarviMuutmine(Color.FromArgb("#FF0000"));
        }
        else if (varv == "Sinine")
        {
            RuudustikuTaustavarviMuutmine(Color.FromArgb("#4169E1"));
        }
        else if (varv == "Roheline")
        {
            RuudustikuTaustavarviMuutmine(Color.FromArgb("#008000"));
        }
        else if (varv == "Kollane")
        {
            RuudustikuTaustavarviMuutmine(Color.FromArgb("#FFFF00"));
        }
        else if (varv == "Oranz")
        {
            RuudustikuTaustavarviMuutmine(Color.FromArgb("#FFA500"));
        }
        else if (varv == "Roosa")
        {
            RuudustikuTaustavarviMuutmine(Color.FromArgb("#DA70D6"));
        }
        else if (varv == "Pruun")
        {
            RuudustikuTaustavarviMuutmine(Color.FromArgb("#A52A2A"));
        }
        else if (varv == "Lilla")
        {
            RuudustikuTaustavarviMuutmine(Color.FromArgb("#8A2BE2"));
        }
    }
    // Меняем фон каждой ячейки на выбранный цвет
    private void RuudustikuTaustavarviMuutmine(Color color)
    {
        for (int i = 0; i < gridsuurus; i++)
        {
            for (int j = 0; j < gridsuurus; j++)
            {
                frames[i, j].BackgroundColor = color;
            }
        }
    }
    //Изменение размера игрового поля
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
                    BackgroundColor = Color.FromArgb("#FFFFFF"),
                    Content = labels[i, j]
                };

                // Добавляем обработчик клика для каждой ячейки
                var x = i;
                var y = j;
                frames[i, j].GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(async () => await TehkeValjakulKaik(x, y))
                });

                gr3x3.Add(frames[i, j], j, i);
            }
        }
    }
    private void Picker_SelectedIndexChanged(object? sender, EventArgs e)
    {
        int uus_suurus = int.Parse(((Picker)sender).SelectedItem.ToString().Substring(0, 1));
        gridsuurus = uus_suurus;
        EhitadaGrid(uus_suurus);
    }

    private async Task TehkeValjakulKaik(int i, int j)
    {
        if (mangulopp || !string.IsNullOrEmpty(labels[i, j].Text)) return;

        // Устанавливаем цвет символа
        labels[i, j].TextColor = mangija == "X" ? xColor : oColor;
        labels[i, j].Text = mangija;
        if (VoiduKontroll())
        {
            await DisplayManguTulemus($"{mangija} võitis!"); 
            mangulopp = true;
            return;
        }
        await Task.Delay(500);
        await Botiliikumine();
    }

    private async Task Botiliikumine()
    {
        if (mangulopp) return;

        var tyhjadKohad = new List<(int, int)>();
        for (int i = 0; i < gridsuurus; i++)
            for (int j = 0; j < gridsuurus; j++)
                if (string.IsNullOrEmpty(labels[i, j].Text))
                    tyhjadKohad.Add((i, j));

        if (tyhjadKohad.Count > 0)
        {
            await Task.Delay(500);
            var (x, y) = tyhjadKohad[rnd.Next(tyhjadKohad.Count)];
            
            // Устанавливаем цвет символа бота
            labels[x, y].TextColor = bot == "X" ? xColor : oColor;
            labels[x, y].Text = bot;
            
            if (VoiduKontroll())
            {
                await DisplayManguTulemus($"{bot} võitis!");  
                mangulopp = true;
            }
            // Проверка на ничью
            else if (TasavagineMang())  
            {
                await DisplayManguTulemus("Mäng lõppes viigiga!"); 
                mangulopp = true;
            }
        }
    }

    // Новый метод для отображения результата игры и предложения сыграть снова
    private async Task DisplayManguTulemus(string tulemust)
    {
        ManguTulemus.Add(tulemust);

        if (tulemust.Contains("võitis"))
        {
            if (tulemust.StartsWith(mangija))  // Игрок победил
            {
                mangijaVoit++;
            }
            else if (tulemust.StartsWith(bot))  // Бот победил
            {
                botVoit++;
            }
        }

        lblStatistics.Text = $"Mängija X: {mangijaVoit}, Bot: {botVoit}";  

        bool playAgain = await DisplayAlert("Mäng lõppes", $"{tulemust}\n\nKas soovite uuesti mängida?", "Jah", "Ei");
        if (playAgain)
        {
            Btn_uusmang_Clicked(null, null);  // Начинаем новую игру
        }
    }


    // Метод для проверки ничьей
    private bool TasavagineMang()
    {
        for (int i = 0; i < gridsuurus; i++)
        {
            for (int j = 0; j < gridsuurus; j++)
            {
                if (string.IsNullOrEmpty(labels[i, j].Text)) // Если есть пустые клетки
                {
                    return false;
                }
            }
        }
        return true; // Если пустых клеток нет, значит ничья
    }

    private bool VoiduKontroll()
    {
        // Проверка на горизонтальные линии
        for (int i = 0; i < gridsuurus; i++)
        {
            for (int j = 0; j < gridsuurus - 2; j++)  // -2 чтобы не выходить за границы
            {
                if (!string.IsNullOrEmpty(labels[i, j].Text) &&
                    labels[i, j].Text == labels[i, j + 1].Text &&
                    labels[i, j + 1].Text == labels[i, j + 2].Text)
                {
                    return true; // Победа по горизонтали
                }
            }
        }

        // Проверка на вертикальные линии
        for (int j = 0; j < gridsuurus; j++)
        {
            for (int i = 0; i < gridsuurus - 2; i++)  // -2 чтобы не выходить за границы
            {
                if (!string.IsNullOrEmpty(labels[i, j].Text) &&
                    labels[i, j].Text == labels[i + 1, j].Text &&
                    labels[i + 1, j].Text == labels[i + 2, j].Text)
                {
                    return true; // Победа по вертикали
                }
            }
        }

        // Проверка на диагонали (слева направо)
        for (int i = 0; i < gridsuurus - 2; i++)  // -2 чтобы не выходить за границы
        {
            for (int j = 0; j < gridsuurus - 2; j++)  // -2 чтобы не выходить за границы
            {
                if (!string.IsNullOrEmpty(labels[i, j].Text) &&
                    labels[i, j].Text == labels[i + 1, j + 1].Text &&
                    labels[i + 1, j + 1].Text == labels[i + 2, j + 2].Text)
                {
                    return true; // Победа по диагонали (слева направо)
                }
            }
        }
        // Проверка на диагонали (справа налево)
        for (int i = 0; i < gridsuurus - 2; i++)  // -2 чтобы не выходить за границы
        {
            for (int j = 2; j < gridsuurus; j++)  // Начинаем с 2, чтобы не выйти за границы
            {
                if (!string.IsNullOrEmpty(labels[i, j].Text) &&
                    labels[i, j].Text == labels[i + 1, j - 1].Text &&
                    labels[i + 1, j - 1].Text == labels[i + 2, j - 2].Text)
                {
                    return true; // Победа по диагонали (справа налево)
                }
            }
        }
        return false; // Нет победы
    }


    private void Btn_uusmang_Clicked(object sender, EventArgs e)
    {
        for (int i = 0; i < gridsuurus; i++)
            for (int j = 0; j < gridsuurus; j++)
                labels[i, j].Text = "";
        mangulopp = false;
    }

    private void Btn_Clicked(object sender, EventArgs e)
    {
        mangija = rnd.Next(2) == 0 ? "X" : "O";
        btn.Text = mangija;
    }
}
