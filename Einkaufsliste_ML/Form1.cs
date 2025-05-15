using Akavache;
using System.Reactive.Linq;
using System.Reflection;

namespace Einkaufsliste_ML
{
    public partial class Form1 : Form
    {
        private IEnumerable<string> m_categories_in_cache;
        private List<Color> m_colors = new();
        private bool m_is_dark_theme = true;
        List<Categories_listType> m_Categoeies_listType_list = new List<Categories_listType>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string appName = Assembly.GetEntryAssembly()?.GetName().Name ?? "UnknownApp";
            BlobCache.ApplicationName = appName;

            m_categories_in_cache = await BlobCache.LocalMachine.GetAllKeys();

            InitColors();

        }

        private void InitColors()
        {
            m_colors=new List<Color>();

            if (m_is_dark_theme)
            {
                m_colors.Add(Color.Yellow);
                m_colors.Add(Color.Lime);
                m_colors.Add(Color.Cyan);
                m_colors.Add(Color.HotPink);
                m_colors.Add(Color.Orange);
                m_colors.Add(Color.Orchid);
                m_colors.Add(Color.Gold);
                m_colors.Add(Color.Red);
                m_colors.Add(Color.LimeGreen);
                m_colors.Add(Color.Turquoise);
                m_colors.Add(Color.Magenta);
                m_colors.Add(Color.Coral);
                m_colors.Add(Color.SkyBlue);
                m_colors.Add(Color.Aqua);
                m_colors.Add(Color.FromArgb(255, 239, 0));  // Canary Yellow
                m_colors.Add(Color.FromArgb(0, 71, 171));      // Cobalt Blue
                m_colors.Add(Color.FromArgb(224, 17, 95));        // Ruby Red
                m_colors.Add(Color.FromArgb(76, 187, 23));     // Kelly Green
                m_colors.Add(Color.FromArgb(153, 102, 204));     // Amethyst
                m_colors.Add(Color.FromArgb(255, 20, 147));      // Deep Pink
            }
            else
            {
                m_colors.Add(Color.FromArgb(0, 0, 128));    // Navy Blue
                m_colors.Add(Color.DarkRed);
                m_colors.Add(Color.ForestGreen);
                m_colors.Add(Color.Indigo);
                m_colors.Add(Color.RoyalBlue);
                m_colors.Add(Color.FromArgb(204, 85, 0));   // Burnt Orange
                m_colors.Add(Color.DarkMagenta);
                m_colors.Add(Color.FromArgb(0, 128, 0));    // Emerald Green
                m_colors.Add(Color.FromArgb(101, 67, 33));  // Chocolate Brown
                m_colors.Add(Color.FromArgb(128, 0, 32));   // Burgundy
                m_colors.Add(Color.OliveDrab);
                m_colors.Add(Color.DarkSlateGray);
                m_colors.Add(Color.SaddleBrown);
                m_colors.Add(Color.MidnightBlue);
                m_colors.Add(Color.DarkOliveGreen);
                m_colors.Add(Color.FromArgb(0, 71, 171));      // Cobalt Blue
                m_colors.Add(Color.FromArgb(224, 17, 95));        // Ruby Red
                m_colors.Add(Color.FromArgb(76, 187, 23));     // Kelly Green
                m_colors.Add(Color.FromArgb(153, 102, 204));     // Amethyst
                m_colors.Add(Color.FromArgb(255, 20, 147));      // Deep Pink
            }
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await GetData();
            }
        }

        private async Task GetData()
        {
            string[] strings = textBox1.Text.Split(new char[] { ';' });

            if (strings.Length > 0)
            {
                dataSet1.PredictionType.Rows.Clear();

                foreach (string s in strings)
                {
                    if (string.IsNullOrEmpty(s))
                        continue;

                    var first_word = s.Split(' ')[0];

                    MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
                    {
                        Col0 = s,
                    };
                    var sortedScoresWithLabel = MLModel1.PredictAllLabels(sampleData);
                    if (sortedScoresWithLabel != null && sortedScoresWithLabel.Count() > 0)
                    {
                        var predicted_item = sortedScoresWithLabel.FirstOrDefault();

                        dataSet1.PredictionType.AddPredictionTypeRow(
                            s,
                            predicted_item.Key,
                            Convert.ToDecimal(predicted_item.Value));
                    }
                }

                await ApplyLocalTypes();

                dataGridView1.Refresh();

                SetRowColors();
            }
        }

        private void SetRowColors()
        {
            m_Categoeies_listType_list.Clear();
            var categoeies_list = dataSet1.PredictionType.Select(x => x.Category).Distinct().ToList();
            List<Color> randomColors = GetRandomColors(m_colors, categoeies_list.Count).Distinct().ToList();

            for (int i = 0; i < categoeies_list.Count; i++)
            {
                m_Categoeies_listType_list.Add(new Categories_listType(categoeies_list[i], randomColors[i]));
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[CategorieColumn.Index].Style.BackColor=Color.White;

                if (row.Cells[categoryDataGridViewTextBoxColumn.Index].Value != null)
                    row.Cells[CategorieColumn.Index].Style.BackColor= 
                        GetColorByCategorie(row.Cells[categoryDataGridViewTextBoxColumn.Index].Value.ToString());                                    
            }
        }

        private Color GetColorByCategorie(string category)
        {
            return m_Categoeies_listType_list.First(x => x.Category == category).Color;
        }

        private List<Color> GetRandomColors(List<Color> allColors, int count)
        {
            if (count > allColors.Count)
                throw new ArgumentException("Anzahl darf nicht größer als die Liste sein!");

            Random random = new Random();
            HashSet<Color> selectedColors = new HashSet<Color>();

            while (selectedColors.Count < count)
            {
                int randomIndex = random.Next(allColors.Count);
                selectedColors.Add(allColors[randomIndex]);
            }

            return new List<Color>(selectedColors);
        }

        private async Task ApplyLocalTypes()
        {
            foreach (var item in dataSet1.PredictionType)
            {
                var first_word = item.Article.Split(" ")[0];

                if (m_categories_in_cache.Contains(first_word))
                {
                    var local_category = await BlobCache.LocalMachine.GetObject<string?>(first_word);
                    if (local_category != null)
                    {
                        var row_searched = dataSet1.PredictionType.FirstOrDefault(x=>x.Article.Split(" ")[0].Equals(first_word, StringComparison.CurrentCultureIgnoreCase)); // .FindByArticle(first_word);
                        if (row_searched != null)
                        {
                            var ind = dataSet1.PredictionType.Rows.IndexOf(row_searched);
                            if (ind != -1)
                            {
                                dataSet1.PredictionType[ind].Category = local_category;
                            }
                        }
                    }
                }
            }
        }

        private async void category_saveButton_Click(object sender, EventArgs e)
        {
            var first_word = articleTextBox.Text.Split(" ")[0];

            await BlobCache.LocalMachine.InsertObject(first_word, categorieTextBox.Text, TimeSpan.FromDays(1));
            m_categories_in_cache = await BlobCache.LocalMachine.GetAllKeys();
            await GetData();

        }

        private async void category_deleteButton_Click(object sender, EventArgs e)
        {
            var first_word = articleTextBox.Text.Split(" ")[0];

            await BlobCache.LocalMachine.Invalidate(first_word);
            m_categories_in_cache = await BlobCache.LocalMachine.GetAllKeys();
            await GetData();
        }
    }

    internal class Categories_listType
    {
        public Categories_listType(string category, Color color)
        {
            Category=category;
            Color=color;
        }

        public string Category { get; set; }
        public Color Color { get; set; }
    }

}
