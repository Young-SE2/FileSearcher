using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FileSearcher
{
    
    public partial class Form2 : Form
    {
        public Form2(DirectoryInfo[] di,string Name)
        {
            this.DirInf = di;
            this.FileName = Name;
            this.BegDate = DateTime.MinValue;
            this.EndDate = DateTime.MaxValue;
            this.MinSize = 0;
            this.MaxSize = Int32.MaxValue;
            InitializeComponent();
            this.lbProgress.Text = "Searching...";
            //При выводе формы на экран запускает метод DoItParallel 
            //для каждой директории заданной в массиве локаций для поиска
            foreach (DirectoryInfo dinf in this.DirInf)
            {
                this.DoItParalell(dinf);
            }
        }
        public Form2(DirectoryInfo[] di,string Name,string BegDate, string EndDate)
        {
            this.DirInf = di;
            this.FileName = Name;
            this.BegDate = DateTime.Parse(BegDate);
            this.EndDate = DateTime.Parse(EndDate);
            this.MinSize = 0;
            this.MaxSize = Int32.MaxValue;
            InitializeComponent();

            this.lbProgress.Text = "Searching...";
            //При выводе формы на экран запускает метод DoItParallel 
            //для каждой директории заданной в массиве локаций для поиска
            foreach (DirectoryInfo dinf in this.DirInf)
            {
                this.DoItParalell(dinf);
            }
        }
        public Form2(DirectoryInfo[] di,string Name, string BegDate, string EndDate,string MinSize,string MaxSize)
        {
            this.DirInf = di;
            this.FileName = Name;
            this.BegDate = DateTime.Parse(BegDate);
            this.EndDate = DateTime.Parse(EndDate);
            Int32.TryParse(MinSize,out this.MinSize);
            Int32.TryParse(MaxSize, out this.MaxSize);
            if (this.MaxSize == 0) this.MaxSize = Int32.MaxValue;
            InitializeComponent();
            this.lbProgress.Text = "Searching...";
            //При выводе формы на экран запускает метод DoItParallel 
            //для каждой директории заданной в массиве локаций для поиска
            foreach (DirectoryInfo dinf in this.DirInf)
            {
                this.DoItParalell(dinf);
            }
        }

        //приватные переменные соответствующие параметрам поиска и массиву директорий для поиска
        //Инициализируются в конструкторе
        private DirectoryInfo[] DirInf;
        private string FileName;
        private DateTime BegDate;
        private DateTime EndDate;
        private int MinSize;
        private int MaxSize;

        //Переменная для хранения списка екземпляров класса Searcher
        private List<Searcher> Searchers;
        //Список потоков созданных для поиска
        private List<Thread> Threads;
        //Список полученных файлов
        public List<FileInfo> FindedFiles;

        //Метод класса Form2 который реализует многопоточность
        private void DoItParalell(DirectoryInfo di)
        {   
            //если в директории есть вложенные папки выполнится следующий код
            if (di.GetDirectories().Length != 0)
            {
                //создадим новый список екземпляров поискового класса
                Searchers = new List<Searcher>();
                //создадим новый список потоков
                Threads = new List<Thread>();

                //для каждой папки в корневой выполним создание поискового класса и потока
                foreach (DirectoryInfo subdir in di.GetDirectories())
                {
                    Searcher s1 = new Searcher(subdir, this.FileName, this.BegDate, this.EndDate, this.MinSize, this.MaxSize);
                    this.Searchers.Add(s1);
                    Thread t1 = new Thread(new ThreadStart(s1.StartSearch));
                    this.Threads.Add(t1);
                }
                //запускаем потоки на выполнение
                foreach (Thread item in this.Threads)
                {
                    item.Start();
                }
                //ждем завершения работы всех потоков
                while (true)
                {
                    int endCount = 0;
                    foreach (Thread item in this.Threads)
                    {
                        //проверка состояния потока
                        if (item.ThreadState == ThreadState.Running)
                        {
                            endCount++;
                        }
                    }
                    //если вторичных потоков больше нет основной поток продолжает работу
                    if (endCount == 0) break;
                }
                
                int counter = 0;

                //Для каждого поискового класса читаем список найденных файлов
                foreach (Searcher si in Searchers)
                {
                    //Добавляем информацию про каждый полученный файл в список на форме
                    foreach (FileInfo fi in si.FindedFiles)
                    {
                            this.listView1.Items.Add(fi.Name);
                            this.listView1.Items[counter].SubItems.Add(fi.DirectoryName);
                            this.listView1.Items[counter].SubItems.Add((fi.Length / 1000).ToString());
                            this.listView1.Items[counter].SubItems.Add(fi.CreationTime.ToString());
                            counter++;
                    }
                }
                //Создаем екземпляр поискового класса для поиска в корен дисков/входных директорий
                Searcher ls=new Searcher(di, this.FileName, this.BegDate, this.EndDate, this.MinSize, this.MaxSize);
                //Ищем файлы только внутри корневой директории
                List<FileInfo> localsFile=ls.SearchFile(di);
                //Добавляем найденные файлы в визуальный список на форме
                foreach (FileInfo fi in localsFile)
                {
                    this.listView1.Items.Add(fi.Name);
                    this.listView1.Items[counter].SubItems.Add(fi.DirectoryName);
                    this.listView1.Items[counter].SubItems.Add((fi.Length / 10).ToString());
                    this.listView1.Items[counter].SubItems.Add(fi.CreationTime.ToString());
                    counter++;
                }
                //Выводим сообщение о количестве отысканных файлов
                this.lbProgress.Text = "Done!" + " Finded " + listView1.Items.Count + " files.";
                    
                //Если файлов в поисковых классах не обнаружено в метку на форме
                //выводится сообщение "File not found"
                if (counter == 0)
                {
                    this.lbProgress.Text = "File not found";
                }
            }
            else
            {
                //Создается единый екземпляр класс Searcher
                Searcher singleSearch = new Searcher(di, this.FileName, this.BegDate, this.EndDate, this.MinSize, this.MaxSize);
                //Проводится поиск в одном потоке
                singleSearch.StartSearch();
                int counter = 0;
                //Получаем все отысканные файлы и выводим в список на форме
                foreach (FileInfo fi in singleSearch.FindedFiles)
                {
                    this.listView1.Items.Add(fi.Name);
                    this.listView1.Items[counter].SubItems.Add(fi.DirectoryName);
                    this.listView1.Items[counter].SubItems.Add((fi.Length / 100).ToString());
                    this.listView1.Items[counter].SubItems.Add(fi.CreationTime.ToString());
                    counter++;
                    this.lbProgress.Text = "Done!";
                }
                //Если файлы не найдены - выводим сообщение
                if (counter == 0)
                {
                    this.lbProgress.Text = "File not found";
                }
            }
                
        }

        private void btQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void lbProgress_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                string nameFile = listView1.SelectedItems[i].SubItems[0].Text as string;
                string pathFile = listView1.SelectedItems[i].SubItems[1].Text as string;
                string[] path = pathFile.Split('\\');
                File.Delete($@"{path[0]}\{path[1]}\{nameFile}");
                listView1.SelectedItems[i].Tag = null;
                listView1.SelectedItems[i].Remove();

            }

            listView1.Refresh();

        }
    }
    public class Searcher
    {
        private DirectoryInfo parentDirectory;
        private string fileName;
        private DateTime crTimeBeg;
        private DateTime crTimeEnd;
        private double sizeInKbEnd;
        private double sizeInKbBegin;

        //Конструктор класса, устанавливает parentDirectory как каталог программы,
        //а имя файла для поиска равным *.*
        public Searcher()
        {
            parentDirectory = new DirectoryInfo(Application.ExecutablePath);
            fileName = "*.*";
            this.FindedFiles = new List<FileInfo>();
        }
        //Разширенный конструктор - позволяет инициализировать приватные переменные класса
        public Searcher(DirectoryInfo parentDirectory, string fileName, DateTime crTimeBeg, DateTime crTimeEnd, double sizeBegin, double sizeEnd)
        {
            this.parentDirectory = parentDirectory;
            this.fileName = fileName;
            this.crTimeBeg = crTimeBeg;
            this.crTimeEnd = crTimeEnd;
            this.sizeInKbBegin = sizeBegin;
            this.sizeInKbEnd = sizeEnd;
            this.FindedFiles = new List<FileInfo>();
        }

        //список полученных файлов
        public List<FileInfo> FindedFiles;
        //Метод который ищет все файлы в переданной в виде параметра директории
        public List<FileInfo> SearchFile(DirectoryInfo dir)
        {
            string pattern = string.Format("*{0}*", this.fileName);
            List<FileInfo> SearchedFile = new List<FileInfo>();
            //Отбираем файлы которые соответствуют строке поиска
            FileInfo[] inDest = dir.GetFiles(pattern, SearchOption.TopDirectoryOnly);
            foreach (FileInfo fi in inDest)
            {
                //Попытка доступа к файлам, если успешно - сравниваем даты и размеры с еталонными
                try
                {
                    if (fi.CreationTime.Date >= this.crTimeBeg && fi.CreationTime.Date <= this.crTimeEnd && ((fi.Length) / 1000) <= this.sizeInKbEnd && ((fi.Length / 1000)) >= this.sizeInKbBegin)
                    {
                        try
                        {
                            SearchedFile.Add(fi);
                        }
                        catch
                        {
                            Thread.Sleep(1);
                        }
                    }
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
            //Возвращаем список файлов
            return SearchedFile;
        }

        public void StartSearch()
        {
            bool AllOk = true;
            //попытка доступа к директории - если успешно то все остается неизменным
            try
            {
                parentDirectory.GetDirectories();
            }
            //Если возникло исключение - переменная  AllOk получает значение false
            catch
            {
                AllOk = false;
            }
            //Если доступ был успешным то получаем подкаталоги
            if (AllOk)
            {
                if (parentDirectory.GetDirectories().Length != 0)
                {
                    //Для каждого подкаталога запускаем новый поиск
                    foreach (DirectoryInfo di in parentDirectory.GetDirectories())
                    {
                        Searcher second = new Searcher(di, fileName, crTimeBeg, crTimeEnd, sizeInKbBegin, sizeInKbEnd);
                        second.StartSearch();
                        //Получаем список файлов удовлетворяющих условия для подкаталога 
                        this.FindedFiles.AddRange(second.FindedFiles);
                    }
                    //Находим файлы удовлетворяющие условия в самом каталоге
                    this.SearchFile(parentDirectory);
                }
                else
                {
                    //Если подкаталогов нет просто ищем файлы в текущем
                    this.FindedFiles.AddRange(this.SearchFile(this.parentDirectory));
                }
            }
        }


    }
}
