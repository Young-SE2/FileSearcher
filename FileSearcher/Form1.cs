using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSearcher
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Программа для поиска и удаления файлов на локальном ЖД (Не работает многопоточность)
        ///Поиск только по дате или размеру будет длится очень долго
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool SearchForName; // Переменная получает true-значение если включен поиск по имени
        private bool SearchForSize; // Переменная получает true-значение если включен поиск по размеру
        private bool SearchForDate; // Переменная получает true-значение если включен поиск по дате создания

        private void Form1_Load(object sender, EventArgs e)
        {
            // Получаем массив всех логических дисков системы
            DriveInfo[] di = DriveInfo.GetDrives();

            //Блокируем кнопки
            cbSizeType.Enabled = false;
            tbSize.Enabled = false;
            tbSizeMax.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            tbName.Enabled = false;
            cbName2.Enabled = false;

            //Устанавливаем допустимые расширения
            cbName2.Items.Add(".jpeg");
            cbName2.Items.Add(".jpg");
            cbName2.Items.Add(".txt");
            cbName2.Items.Add(".doc");
            cbName2.Items.Add(".rar");

            /// Для каждого полученного диска из массива получаем его тип 
            foreach (DriveInfo drive in di)
            {
                string driveSignature = String.Empty;
                switch (drive.DriveType)
                {
                    case DriveType.Fixed:
                        driveSignature = "Локальный диск";
                        break;
                    case DriveType.CDRom:
                        driveSignature = "CD-привод";
                        break;
                    case DriveType.Removable:
                        driveSignature = "Сьемный носитель";
                        break;
                    default:
                        driveSignature = "Другой";
                        break;
                }
                clbDrive.Items.Add(drive.Name+"\t"+driveSignature);
            }
            // Добавляем в список пункт выбора "Другое расположение"
            clbDrive.Items.Add("Другое расположение..."); 
            // Добавляем елементы в выпадной список cbSizeType
            cbSizeType.Items.Add("Mb"); 
            cbSizeType.Items.Add("Gb");
            cbSizeType.Items.Add("Kb");

        }

        private void btClose_Click(object sender, EventArgs e) 
        {
            this.Close(); 
        }

        //Обработчик нажатия "Поиск"
        private void btDoIt_Click(object sender, EventArgs e) 
        {

            //this.Hide();
            
            //Form3 f = new Form3();
            //f.Show();
            

            Form2 f2; //Обьявляем экземпляр класса Form2
            //Создаем список для учета выбранных для поиска локаций
            List<DirectoryInfo> DirList = new List<DirectoryInfo>();

            foreach (var chItem in clbDrive.CheckedItems) 
            {
                if (chItem != clbDrive.Items[clbDrive.Items.Count - 1]) 
                {
                    DirList.Add(new DirectoryInfo(chItem.ToString().Substring(0,3)));
                }
                else 
                {
                    DirList.Add(new DirectoryInfo(clbDrive.Items[clbDrive.Items.Count-1].ToString()));
                }
            }

            //Преобразуем список в массив
            DirectoryInfo[] DirArr = DirList.ToArray(); 

            //Создаем и инициализируем переменную которая будет содержать информацию про состояние поля tbName
            bool NameControl = true;

            if (!SearchForName)
            {
                SearchForName = true;
                this.tbName.Text = "*.*";
                NameControl = false;
            }

            label6.Text = "Идет поиск...";
            label6.Refresh();
            if (SearchForName)
            {
                if (SearchForDate)
                {
                    if (SearchForSize)
                    {
                        f2 = new Form2(DirArr,(tbName.Text + cbName2.Text), dateTimePicker1.Text, dateTimePicker2.Text, tbSize.Text, tbSizeMax.Text);
                    }
                    else
                    {
                        f2 = new Form2(DirArr, (tbName.Text + cbName2.Text), dateTimePicker1.Text, dateTimePicker2.Text);
                    }

                }
                else
                {
                    f2 = new Form2(DirArr, (tbName.Text + cbName2.Text));
                }

                /* Попытка отображения второй формы в диалоговом (модальном) режиме
                 * В случае успеха главная форма ждет возврата управления 
                 * после закрытия второй формы, иначе выводится сообщение про ошибку
                 */
                try
                {
                    f2.Show();
                    if (!NameControl)
                    {
                        SearchForName = false;
                        tbName.Text = "";
                    }
                    label6.Text = "Введите параметры";
                    label6.Refresh();
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        //приватная переменная класса Form1 которая используется 
        //для проверки состояния выбора пункта "Другое расположение"
        private bool OtherIsSelected; 


        private void clbDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Last=clbDrive.Items.Count-1;
            if (clbDrive.CheckedIndices.Contains(Last))
            {
                if (OtherIsSelected == false)
                {
                    folderBrowserDialog1.ShowDialog(); //вызов диалога выбора папки
                    OtherIsSelected = true;
                    //Отображает выбранную папку в списке и отмечает ее
                    clbDrive.Items.Insert(Last,folderBrowserDialog1.SelectedPath); 
                    clbDrive.SetItemChecked(Last, true);
                    clbDrive.Items.Remove(clbDrive.Items[Last+1]);
                }
            }
            else
            {
                OtherIsSelected = false; 
            }
            
            
        }

        private void cbName_CheckedChanged(object sender, EventArgs e) 
        {
            this.SearchForName = cbName.Checked;
            tbName.Enabled = true;
            cbName2.Enabled = true;

            if (cbName.Checked == false)
            {
                tbName.Enabled = false;
                cbName2.Enabled = false;
            }
        }

        private void cbDate_CheckedChanged(object sender, EventArgs e) 
        {
            this.SearchForDate = cbDate.Checked;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;

            if (cbDate.Checked == false)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void cbSize_CheckedChanged(object sender, EventArgs e) 
        {
            this.SearchForSize = cbSize.Checked;
            cbSizeType.Enabled = true;
            tbSize.Enabled = true;
            tbSizeMax.Enabled = true;

            if (cbSize.Checked == false)
            {
                cbSizeType.Enabled = false;
                tbSize.Enabled = false;
                tbSizeMax.Enabled = false;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e) 
        {
            if (tbName.Text != "")
            {
                cbName.CheckState = CheckState.Checked;
            }
            else
            {
                cbName.CheckState = CheckState.Unchecked;
            }
        }
        
        //Включает флажок (комбо-бокс) cbDate при первом изменении даты
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) 
        {
            cbDate.CheckState = CheckState.Checked;
        }

        //Задает размер в Кб по умолчанию
        private void cbSizeType_Click(object sender, EventArgs e) //
        {
            cbSizeType.SelectedItem = cbSizeType.Items[2];
        }

        private void cbSizeType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
