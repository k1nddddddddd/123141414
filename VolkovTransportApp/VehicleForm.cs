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
    public partial class VehicleForm : Form
    {
        List<string> characteristicNames;
        double maxVolume;
        double volume;

        int iValue;
        double fValue;

        public VehicleForm()
        {
            InitializeComponent();
            // Список названий характеристик
            characteristicNames = new List<string>();
            characteristicNames.Add("Количество двигателей:");
            characteristicNames.Add("Водоизмещение:");
            characteristicNames.Add("Количество колес:");
            // Начальные значения
            EditMode = false;
            MaxVolume = 1;
            Volume = 0;
            IntegerValue = 0;
        }

        public VehicleTypes VehicleType
        {
            set
            {
                switch (value)
                {
                    case VehicleTypes.AirVehicle:
                        typeComboBox.SelectedIndex = 0;
                        break;
                    case VehicleTypes.WaterVehicle:
                        typeComboBox.SelectedIndex = 1;
                        break;
                    case VehicleTypes.LandVehicle:
                        typeComboBox.SelectedIndex = 2;
                        break;
                    default:
                        typeComboBox.SelectedIndex = -1;
                        break;
                }
            }
            get
            {
                VehicleTypes type = VehicleTypes.Unknown;
                switch (typeComboBox.SelectedIndex)
                {
                    case 0: type = VehicleTypes.AirVehicle; break;
                    case 1: type = VehicleTypes.WaterVehicle; break;
                    case 2: type = VehicleTypes.LandVehicle; break;
                }
                return type;
            }
        }

        public string VehicleName
        {
            set { nameTextBox.Text = value; }
            get { return nameTextBox.Text; }
        }

        public double MaxVolume
        {
            set
            {
                maxVolume = value;
                maxVolumeTextBox.Text = value.ToString();
            }
            get { return maxVolume; }
        }

        public double Volume
        {
            set
            {
                volume = value;
                volumeTextBox.Text = value.ToString();
            }
            get { return volume; }
        }

        public double FloatValue
        {
            set
            {
                fValue = value;
                characteristicTextBox.Text = value.ToString();
            }
            get { return fValue; }
        }

        public int IntegerValue
        {
            set
            {
                iValue = value;
                characteristicTextBox.Text = value.ToString();
            }
            get { return iValue; }
        }

        protected bool CheckData()
        {
            // Тип транспортного средства
            if (typeComboBox.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Не выбран тип транспортного средства!", "");
                return false;
            }
            // Название
            if (string.IsNullOrEmpty(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show(
                   "Не задано название транспортного средства!", "");
                return false;
            }
            // Максимальный объем
            if (!double.TryParse(maxVolumeTextBox.Text,
                out maxVolume))
            {
                MessageBox.Show(
                   "Некорректное значение максимального объема!", "");
                return false;
            }
            // Объем
            if (!double.TryParse(volumeTextBox.Text,
                out volume))
            {
                MessageBox.Show(
                   "Некорректное значение объема!", "");
                return false;
            }
            // Характеристика
            bool res = false;
            switch (typeComboBox.SelectedIndex)
            {
                case 0: // воздушный транспорт
                    res = int.TryParse(characteristicTextBox.Text,
                        out iValue);
                    break;
                case 1: // водный транспорт
                    res = double.TryParse(characteristicTextBox.Text,
                        out fValue);
                    break;
                case 2: // наземный транспорт
                    res = int.TryParse(characteristicTextBox.Text,
                        out iValue);
                    break;
            }
            if (!res)
            {
                string text = "Некорректное значение в поле " +
                    characteristicNames[typeComboBox.SelectedIndex] + "!";
                MessageBox.Show(text, "");
                return false;
            }

            return true;
        }

        public bool EditMode
        {
            set
            {
                typeComboBox.Enabled = !value;
                maxVolumeTextBox.Enabled = !value;
                characteristicTextBox.Enabled = !value;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                // Проверка прошла успешно
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Type_Changed(object sender, EventArgs e)
        {
            if (typeComboBox.SelectedIndex >= 0)
            {
                characteristicLabel.Text =
                    characteristicNames[typeComboBox.SelectedIndex];
            }
        }
    }
}
