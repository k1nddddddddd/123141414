using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolkovTransportApp
{
    public partial class MainForm : Form
    {
        List<Vehicle> vehicles;
        public MainForm()
        {
            InitializeComponent();
            // список транспортных средств
            vehicles = new List<Vehicle>();

            UpdateStatusBar();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы TXT|*.txt|Все файлы|*.*";
            // выбрать файл
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Открыть файл
                Vehicle.ReadFile(dlg.FileName, vehicles);
                FillListBox(vehicles, vehiclesListBox);
                UpdateStatusBar();
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Текстовые файлы TXT|*.txt|Все файлы|*.*";
            // выбрать файл
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Сохранить файл
                Vehicle.SaveFile(dlg.FileName, vehicles);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            // Закрыть приложение
            Close();
        }

        private void AddVehicle_Click(object sender, EventArgs e)
        {
            // Добавить транспортное средство
            VehicleForm form = new VehicleForm();
            form.Text = "Добавление транспортного средства";
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Добавить транспортное средство в список
                Vehicle v = null;
                switch (form.VehicleType)
                {
                    case VehicleTypes.AirVehicle:
                        v = new AirVehicle(form.VehicleName,
                            form.MaxVolume, form.IntegerValue);
                        v.Volume = form.Volume;
                        break;
                    case VehicleTypes.WaterVehicle:
                        v = new WaterVehicle(form.VehicleName,
                            form.MaxVolume, form.FloatValue);
                        v.Volume = form.Volume;
                        break;
                    case VehicleTypes.LandVehicle:
                        v = new LandVehicle(form.VehicleName,
                            form.MaxVolume, form.IntegerValue);
                        v.Volume = form.Volume;
                        break;
                }
                if (v != null)
                {
                    vehicles.Add(v);
                    vehiclesListBox.Items.Add(v);
                    UpdateStatusBar();
                }
            }
        }

        private void EditVehicle_Click(object sender, EventArgs e)
        {
            int selected = vehiclesListBox.SelectedIndex;
            if (selected >= 0)
            {
                Vehicle v = vehicles[selected];
                // Изменить транспортное средство
                VehicleForm form = new VehicleForm();
                form.Text = "Изменение транспортного средства";
                form.EditMode = true;
                form.VehicleType = v.VehicleType;
                form.VehicleName = v.Name;
                form.MaxVolume = v.MaxVolume;
                form.Volume = v.Volume;
                switch (v.VehicleType)
                {
                    case VehicleTypes.AirVehicle:
                        form.IntegerValue = ((AirVehicle)v).Engines;
                        break;
                    case VehicleTypes.WaterVehicle:
                        form.FloatValue = ((WaterVehicle)v).Displacement;
                        break;
                    case VehicleTypes.LandVehicle:
                        form.IntegerValue = ((LandVehicle)v).Wheels;
                        break;
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // новые значения из формы
                    v.Name = form.VehicleName;
                    v.Volume = form.Volume;

                    // обновить список
                    vehiclesListBox.Items[selected] = v;
                }
            }
        }

        private void DeleteVehicle_Click(object sender, EventArgs e)
        {
            int selected = vehiclesListBox.SelectedIndex;
            if (selected >= 0)
            {
                string question = "Желате удалить " +
                    vehicles[selected].Name + "?";
                DialogResult res = MessageBox.Show(question,
                    "Удаление транспортного средства",
                    MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    vehicles.RemoveAt(selected);
                    vehiclesListBox.Items.RemoveAt(selected);
                    UpdateStatusBar();
                }
            }
        }

        private void SortAZ_Click(object sender, EventArgs e)
        {
            if (vehicles.Count > 0)
            {
                // Сортировка списка
                vehicles.Sort(Vehicle.SortAZ);

                // Обновление списка
                FillListBox(vehicles, vehiclesListBox);
            }
        }

        private void SortZA_Click(object sender, EventArgs e)
        {
            if (vehicles.Count > 0)
            {
                // Сортировка списка
                vehicles.Sort(Vehicle.SortZA);

                // Обновление списка
                FillListBox(vehicles, vehiclesListBox);
            }
        }

        private void Selection_Click(object sender, EventArgs e)
        {

        }

        private void Report_Click(object sender, EventArgs e)
        {

        }

        protected void FillListBox(List<Vehicle> vehicles,
            ListBox listBox)
        {
            // очистить список
            listBox.Items.Clear();
            // добавить элементы в список
            foreach (Vehicle v in vehicles)
                listBox.Items.Add(v);
        }

        protected void UpdateStatusBar()
        {
            infoStatusLabel.Text =
                "Количество транспортных средств: " +
                vehicles.Count.ToString();
        }
    }
}
