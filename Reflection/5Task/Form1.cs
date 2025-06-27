using System;
using System.Reflection;
using System.Windows.Forms;

namespace _5Task
{
    /*Створіть програму-рефлектор, яка дозволить отримати інформацію про складання та типи, що входять до її складу.
     * Для основи можна використовувати програму-рефлектор із уроку.*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxLoadInfo.ScrollBars = ScrollBars.Vertical;
            textBoxLoadInfo.WordWrap = false;
        }

        private void btnLoadAssembly_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Assemblies (*.dll;*.exe)|*.dll;*.exe|All files (*.*)|*.*";
            dlg.Title = "Виберіть збірку";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dlg.FileName);

                    textBoxLoadInfo.Clear();

                    textBoxLoadInfo.AppendText($"Збірка: {assembly.FullName}{Environment.NewLine}");
                    textBoxLoadInfo.AppendText("Типи у збірці:" + Environment.NewLine);

                    Type[] types = assembly.GetTypes();
                    foreach (var type in types)
                    {
                        textBoxLoadInfo.AppendText($"- {type.FullName}{Environment.NewLine}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при завантаженні збірки: " + ex.Message);
                }
            }
        }
    }
}
