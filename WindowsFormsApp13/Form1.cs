using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using Maxs_Gorn;

namespace WindowsFormsApp13
{

    public partial class Form1 : Form
    {

        int task = 0;
        List<Legend> Legends;
       
        private int viNumInRg = 20;//20 - начальное значение
        private string[,] rgsValues = null;
        public Form1()
        {
            InitializeComponent();
            Legends = new List<Legend>();
        }

  






       

        

        private void Build_Circle_Click(object sender, EventArgs e)
        {
            pictureBox_Circle.Image = null;
          
            vCreateCircleDiagramm();
            task = -1;
        }
        private void vCreateCircleDiagramm()
        {
            //Создаем массив значений для вывода на графике
            vCreateRg();
            //Создаем класс и передаем ему размер холсты
            PaintCl clPaint = new PaintCl(pictureBox_Circle.Width, pictureBox_Circle.Height);
            //Фон холста
            clPaint.vSetBackground(Color.White);
            //Передаем значения массива в класс
            clPaint.RgValue = rgsValues;
            //Рисуем график. Параметры: отступ осей x слева, x справа ,
            //y от краев холста, толщина диаграммы,вынос сектора        
            if (Legends.Count > 0)
            {
                clPaint.vDravCircle3D(20, 250, 50, 20, 20, 40);
            }
            //Круговые надписи true цифры 1-20, false - значения
            clPaint.vDravTextCircle1(true);
            //false - Разноцветные надписи в легенде true - Цветом шрифта
            clPaint.vDravTextKeyCircle(true);
            //Принимаем нарисованное в pictureBox
            pictureBox_Circle.Image = clPaint.Bmp;
          
        }
        private void ResetCircle_Click(object sender, EventArgs e)
        {
            pictureBox_Circle.Image = null;
        }
        private int? ConvertStringToInt(string intString)
        {
            int i = 0;
            return (Int32.TryParse(intString, out i) ? i : (int?)null);
        }
        private void AddLegend_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.TextLength==0 || textBox2.TextLength==0)
                {
                    throw new Exception("Eror length legend or value");
                }

                if (ConvertStringToInt(textBox2.Text) == null)
                {
                    throw new Exception("Eror convert to int!");
                }
                if (listBox.Items.Contains(textBox1.Text))
                {
                    throw new Exception("Legend is exists!");

                }
                if(listBox.Items.Count==20)
                {
                    throw new Exception("Too many users!");
                }
                Legend legend = new Legend() { legend = textBox1.Text, value = Convert.ToInt32(textBox2.Text) };
                var item = listBox.Items.Add(legend.legend);
                Legends.Add(legend);


            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message,"Notifications", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }
        class Legend
        {
            public int value { get; set; }
            public string legend { get; set; }
        }

        private void Delelegend_Click(object sender, EventArgs e)
        {

            try
            {
                if(listBox.SelectedIndex<0)
                {
                    throw new Exception("Eror index!");
                }
                Legends.RemoveAt(listBox.SelectedIndex);
                listBox.Items.RemoveAt(listBox.SelectedIndex);
               
                //listBoxДупутв.SelectedIndex =;
                listBox.Text = "";
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message,"Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ResetStovp_Click(object sender, EventArgs e)
        {
            pictureBox_Stovp.Image = null;
        }

        private void Build_Stovp_Click(object sender, EventArgs e)
        {
            task = 4;
            pictureBox_Stovp.Invalidate();
        }

        private void pictureBox_Stovp_Paint(object sender, PaintEventArgs e)
        {

            if (task == 4)
            {
                vCreateRectangleDiagramm();
                task = -1;
            }
              
        }
        #region Создание массива значений
        private void vCreateRg()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            Random rnd1 = new Random(DateTime.Now.Millisecond + 5);
            rgsValues = new string[viNumInRg, 2];
            if(Legends.Count> viNumInRg)
            {
                for (int i = 0; i < Legends.Count; i++)
                {
                    rgsValues[i, 0] = Convert.ToString((Legends[i].value / (float)100));
                    rgsValues[i, 1] = "I-" + listBox.Items[i];
                }
            }
            else
            {
                for (int i = 0; i < Legends.Count; i++)
                {
                    rgsValues[i, 0] = Convert.ToString((Legends[i].value / (float)100));
                    rgsValues[i, 1] = "I-" + listBox.Items[i];
                }
                for (int i = Legends.Count; i < viNumInRg; i++)
                {
                    rgsValues[i, 0] = Convert.ToString(0);
                    rgsValues[i, 1] = "I-" + Convert.ToString(i + 1);
                }
            }
          
        }
        #endregion
        private void vCreateRectangleDiagramm()
        {
            //Создаем массив значений для вывода на графике
            vCreateRg();
            //Создаем класс и передаем ему размер холсты
            PaintCl clPaint = new PaintCl(pictureBox_Stovp.Width, pictureBox_Stovp.Height);
            //Фон холста
            clPaint.vSetBackground(Color.White);
            //Параметры вызоыва: отступы слева, справа, сверху(снизу),Цвет осей, толщина пера
            clPaint.vDravAxis(50, 50, 30, Color.Red, 2, true);
            clPaint.vSetPenWidthLine(1);
            clPaint.vSetPenColorLine(Color.Silver);
            clPaint.MaxRg = 20;
            clPaint.vDravGrid();
            clPaint.vSetPenWidthLine(2);
            clPaint.vSetPenColorLine(Color.Green);
            clPaint.RgValue = rgsValues;
            //a=0 без сдвига цвета a=1 со сдвигом,b = 0 - без разрыва, > 1 - с разрывом и величина разрыва в %
            clPaint.vDrawGraphRectangular(1, 5);
            Font objFont = new Font("Arial", 7, FontStyle.Bold | FontStyle.Italic);
            clPaint.font = objFont;
            clPaint.brush = Brushes.Blue;
            clPaint.vDrawTextAxXNumber(false);
            //clPaint.vDrawTextAxXValues(true);
            clPaint.vDrawTextAxYValues();
            clPaint.vDrawTextAxYValuesPoint(true, false);
            //Принимаем нарисованное в pictureBox
            pictureBox_Stovp.Image = clPaint.Bmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox_Circle.Image = null;
            task = 3;
            pictureBox_Circle.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{
        //    using (Graphics g = e.Graphics)
        //    {
        //        Point[] points = graphPoints.ToArray();
        //        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //        if (points.Length > 1)
        //            g.DrawCurve(graphPen, points);
        //    }
        //}

        //private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    graphPoints.Add(new System.Drawing.Point(counter * steps, (int)(float)e.UserState));      //x - regular interval decided by a constant; y - simulated by background worker
        //    panel1.Refresh();
        //    counter++;
        //}

    }


}

