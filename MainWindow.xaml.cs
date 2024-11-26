using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CalendarWithNotes
{
    public partial class MainWindow : Window
    {
        private Dictionary<DateTime, string> notes = new Dictionary<DateTime, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //Проверка на наличие выбранной даты
            if (calendar.SelectedDate.HasValue)
            {
                DateTime selectedDate = calendar.SelectedDate.Value;
                //Проверка наличия заметки для выбранной даты
                if (notes.TryGetValue(selectedDate, out string note))
                {
                    txtNote.Text = note;
                }
                else
                {
                    txtNote.Text = "";
                }
            }
        }

        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            if (calendar.SelectedDate.HasValue)
            {
                DateTime selectedDate = calendar.SelectedDate.Value;
                // Добавляем или обновляем заметку
                notes[selectedDate] = txtNote.Text;
            }
        }

        private void btnRemoveNote_Click(object sender, RoutedEventArgs e)
        {
            if (calendar.SelectedDate.HasValue)
            {
                DateTime selectedDate = calendar.SelectedDate.Value;
                if (notes.ContainsKey(selectedDate))
                {
                    notes.Remove(selectedDate);
                    txtNote.Text = "";
                }
            }
        }
    }
}