namespace Einkaufsliste_ML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            List<KeyValuePair<string,float>> list_output = new ();

            if (e.KeyCode == Keys.Enter)
            {
                string[] strings = textBox1.Text.Split(new char[] { ';' });

                if (strings.Length > 0)
                {
                    dataGridView1.DataSource=null;

                    foreach (string s in strings)
                    {
                        MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
                        {
                            Col0 = s,
                        };
                        var sortedScoresWithLabel = MLModel1.PredictAllLabels(sampleData);
                        if(sortedScoresWithLabel != null && sortedScoresWithLabel.Count() > 0)
                        {
                            var predicted_item = sortedScoresWithLabel.FirstOrDefault();

                            list_output.Add(predicted_item);
                        }
                    }

                    dataGridView1.DataSource = list_output;
                }
            }
        }
    }



}
