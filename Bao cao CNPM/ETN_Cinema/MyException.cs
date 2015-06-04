using BUL;
using PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace ETN_Cinema
{
    public class MyException
    {
        List<TextBox> ListOfTextBox;
        List<Label> ListOfLabelTextBox;
        List<Label> ListOfDateTimePickerLabel;
        List<DatePicker> ListOfDatePicker;
        List<Image> ListOfImage;
        List<Label> ListOfImageLabel;
        List<Label> ListOfCheckboxLabel;
        List<CheckBox> ListOfCheckbox;
        public bool IsError = true;
        bool IsChecked = false;
        public MyException()
        {
            ListOfTextBox = new List<TextBox>();
            ListOfLabelTextBox = new List<Label>();
            ListOfDatePicker = new List<DatePicker>();
            ListOfDateTimePickerLabel = new List<Label>();
            ListOfImage = new List<Image>();
            ListOfImageLabel = new List<Label>();
            ListOfCheckbox = new List<CheckBox>();
            ListOfCheckboxLabel = new List<Label>();
        }
        public void AddTextBox(TextBox _element, Label _element_label)
        {
            ListOfTextBox.Add(_element);
            ListOfLabelTextBox.Add(_element_label);
        }

        public void AddDateTimePicker(DatePicker _element, Label _element_label)
        {
            ListOfDatePicker.Add(_element);
            ListOfDateTimePickerLabel.Add(_element_label);
        }

        public void AddImage(Image _element, Label _element_label)
        {
            ListOfImage.Add(_element);
            ListOfImageLabel.Add(_element_label);
        }

        public void AddCheckbox(CheckBox _element, Label _element_label)
        {
            ListOfCheckbox.Add(_element);
            ListOfCheckboxLabel.Add(_element_label);
        }

        public ArgumentException ThrowExceptionForMessageBox()
        {
            for (int i = 0; i < ListOfTextBox.Count; i++)
            {
                if (ListOfTextBox[i].Text == "")
                {
                    throw new ArgumentException("Chưa nhập " + ListOfLabelTextBox[i].Content.ToString());
                }
            }
            for (int i = 0; i < ListOfDatePicker.Count; i++)
            {
                if (ListOfDatePicker[i].SelectedDate == null)
                {
                    throw new ArgumentException("Chưa nhập " + ListOfDateTimePickerLabel[i].Content.ToString());
                }
            }
            for (int i = 0; i < ListOfImage.Count; i++)
            {
                if (ListOfImage[i].Source == null)
                {
                    throw new ArgumentException("Chưa nhập " + ListOfImageLabel[i].Content.ToString());
                }
            }
            for (int i = 0; i < ListOfCheckbox.Count; i++)
            {
                if (ListOfCheckbox[i].IsChecked == true)
                {
                    IsChecked = true;
                }
                if (!IsChecked)
                {
                    throw new ArgumentException("Chưa nhập " + ListOfCheckboxLabel[i].Content.ToString());
                }
            }
            IsError = false;
            return null;
        }

        public void ShowMessageBox()
        {
            try
            {
                this.ThrowExceptionForMessageBox();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
