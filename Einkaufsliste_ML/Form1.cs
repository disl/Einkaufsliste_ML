using Akavache;
using System.Reactive.Linq;
using System.Reflection;

namespace Einkaufsliste_ML
{
    public partial class Form1 : Form
    {
        private IEnumerable<string> m_categories_in_cache;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string appName = Assembly.GetEntryAssembly()?.GetName().Name ?? "UnknownApp";
            BlobCache.ApplicationName = appName;

            m_categories_in_cache = await BlobCache.LocalMachine.GetAllKeys();
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetData();
            }
        }

        private void GetData()
        {
            string[] strings = textBox1.Text.Split(new char[] { ';' });

            if (strings.Length > 0)
            {
                dataSet1.PredictionType.Rows.Clear();

                foreach (string s in strings)
                {
                    MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
                    {
                        Col0 = s,
                    };
                    var sortedScoresWithLabel = MLModel1.PredictAllLabels(sampleData);
                    if (sortedScoresWithLabel != null && sortedScoresWithLabel.Count() > 0)
                    {
                        var predicted_item = sortedScoresWithLabel.FirstOrDefault();

                        dataSet1.PredictionType.AddPredictionTypeRow(s, predicted_item.Key, Convert.ToDecimal(predicted_item.Value));
                    }
                }
                ApplyLocalTypes();
            }
        }

        private async void ApplyLocalTypes()
        {
            foreach (var item in dataSet1.PredictionType)
            {
                if (m_categories_in_cache.Contains(item.Article))
                {
                    var local_category = await BlobCache.LocalMachine.GetObject<string?>(item.Article);
                    if (local_category != null)
                    {
                        var row_searched = dataSet1.PredictionType.FindByArticle(item.Article);
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
            /*
                // Objekt speichern
                await BlobCache.LocalMachine.InsertObject("Artikel-123", "Elektronik", TimeSpan.FromDays(1));

                // Objekt abrufen
                string kategorie = await BlobCache.LocalMachine.GetObject<string>("Artikel-123");
             */
            await BlobCache.LocalMachine.InsertObject(articleTextBox.Text, categorieTextBox.Text, TimeSpan.FromDays(1));
            m_categories_in_cache = await BlobCache.LocalMachine.GetAllKeys();
            GetData();

        }

        private async void category_deleteButton_Click(object sender, EventArgs e)
        {
            await BlobCache.LocalMachine.Invalidate(articleTextBox.Text);
            m_categories_in_cache = await BlobCache.LocalMachine.GetAllKeys();
            GetData();
        }
    }



}
