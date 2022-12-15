using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VolkovFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            // выбранное действие
            int selected = actionComboBox.SelectedIndex;
            switch (selected)
            {
                case 0:// Показать сообщение
                    {
                        MessageBox.Show(messageTextBox.Text,
                            "Сообщение");
                    }
                    break;
                case 1:// Записать в поле
                    {
                        if (rusCheckBox.Checked)
                            messageTextBox.Text = "Привет, Мир!";
                        else
                            messageTextBox.Text = "Hello, World!";
                    }
                    break;
                case 2:// Добавить сообщение в список
                    {
                        string text = messageTextBox.Text;
                        if (!string.IsNullOrEmpty(text))
                            messagesListBox.Items.Add(text);
                    }
                    break;
                case 3:// Удалить выбранное сообщение
                    {
                        int selectedItem = messagesListBox.SelectedIndex;
                        if (selectedItem >= 0)
                        {
                            string text =
                                messagesListBox.Items[selectedItem] as string;
                            // запрос подтверждения
                            DialogResult res = MessageBox.Show(
                                "Желаете удалить элемент " + text + "?",
                                "Удаление сообщения", MessageBoxButtons.YesNo);
                            if (res == DialogResult.Yes)
                                messagesListBox.Items.RemoveAt(selectedItem);
                        }
                    }
                    break;
                case 4:// Очистить список
                    {
                        // запрос подтверждения
                        DialogResult res = MessageBox.Show(
                            "Желаете очистить список сообщений?",
                            "Очистка списка сообщений", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                            messagesListBox.Items.Clear();
                    }
                    break;
                case 5:
                    {
                        // Все сообщения в одну строку
                        StringBuilder text = new StringBuilder();
                        for (int i = 0; i < messagesListBox.Items.Count; i++)
                            text.AppendLine(messagesListBox.Items[i].ToString());
                        // Записать текст в текстовое поле
                        textRichTextBox.Text = text.ToString();
                    }
                    break;
                case 6:// Показать изображение
                    {
                        OpenFileDialog dlg = new OpenFileDialog();
                        // Настройка типов файлов
                        dlg.Filter = "Файлы PNG|*.png|Файлы JPEG|*.jpg";
                        dlg.FilterIndex = 1;
                        // Показать окно выбора
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            // открыть изображение
                            pictureBox.ImageLocation = dlg.FileName;
                        }
                    }
                    break;
            }
        }
    }
}
