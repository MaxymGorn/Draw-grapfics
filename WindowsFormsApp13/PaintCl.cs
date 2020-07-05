using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Maxs_Gorn
{
    class PaintCl
    {
        //Основные объекты для рисования
        private Bitmap bmp = null;
        private Graphics graph = null;
        private Font objFont = new Font("Arial", 8, FontStyle.Bold);
        private Brush objBrush = Brushes.Black;
        private Pen objPenLine = new Pen(Color.Black, 1);
        //Размеры холста
        private int viX = 200;
        private int viY = 100;
        //Отступы от краев холста
        private int viDeltaaxisL = 50;
        private int viDeltaaxisR = 50;
        private int viDeltaaxisH = 20;

        private Brush[] br ={
        Brushes.LightGreen,Brushes.Chartreuse,Brushes.LimeGreen,Brushes.Green,Brushes.DarkGreen,
        Brushes.DarkOliveGreen,Brushes.LightPink,Brushes.LightSeaGreen,Brushes.LightCoral,Brushes.DarkCyan ,
        Brushes.Crimson,Brushes.CornflowerBlue ,Brushes.Chocolate,Brushes.CadetBlue,Brushes.BlueViolet,
        Brushes.Maroon, Brushes.Blue,Brushes.Brown,Brushes.DarkBlue, Brushes.Red,
        Brushes.Coral,Brushes.DarkRed, Brushes.DarkMagenta, Brushes.DarkOrange,Brushes.DarkOrchid};
        private string[,] rgsValues = null;


        private float vfDiamX = 100;
        private float vfDiamY = 100;
        private float vfXcirc = 100;
        private float vfYcirc = 100;
        private Color[] color ={
        Color.LightGreen,Color.Chartreuse,Color.LimeGreen,Color.Green,Color.DarkGreen,
        Color.DarkOliveGreen,Color.LightPink ,Color.LightSeaGreen,Color.LightCoral ,Color.DarkCyan ,
        Color.Crimson , Color.CornflowerBlue ,Color.Chocolate,Color.CadetBlue,Color.BlueViolet,
        Color.Maroon,Color.Blue,Color.Brown,Color.DarkBlue, Color.Red,
        Color.Coral,Color.DarkRed, Color.DarkMagenta, Color.DarkOrange,Color.DarkOrchid};


        public string[,] RgValue
        {
            set { rgsValues = value; }
        }

        public Brush brush
        {
            set { objBrush = value; }
        }
        public Font font
        {
            set { objFont = value; }
        }

        #region Конструкторы
        //Первый
        public PaintCl()
        {

        }
        //Второй
        public PaintCl(int a, int b)
        {
            bmp = new Bitmap(a, b);
            //Создаем объект Graphics на основе битовой матрицы 
            graph = Graphics.FromImage(bmp);
            //Запоминаем размеры холста
            viX = a;
            viY = b;
        }
        #endregion

        #region Установка цвет фона диаграммы 
        public void vSetBackground(Color bcl)
        {
            graph.Clear(bcl);
        }
        #endregion

        #region Доступ к переменным класса
        public Bitmap Bmp
        {
            get { return bmp; }
        }
        #endregion


        #region Рисование Осей
        //Параметры вызоыва: отступы слева - deltaaxisL, справа - deltaaxisR, 
        //сверху(снизу) - deltaaxisH, Цвет осей - colorpenaxis, толщина пера - widthpen, 
        //нужны ли стрелки - fArrow (true - да)
        public void vDravAxis(int deltaaxisL, int deltaaxisR,
                     int deltaaxisH, Color colorpenaxis, int widthpen, bool fArrow)
        {
            //Запоминаем отступы                        
            viDeltaaxisL = deltaaxisL;
            viDeltaaxisR = deltaaxisR;
            viDeltaaxisH = deltaaxisH;
            //Запоминаем цвет осей и толщину
            vSetPenColorLine(colorpenaxis);
            if (widthpen > 0) vSetPenWidthLine(widthpen);
            //Точка начала рисования по х и y           
            int x = deltaaxisL;
            int y = viY - deltaaxisH;
            int x1 = viX - deltaaxisR;
            int y1 = deltaaxisH;
            //Переменная определения длины стрелок
            int d = 0;
            if (fArrow) d = widthpen * 10;
            //Оси на d пикселей длинней для стрелок
            graph.DrawLine(objPenLine, x, y, x1 + d, y);
            graph.DrawLine(objPenLine, x, y, x, y1 - d);
            //Надо рисовать стрелки
            if (fArrow)
            {
                int a = 10 * (int)objPenLine.Width;
                int b = 2 * (int)objPenLine.Width;
                int x2 = x1 - a;
                int y2 = y + b;
                //Стрелки
                graph.DrawLine(objPenLine, x1 + 20, y, x2 + d, y2);
                y2 = y - b;
                graph.DrawLine(objPenLine, x1 + 20, y, x2 + d, y2);
                x2 = x - b;
                y2 = y1 + a;
                graph.DrawLine(objPenLine, x, y1 - d, x2, y2 - d);
                x2 = x + b;
                graph.DrawLine(objPenLine, x, y1 - d, x2, y2 - d);
            }
        }
        #endregion

        #region Карандаш, шрифт, кисть
        //Цвет карандаша
        public void vSetPenColorLine(Color pcl)
        {
            if (objPenLine == null)
            {
                objPenLine = new Pen(Color.Black, 1);
            }
            objPenLine.Color = pcl;
        }

        //Максимальный размер массива
        private int viMaxRg = 20;

        public int MaxRg
        {
            set { viMaxRg = value; }
        }

        #region Рисование сетки
        public void vDravGrid()
        {
            float x = viDeltaaxisL;
            float y = viY - viDeltaaxisH;
            float x1 = viX - viDeltaaxisR;
            float y1 = viDeltaaxisH;
            //Сдвиг линий сетки на один отсчет по Y
            float f = (y - y1) / (float)viMaxRg;
            //Рисуем горизонтальные линии
            for (int i = 1; i < viMaxRg + 1; i++)
            {
                graph.DrawLine(objPenLine, x, y - f * i, x1, y - f * i);
            }
            //Сдвиг линий сетки на один отсчет по X
            f = (x - x1) / (float)(viMaxRg - 1);
            //Рисуем вертикальные линии
            for (int i = 1; i < viMaxRg; i++)
            {
                graph.DrawLine(objPenLine, x - f * i, y, x - f * i, y1);
            }
        }
        #endregion

        //Установка толщина карандаша        
        public void vSetPenWidthLine(int penwidth)
        {
            if (objPenLine == null)
            {
                objPenLine = new Pen(Color.Black, 1);
            }
            objPenLine.Width = penwidth;
        }
        #endregion


        

        #region Текст по оси X - Цифры отсчетов
        //Параметр: false - соседние значения без сдвига по оси Y
        //          true  - соседние значения со здвигом по оси Y
        public void vDrawTextAxXNumber(bool f)
        {
            //Пикселей для надписей по оси х
            float fdeltax = viX - viDeltaaxisL - viDeltaaxisR;
            //Пикселей на один отсчет
            fdeltax = fdeltax / (float)(viMaxRg - 1);
            float x = viDeltaaxisL;
            float y = viY - viDeltaaxisH + objPenLine.Width;
            for (int i = 1; i < viMaxRg + 1; i++)
            {
                if (!f || i % 2 == 0)
                {
                    graph.DrawString(Convert.ToString(i), objFont, objBrush, x + (i - 1) * fdeltax, y);
                }
                else
                {
                    graph.DrawString(Convert.ToString(i),
                     objFont, objBrush, x + (i - 1) * fdeltax, y + objFont.Size);
                }
            }
        }
        #endregion

        #region Текст по оси X -  Параметр массива
        //Параметр: false - соседние значения без сдвига по оси Y
        //          true  - соседние значения со здвигом по оси Y
        public void vDrawTextAxXValues(bool f)
        {
            string s = string.Empty;
            //Пикселей для надписей по оси х
            float fdeltax = viX - viDeltaaxisL - viDeltaaxisR;
            //Пикселей на один отсчет
            fdeltax = fdeltax / (float)(viMaxRg - 1);
            float x = viDeltaaxisL;
            float y = viY - viDeltaaxisH;// +objPenLine.Width;
            for (int i = 0; i < viMaxRg; i++)
            {
                if (!f || i % 2 == 0)
                {
                    graph.DrawString(rgsValues[i, 1], objFont, objBrush, x + i * fdeltax, y);
                }
                else
                {
                    graph.DrawString(rgsValues[i, 1], objFont, objBrush, x + i * fdeltax, y + objFont.Size);
                }
            }
        }
        #endregion

        #region Текст по оси Y - Значения по отсчетам сетки оси Y
        public void vDrawTextAxYValues()
        {
            string s = string.Empty;
            float f = 0;
            float fMax = float.MinValue;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                if (fMax < float.Parse(s)) fMax = float.Parse(s);
            }
            f = fMax / (float)(viMaxRg - 1);
            //Пикселей для надписей по оси х
            float fdeltay = viY - 2 * viDeltaaxisH;
            //Пикселей на один отсчет
            fdeltay = fdeltay / (float)(viMaxRg - 1);
            float y = viY - viDeltaaxisH - objFont.Size;
            for (int i = 0; i < viMaxRg; i++)
            {
                graph.DrawString((100*(float)(i * f)).ToString("0.00"),
                   objFont, objBrush, viDeltaaxisL - (objFont.Size) * 5 - 5, y - i * fdeltay);
            }
        }
        #endregion

        #region Надписи - Значения  над точкой 
        //1 параметр = false - без отображения процентов, true - с отображением
        //2 параметр = false - без сдвига, true - со здвигом по оси Y
        public void vDrawTextAxYValuesPoint(bool a, bool b)
        {
            string s = string.Empty;
            float fMax = float.MinValue;
            float fSum = 0;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                fSum += float.Parse(s);
                if (fMax < float.Parse(s)) fMax = float.Parse(s);
            }
            //Пикселей для надписей по оси х
            float fdeltax = viX - viDeltaaxisL - viDeltaaxisR;
            //Пикселей на один отсчет по х
            fdeltax = fdeltax / (float)(viMaxRg - 1);
            float x = viDeltaaxisL;
            float fdeltay = viY - 2 * viDeltaaxisH;
            float y = viY - viDeltaaxisH - objFont.Size;
            //Пикселей на одну единицу
            fdeltay = fdeltay / fMax;
            float fdelta = 0;
            for (int i = 0; i < viMaxRg; i++)
            {
                if (a)
                {
                    if (i % 2 == 0) fdelta = objFont.Size;
                    else fdelta = 2 * objFont.Size;
                }
                else
                {
                    fdelta = objFont.Size;
                }
                if (b)
                {
                    graph.DrawString(rgsValues[i, 0], objFont, objBrush, x + i * fdeltax,
                           y - (float.Parse(rgsValues[i, 0]) * fdeltay) - fdelta);
                }
                else
                {
                    float fp = float.Parse(rgsValues[i, 0]);
                    fp = (fp * 100) / fSum;
                    graph.DrawString(rgsValues[i, 1] + "-" + fp.ToString("0.0") + "%",
                                    objFont, objBrush, x + i * fdeltax,
                                              y - (float.Parse(rgsValues[i, 0]) * fdeltay) - fdelta);
                }
            }
        }
        #endregion


        #region Рисование Гистограммы
        //Параметры: a=0 без сдвига цвета a=1 со сдвигом
        //b = 0 - без разрыва столбиков > 1 - с разрывом и величина разрыва в %
        public void vDrawGraphRectangular(int a, int c)
        {
            string s = string.Empty;
            string s1 = string.Empty;
            string s2 = string.Empty;
            float f = 0;
            float x1 = 0;
            float x = viDeltaaxisL;
            float y = viY - viDeltaaxisH;
            float fMax = float.MinValue;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                if (fMax < float.Parse(s)) fMax = float.Parse(s);
            }
            //Пикселей для рисования по оси х
            float fdeltax = viX - viDeltaaxisL - viDeltaaxisR;
            //Пикселей на один отсчет
            fdeltax = fdeltax / (float)(viMaxRg - 1);
            //Пикселей для рисования по оси y
            float fdeltay = viY - 2 * viDeltaaxisH;
            //Пикселей на одну единицу массива значений
            fdeltay = fdeltay / fMax;
            float fdx = 0;
            if (c != 0) fdx = (fdeltax * c / 100) / 2;
            Random rand = new Random(DateTime.Now.Millisecond);
            int arn = rand.Next((int)br.Length);
            objBrush = br[arn];
            for (int i = 0; i < viMaxRg - 1; i++)
            {
                s = rgsValues[i, 0];
                f = float.Parse(s);
                x1 = x + ((float)i * fdeltax);
                if (a == 0)
                {
                    graph.FillRectangle(objBrush, x1 + fdx, y - fdeltay * f,
                                                    fdeltax - 2 * fdx, fdeltay * f);
                }
                else
                {
                    int b = i % br.Length;
                    graph.FillRectangle(br[b], x1 + fdx, y - fdeltay * f,
                                                    fdeltax - 2 * fdx, fdeltay * f);
                }
                if (i == viMaxRg - 2)
                {
                    int b = (i + 1) % br.Length;
                    s = rgsValues[i + 1, 0];
                    f = float.Parse(s);
                    x1 = x + ((float)(i + 1) * fdeltax);
                    if (a == 0)
                    {
                        graph.FillRectangle(objBrush, x1 - 2, y - fdeltay * f,
                                                             4/*fdeltax*/, fdeltay * f);
                    }
                    else
                    {
                        graph.FillRectangle(br[b], x1 - 2, y - fdeltay * f,
                                                             4/*fdeltax*/, fdeltay * f);
                    }
                }
            }
        }
        #endregion


        #region  vDravCircle3D
        //Параметры - Отступ от краев по X слева deltaaxisL, от краев по Y справа deltaaxisR,
        //deltaaxisH - отступа сверху и снизу, толщина диаграммы viH, сдвиг сектора viDx, viDy
        public void vDravCircle3D(int deltaaxisL, int deltaaxisR,
                         int deltaaxisH, int viH, int viDx, int viDy)
        {
            //Запоминаем отступы            
            viDeltaaxisL = deltaaxisL;
            viDeltaaxisR = deltaaxisR;
            viDeltaaxisH = deltaaxisH;
            float a = viX - (deltaaxisL + deltaaxisR);
            //Нужен ли выброс сектора
            int viMov = 1;
            if (viDx == 0 && viDy == 0)
            {
                viMov = 0;
            }
            //Запоминаем диаметр
            vfDiamX = a;
            vfDiamY = viY - 2 * viDeltaaxisH;
            //Запоминаем центр элипса
            vfXcirc = deltaaxisL + a / 2;
            vfYcirc = viY / 2;
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            //Определяем сумму всех значений в массиве
            float fSum = 0;
            string s = string.Empty;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                fSum += float.Parse(s);
            }
            float f = 0;
            float fBSum = 0;
            float fDeltaGrad = (fSum / (float)360);
            SolidBrush objBrush = new SolidBrush(Color.Aqua);
            Random rand = new Random(DateTime.Now.Millisecond);
            float[] frgZn = new float[viMaxRg];
            float[] frgSumGr = new float[viMaxRg];
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                frgZn[i] = float.Parse(s);
                if (i == 0) frgSumGr[i] = 0;
                else frgSumGr[i] = frgZn[i] + frgSumGr[i - 1];
            }
            for (int i = viMaxRg - 1; i >= 0; i--)
            {
                if (i != viMaxRg - 1 && fBSum < 90) break;
                //f в градусах  fBSum в градусах
                f = frgZn[i] / fDeltaGrad;
                //fBSum = frgSumGr[i] / fDeltaGrad;
                if (i == viMaxRg - 1)
                {
                    fBSum = 360 - f;
                }
                else
                {
                    fBSum -= f;
                }
                //Для цвета
                int j = i % br.Length;
                float k = f;
                if (f < 1) k = 1;
                //objBrush.Color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                if (i != 0)
                {
                    if ((fBSum > 90 && fBSum < 180) || i == viMaxRg - 1)
                    {
                        for (int d = 0; d < viH; d++)
                        {
                            //Этап 1
                            graph.FillPie(new HatchBrush(HatchStyle.Percent25, color[j]/*objBrush.Color*/),
                                  vfXcirc - a / 2, vfYcirc - vfDiamY / 2 + d,
                                    vfDiamX, vfDiamY, fBSum, k);
                        }
                    }
                    objBrush.Color = color[j];
                    //Этап 2
                    graph.FillPie(objBrush, vfXcirc - a / 2, vfYcirc - vfDiamY / 2,
                         vfDiamX, vfDiamY, fBSum, k);
                }
            }
            fBSum = 0;
            for (int i = viMov; i < viMaxRg; i++)
            {
                //f в градусах  fBSum в градусах
                f = frgZn[i] / fDeltaGrad;
                if (i == 1)
                {
                    fBSum = frgZn[0] / fDeltaGrad;
                }
                //Для цвета
                int j = i % br.Length;
                float k = f;
                if (f < 1) k = 1;

                if (fBSum < 90)
                {
                    for (int d = 0; d < viH; d++)
                    {
                        //Этап 3
                        graph.FillPie(new HatchBrush(HatchStyle.Percent25, color[j]),
                         vfXcirc - a / 2, vfYcirc - vfDiamY / 2 + d,
                            vfDiamX, vfDiamY, fBSum, k);
                    }
                    objBrush.Color = color[j];
                    //Этап 4
                    graph.FillPie(objBrush, vfXcirc - a / 2, vfYcirc - vfDiamY / 2,
                     vfDiamX, vfDiamY, fBSum, k);
                }
                else
                {
                    break;
                }
                fBSum += f;
            }
            //Рисуем сдвинутым первый сектор 
            //Этап 5
            if (viMov == 1)
            {
                f = frgZn[0] / fDeltaGrad;
                fBSum = 0;
                float k1 = f;
                if (f < 1) k1 = 1;
                for (int d = 0; d < viH; d++)
                {
                    graph.FillPie(new HatchBrush(HatchStyle.Percent25, color[0]),
                     vfXcirc - a / 2 + viDx, vfYcirc - vfDiamY / 2 + d - viDy,
                        vfDiamX, vfDiamY, fBSum, k1);
                }
                objBrush.Color = color[0];
                graph.FillPie(objBrush, vfXcirc - a / 2 + viDx, vfYcirc - vfDiamY / 2 - viDy,
                vfDiamX, vfDiamY, fBSum, k1);
            }
        }
        #endregion


        #region vDravTextCircle
        public void vDravTextCircle1(bool vfGde)
        {
            float fSum = 0;
            string s = string.Empty;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                fSum += float.Parse(s);
            }
            float f = 0;
            float fBSum = 0;
            float f1Radian = (float)Math.PI / 180;
            float fDeltaGrad = fSum / 360;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                f = float.Parse(s);
                //f в градусах
                f = f / fDeltaGrad;
                int j = i % br.Length;
                //Угол в радианах
                float fRad = (f + fBSum) * f1Radian;
                float fty = 0;
                float ftx = 0;
                float fSin = (float)Math.Sin((360 - (f / 2 + fBSum)) * f1Radian);
                float fCos = (float)Math.Cos((360 - (f / 2 + fBSum)) * f1Radian);
                float c = (float)Math.Sqrt((vfDiamX / 2 * vfDiamX / 2 * vfDiamY / 2 * vfDiamY / 2) /
                    (vfDiamY / 2 * vfDiamY / 2 * fCos * fCos + vfDiamX / 2 * vfDiamX / 2 * fSin * fSin));
                c -= 3 * objFont.Size;
                if (c < 0) c = 0;
                ftx = c * fCos;
                fty = c * fSin;
                ftx = vfXcirc + ftx;
                fty = vfYcirc - fty;
                if (vfGde)
                {
                    graph.DrawString(Convert.ToString(i + 1), objFont, objBrush, ftx, fty);
                }
                else
                {
                    graph.DrawString(rgsValues[i, 0], objFont, objBrush, ftx, fty);
                }
                fBSum += f;
            }
        }
        #endregion

        #region Текст легенды
        public void vDravTextKeyCircle(bool vfGde)
        {
            float fSum = 0;
            float f = 0;
            string s = string.Empty;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                fSum += float.Parse(s);
            }
            //Сдвиг от круговой диаграммы
            float vfSdvig = vfXcirc + vfDiamX / 2;
            vfSdvig += (viX - vfSdvig) / 5;
            //Высота места для легенды
            //На одну строку по высоте отводится - +1 на заголовок
            float vfHg = viY / (viMaxRg + 2);
            vSetFont("Arial", 12, true);
            if (viMaxRg > 100)
            {
                graph.DrawString("Легенда не может быть размещена",
                 objFont, Brushes.DarkBlue, vfSdvig + (viX - vfSdvig) / 10, objFont.Size);
            }
            else
            {
                //Шрифт в 2 раза меньше места на строку надписи
                if (viMaxRg > 15)
                {
                    vSetFont("Arial", (vfHg / 2), true);
                }
                else
                {
                    if (viMaxRg > 10)
                    {
                        vSetFont("Arial", (vfHg / 3), true);
                    }
                    else
                    {
                        vSetFont("Arial", (vfHg / 6), true);
                    }
                }
                if (vfGde)
                {
                    graph.DrawString("Пояснения к графику",
                     objFont, Brushes.DarkBlue, vfSdvig /*+ (viX - vfSdvig) / 10*/, objFont.Size);
                }
                else
                {
                    graph.DrawString("Пояснения к графику",
                      objFont, objBrush, vfSdvig/* + (viX - vfSdvig) / 10*/, objFont.Size);
                }
                if (viMaxRg > 15)
                {
                    vSetFont("Arial", (vfHg / 2) + 1, true);
                }
                else
                {
                    if (viMaxRg > 10)
                    {
                        vSetFont("Arial", (vfHg / 4) + 1, true);
                    }
                    else
                    {
                        vSetFont("Arial", (vfHg / 7) + 1, true);
                    }
                }
                for (int i = 0; i < rgsValues.Length / 2; i++)
                {
                    Brush brTxt = null;
                    int j = i % br.Length;
                    if (vfGde) brTxt = br[j];
                    else brTxt = objBrush;
                    graph.DrawString(Convert.ToString(i + 1), objFont, brTxt, vfSdvig, vfHg * (i + 2));
                    f = float.Parse(rgsValues[i, 0]);
                    f = (f * 100) / fSum;
                    graph.DrawString(Convert.ToString(float.Parse(rgsValues[i, 0])*100), objFont,
                        brTxt, vfSdvig + 1 * (viX - vfSdvig) / 5, vfHg * (i + 2));
                    graph.DrawString(f.ToString("0.0") + "%", objFont,
                        brTxt, vfSdvig + 2 * (viX - vfSdvig) / 5, vfHg * (i + 2));
                    graph.DrawString(rgsValues[i, 1], objFont,
                        brTxt, vfSdvig + 3 * (viX - vfSdvig) / 5, vfHg * (i + 2));
                }
            }
        }
        #endregion


        #region Смена шрифта по секторам
        private void vSetFont(string name, float size, bool bold)
        {
            if (objFont != null) objFont = null;
            if (bold)
            {
                objFont = new Font(name, size, FontStyle.Bold);
            }
            else
            {
                objFont = new Font(name, size);
            }
        }
        #endregion

    }
}