using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace WinForms_punktowane
{
    public partial class Form : System.Windows.Forms.Form
    {
        public static Form mainF;

        private Bitmap drawArea;

        private Pen pen;
        private Pen dashedPen;

        private int whichShape;

        private Form2 form = null;

        private Shape selectedShape = null;
        private int diffX = 0;
        private int diffY = 0;

        private List<Shape> list = null;

        private bool moving = false;

        public List<Arrow> arrows = null;
        private Arrow currentArrow = null;

        int greenEllipses = 0;

        public Form()
        {
            InitializeComponent();
            Canvas.Width = 2000;
            Canvas.Height = 2000;
            drawArea = new Bitmap(2000, 2000);
            Canvas.Image = drawArea;
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
            }

            pen = new Pen(Brushes.Black, 3);
            dashedPen = new Pen(Brushes.Black, 3);
            dashedPen.DashPattern = new float[] { 2, 1 };


            START.BackColor = Color.LightBlue;
            BO.BackColor = SystemColors.Control;
            BD.BackColor = SystemColors.Control;
            STOP.BackColor = SystemColors.Control;
            LINK.BackColor = SystemColors.Control;
            DELETE.BackColor = SystemColors.Control;

            Bitmap drawBO = new Bitmap(BO.Width, BO.Height);
            BO.Image = drawBO;
            using (Graphics g = Graphics.FromImage(drawBO))
            {
                g.DrawRectangle(pen, 15, 30, BO.Width - 30, BO.Height - 60);
            }

            Bitmap drawBD = new Bitmap(BD.Width, BD.Height);
            BD.Image = drawBD;
            using (Graphics g = Graphics.FromImage(drawBD))
            {
                Point p1 = new Point(15, BD.Height / 2);
                Point p2 = new Point(BD.Width / 2, 30);
                Point p3 = new Point(BD.Width - 15, BD.Height / 2);
                Point p4 = new Point(BD.Width / 2, BD.Height - 30);

                Point[] points = { p1, p2, p3, p4 };

                g.DrawPolygon(pen, points);
            }

            Bitmap drawStart = new Bitmap(START.Width, START.Height);
            START.Image = drawStart;
            using(Graphics g = Graphics.FromImage(drawStart))
            {
                Pen greenPen = new Pen(Color.Green, 3);
                g.DrawEllipse(greenPen, START.Width / 2 - 50, START.Height / 2 - 25, 100, 50);
            }

            Bitmap drawStop = new Bitmap(STOP.Width, STOP.Height);
            STOP.Image = drawStop;
            using (Graphics g = Graphics.FromImage(drawStop))
            {
                Pen redPen = new Pen(Color.Red, 3);
                g.DrawEllipse(redPen, STOP.Width / 2 - 50, STOP.Height / 2 - 25, 100, 50);
            }

            DELETE.BackgroundImage = new Bitmap("C:\\Users\\Sosna\\source\\repos\\WinForms_punktowane\\WinForms_punktowane\\trash.png");
            DELETE.BackgroundImageLayout = ImageLayout.Stretch;

            LINK.BackgroundImage = new Bitmap("C:\\Users\\Sosna\\source\\repos\\WinForms_punktowane\\WinForms_punktowane\\link.png");
            LINK.BackgroundImageLayout = ImageLayout.Stretch;

            whichShape = 1;

            mainF = this;

            list = new List<Shape>();
            arrows = new List<Arrow>();

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void BO_Click(object sender, EventArgs e)
        {
            BO.BackColor = Color.LightBlue;
            BD.BackColor = SystemColors.Control;
            STOP.BackColor = SystemColors.Control;
            START.BackColor = SystemColors.Control;
            LINK.BackColor = SystemColors.Control;
            DELETE.BackColor = SystemColors.Control;

            whichShape = 2;
        }

        private void BD_Click(object sender, EventArgs e)
        {
            BD.BackColor = Color.LightBlue;
            BO.BackColor = SystemColors.Control;
            STOP.BackColor = SystemColors.Control;
            START.BackColor = SystemColors.Control;
            LINK.BackColor = SystemColors.Control;
            DELETE.BackColor = SystemColors.Control;

            whichShape = 5;
        }

        private Shape findClosest(int x, int y)
        {
            List<Shape> inArea = new List<Shape>();

            foreach(var v in list)
            {
                if (v.isInTheArea(x, y)) inArea.Add(v);
            }

            if(inArea.Count > 0)
            {
                List<double> distances = new List<double>();

                foreach(var v in inArea)
                {
                    distances.Add(v.GetDistance(x, y));
                }

                int index = distances.IndexOf(distances.Min());

                return inArea[index];
            }
            return null;
        }

        private Dot findClosestDot(int x, int y)
        {
            List<Dot> inArea = new List<Dot>();

            foreach(var v in list)
            {
                foreach(var dot in v.dots)
                if (dot.isInTheArea(x, y)) inArea.Add(dot);
            }

            if(inArea.Count > 0)
            {
                List<double> distances = new List<double>();

                foreach(var v in inArea)
                {
                    distances.Add(v.GetDistance(x, y));
                }

                int index = distances.IndexOf(distances.Min());

                return inArea[index];
            }
            return null;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (moving == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (whichShape == 1)
                    {
                        if (greenEllipses > 0)
                        {
                            MessageBox.Show("Schemat już posiada jeden blok startowy.");
                        }
                        else if (greenEllipses == 0)
                        {
                            GreenEllipse ell = new GreenEllipse(e.X, e.Y);
                            list.Add(ell);
                            DrawCanvas();
                            greenEllipses++;
                        }
                    }
                    if (whichShape == 2)
                    {
                        Rectangle rect = new Rectangle(e.X, e.Y);
                        list.Add(rect);
                        DrawCanvas();
                    }
                    if(whichShape == 3)
                    {
                        Dot closest = findClosestDot(e.X, e.Y);
                        if (closest != null && closest.isConnected == false)
                        {
                            if (closest.inOut == 1)
                            {
                                Arrow arr = new Arrow(closest.x, closest.y, closest);
                                arr.endX = e.X;
                                arr.endY = e.Y;
                                arrows.Add(arr);
                                moving = true;
                                currentArrow = arr;
                                DrawCanvas();
                            }
                        }
                    }
                    if (whichShape == 4)
                    {
                        RedEllipse ell = new RedEllipse(e.X, e.Y);
                        list.Add(ell);
                        DrawCanvas();
                    }
                    if (whichShape == 5)
                    {
                        Diamond diam = new Diamond(e.X, e.Y);
                        list.Add(diam);
                        DrawCanvas();
                    }
                    if (whichShape == 6)
                    {
                        Shape toRemove = findClosest(e.X, e.Y);

                        if (toRemove != null)
                        {
                            if(toRemove == selectedShape)
                            {
                                selectedShape = null;
                                BlockText.Text = "";
                                BlockText.Enabled = false;
                            }
                            List<Arrow> arrToRemove = new List<Arrow>();
                            foreach(var v in toRemove.dots)
                            {
                                foreach(var arr in arrows)
                                {
                                    if (arr.begin == v || arr.end == v) arrToRemove.Add(arr);
                                }
                            }
                            foreach(var v in arrToRemove)
                            {
                                arrows.Remove(v);
                                v.begin.isConnected = false;
                                v.end.isConnected = false;
                            }
                            if (toRemove.GetType().Equals(typeof(GreenEllipse))) greenEllipses--;
                            list.Remove(toRemove);
                            DrawCanvas();
                        }

                    }

                }
                if (e.Button == MouseButtons.Right)
                {

                    Shape toSelect = findClosest(e.X, e.Y);


                    foreach (var v in list)
                    {
                        v.isSelected = false;
                    }

                    selectedShape = toSelect;

                    if (selectedShape != null)
                    {

                        selectedShape.isSelected = true;
                        SelectedText();
                    }
                    else if(selectedShape == null)
                    {
                        BlockText.Text = "";
                        BlockText.Enabled = false;
                    }

                    DrawCanvas();

                }

                if (e.Button == MouseButtons.Middle)
                {
                    if (selectedShape != null)
                    {
                        diffX = e.X - selectedShape.x;
                        diffY = e.Y - selectedShape.y;
                        
                    }
                    moving = true;
                }
            }

        }

        private void SelectedText()
        {
            BlockText.Text = selectedShape.s;

            Type t = selectedShape.GetType();
            if (t.Equals(typeof(Rectangle)) || t.Equals(typeof(Diamond))) BlockText.Enabled = true;
            else if (t.Equals(typeof(GreenEllipse)) || t.Equals(typeof(RedEllipse))) BlockText.Enabled = false;

        }

        private void Canvas_MouseDown_1(object sender, MouseEventArgs e)
        {
            Canvas_MouseDown(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            form = new Form2();

            form.ShowDialog();

        }

        public void DrawCanvas()
        {
            drawArea = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = drawArea;
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
            }

            if (selectedShape != null)
            {
                selectedShape.DrawShape(drawArea);
                foreach (var dot in selectedShape.dots)
                {
                    foreach (var arr in arrows)
                    {
                        if (arr.begin == dot || arr.end == dot)
                        {
                            arr.DrawShape(drawArea);
                            arr.drawn = true;
                        }
                    }
                }
            }

            foreach (var v in list)
            {
                if (v == selectedShape) continue;
                v.DrawShape(drawArea);
                foreach (var dot in v.dots)
                {
                    foreach (var arr in arrows)
                    {
                        if (arr.drawn == false)
                        {
                            if (arr.begin == dot || arr.end == dot)
                            {
                                arr.DrawShape(drawArea);
                                arr.drawn = true;
                            }
                        }
                    }
                }
            }
            foreach (var v in arrows)
            {
                v.drawn = false;
            }
            //foreach (var v in arrows)
            //{
            //    v.DrawShape(drawArea);
            //}


            Canvas.Refresh();

        }

        //public void DrawCanvas()
        //{
        //    drawArea = new Bitmap(Canvas.Width, Canvas.Height);
        //    Canvas.Image = drawArea;
        //    using (Graphics g = Graphics.FromImage(drawArea))
        //    {
        //        g.Clear(Color.White);
        //    }



        //    foreach (var v in list)
        //    {
        //        if (v == selectedShape) continue;
        //        v.DrawShape(drawArea);
        //        foreach (var dot in v.dots)
        //        {
        //            foreach (var arr in arrows)
        //            {
        //                if (arr.drawn == false)
        //                {
        //                    if (arr.begin.parent == selectedShape || arr.end.parent == selectedShape) continue;
        //                    if (arr.begin == dot || arr.end == dot)
        //                    {
        //                        arr.DrawShape(drawArea);
        //                        arr.drawn = true;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (selectedShape != null)
        //    {
        //        selectedShape.DrawShape(drawArea);
        //        foreach (var dot in selectedShape.dots)
        //        {
        //            foreach (var arr in arrows)
        //            {
        //                if (arr.begin == dot || arr.end == dot)
        //                {
        //                    arr.DrawShape(drawArea);
        //                    arr.drawn = true;
        //                }
        //            }
        //        }
        //    }
        //    foreach (var v in arrows)
        //    {
        //        v.drawn = false;
        //    }
        //    //foreach (var v in arrows)
        //    //{
        //    //    v.DrawShape(drawArea);
        //    //}


        //    Canvas.Refresh();

        //}

        public static void createNewBitmap(int width, int height)
        {
            mainF.Canvas.Width = width;
            mainF.Canvas.Height = height;

            mainF.drawArea = new Bitmap(5000, 5000);
            mainF.Canvas.Image = mainF.drawArea;
            using (Graphics g = Graphics.FromImage(mainF.drawArea))
            {
                g.Clear(Color.White);
            }

        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (selectedShape != null)
                {
                    selectedShape.x = e.X - diffX;
                    selectedShape.y = e.Y - diffY;

                    if(selectedShape.x < 0)
                    {
                        selectedShape.x = 0;
                    }
                    else if(selectedShape.x > Canvas.Width)
                    {
                        selectedShape.x = Canvas.Width;
                    }

                    if(selectedShape.y < 0)
                    {
                        selectedShape.y = 0;
                    }
                    else if(selectedShape.y > Canvas.Height)
                    {
                        selectedShape.y = Canvas.Height;
                    }
                }

                moving = false;

                DrawCanvas();
            }

            if(e.Button == MouseButtons.Left)
            {
                if(whichShape == 3)
                {
                    if (currentArrow != null)
                    {
                        Dot closest = findClosestDot(e.X, e.Y);
                        if (closest != null && closest.isConnected == false)
                        {
                            if (closest.inOut == 0)
                            {
                                if (closest.parent != currentArrow.begin.parent)
                                {
                                    currentArrow.begin.isConnected = true;
                                    closest.isConnected = true;
                                    moving = false;
                                    currentArrow.endX = closest.x;
                                    currentArrow.endY = closest.y;
                                    currentArrow.end = closest;
                                    currentArrow = null;
                                    DrawCanvas();
                                    return;
                                }
                            }
                        }
                        arrows.Remove(currentArrow);
                        currentArrow = null;
                        DrawCanvas();
                    }
                    moving = false;
                    
                }
            }

        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                if (selectedShape != null)
                {
                    selectedShape.x = e.X - diffX;
                    selectedShape.y = e.Y - diffY;
                }

                DrawCanvas();
            }
            if(e.Button == MouseButtons.Left)
            {
                if(whichShape == 3)
                {
                    if (currentArrow != null)
                    {
                        currentArrow.endX = e.X;
                        currentArrow.endY = e.Y;
                        DrawCanvas();
                    }
                }
            }
        }

        private void BO_Paint(object sender, PaintEventArgs e)
        {

        }

        private void START_Click(object sender, EventArgs e)
        {
            START.BackColor = Color.LightBlue;
            STOP.BackColor = SystemColors.Control;
            BO.BackColor = SystemColors.Control;
            BD.BackColor = SystemColors.Control;
            LINK.BackColor = SystemColors.Control;
            DELETE.BackColor = SystemColors.Control;

            whichShape = 1;
        }

        private void STOP_Click(object sender, EventArgs e)
        {
            STOP.BackColor = Color.LightBlue;
            START.BackColor = SystemColors.Control;
            BO.BackColor = SystemColors.Control;
            BD.BackColor = SystemColors.Control;
            LINK.BackColor = SystemColors.Control;
            DELETE.BackColor = SystemColors.Control;

            whichShape = 4;
        }

        private void LINK_Click(object sender, EventArgs e)
        {

            LINK.BackColor = Color.LightBlue;
            DELETE.BackColor = SystemColors.Control;
            STOP.BackColor = SystemColors.Control;
            START.BackColor = SystemColors.Control;
            BD.BackColor = SystemColors.Control;
            BO.BackColor = SystemColors.Control;

            whichShape = 3;
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            DELETE.BackColor = Color.LightBlue;
            LINK.BackColor = SystemColors.Control;
            STOP.BackColor = SystemColors.Control;
            START.BackColor = SystemColors.Control;
            BO.BackColor = SystemColors.Control;
            BD.BackColor = SystemColors.Control;

            whichShape = 6;
        }

        private void BlockText_TextChanged(object sender, EventArgs e)
        {
            if(selectedShape != null)
            {
                selectedShape.s = BlockText.Text;
                DrawCanvas();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream;
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Plik diagramu(*.diag)|*.diag";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    //if((myStream = (System.IO.FileStream)save.OpenFile()) != null)
                    //{
                    //    AddText(myStream, "chuj");
                    //    myStream.Close();
                    //}
                    //System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(ToSerialize));
                    //System.IO.TextWriter writer = new System.IO.StreamWriter(save.FileName);
                    //ToSerialize ts = new ToSerialize(list, arrows);
                    //ser.Serialize(writer, ts);
                    //writer.Close();
                    if ((myStream = save.OpenFile()) != null)
                    {
                        ToSerialize ts = new ToSerialize(list, arrows, Canvas.Width, Canvas.Height, greenEllipses, selectedShape);
                        var ser = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        ser.Serialize(myStream, ts);

                        myStream.Close();
                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog load = new OpenFileDialog())
            {
                load.Filter = "Pliki diagramu(*.diag)|*.diag";
                if(load.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Stream myStream = load.OpenFile();

                        if(myStream != null)
                        {
                            var ser = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            ToSerialize ts = (ToSerialize)ser.Deserialize(myStream);
                            list = ts.shapes;
                            arrows = ts.arrows;
                            Canvas.Width = ts.width;
                            Canvas.Height = ts.height;
                            greenEllipses = ts.greenEllipses;
                            selectedShape = ts.selectedShape;


                            myStream.Close();

                            DrawCanvas();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Zły plik.");
                    }
                }
            }
        }
    }

    [Serializable]
    public class Shape
    {
        public int x;
        public int y;
        public string s;

        public bool isSelected;

        public List<Dot> dots;

        public Shape() { }

        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
            s = "";
            dots = null;
        }
        public virtual void DrawShape(Bitmap drawArea) { }
        public virtual double GetDistance(int mouseX, int mouseY)
        {
            return (mouseX - x) * (mouseX - x) + (mouseY - y) * (mouseY - y);
        }

        public virtual bool isInTheArea(int mouseX, int mouseY) { return false; }
    }

    [Serializable]
    public class Rectangle : Shape
    {
        public Rectangle(int x, int y) : base(x, y)
        {
            s = "blok operacyjny";
            dots = new List<Dot>();
            Dot d1 = new Dot(x, y - height / 2, 0);
            dots.Add(d1);
            Dot d2 = new Dot(x, y + height / 2, 1);
            dots.Add(d2);
        }
        
                

        public static int width = 150;
        public static int height = 100;

        public Rectangle() { }

        public override void DrawShape(Bitmap drawArea)
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                Pen tempPen = new Pen(Color.Black, 3);
                if (isSelected == true)
                {
                    tempPen.DashPattern = new float[] { 2, 1 };
                }

                g.FillRectangle(Brushes.White, x - width / 2, y - height / 2, width, height);
                g.DrawRectangle(tempPen, x - width / 2, y - height / 2, width, height);

                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 7);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;

                RectangleF textRect = new RectangleF(x - width / 2 + 5, y - height / 2 + 5, width - 5, height - 5);


                g.DrawString(s, drawFont, drawBrush, textRect, drawFormat);

                dots[0].x = x;
                dots[0].y = y - height / 2;
                dots[1].x = x;
                dots[1].y = y + height / 2;

                foreach(var v in dots)
                {
                    v.DrawShape(drawArea);
                    v.parent = this;
                }
            }

        }

        public override bool isInTheArea(int mouseX, int mouseY)
        {
            if (mouseX < x - width / 2) return false;
            if (mouseX > x + width / 2) return false;
            if (mouseY < y - height / 2) return false;
            if (mouseY > y + height / 2) return false;

            return true;
        }
    }

    [Serializable]
    public class Diamond : Shape
    {
        public Diamond(int x, int y) : base(x, y)
        {
            s = "blok decyzyjny";
            dots = new List<Dot>();
            Dot d1 = new Dot(x, y - height / 2, 0);
            dots.Add(d1);
            Dot d2 = new Dot(x - width / 2, y, 1);
            dots.Add(d2);
            Dot d3 = new Dot(x + width / 2, y, 1);
            dots.Add(d3);
        }

        public static int width = 200;
        public static int height = 150;

        public RectangleF textRect;

        public Diamond() { }

        public override void DrawShape(Bitmap drawArea)
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                Pen tempPen = new Pen(Color.Black, 3);
                if (isSelected == true)
                {
                    tempPen.DashPattern = new float[] { 2, 1 };
                }

                Point point1 = new Point(x - width / 2, y);
                Point point2 = new Point(x, y - height / 2);
                Point point3 = new Point(x + width / 2, y);
                Point point4 = new Point(x, y + height / 2);
                Point[] points = { point1, point2, point3, point4 };

                g.FillPolygon(Brushes.White, points);
                g.DrawPolygon(tempPen, points);

                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 7);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;

                RectangleF textRect = new RectangleF(x - width / 4, y - height / 4, width / 2, height / 2);

                g.DrawString(s, drawFont, drawBrush, textRect, drawFormat);

                dots[0].x = x;
                dots[0].y = y - height / 2;
                dots[1].x = x - width / 2;
                dots[1].y = y;
                dots[2].x = x + width / 2;
                dots[2].y = y;

                foreach(var v in dots)
                {
                    v.DrawShape(drawArea);
                    v.parent = this;
                }

            }
        }

        public override bool isInTheArea(int mouseX, int mouseY)
        {

            if (mouseY - y < (1.0 * -(height / 2)) / (width / 2) * (mouseX - x) - height / 2) return false;
            if (mouseY - y > (1.0 * -(height / 2)) / (width / 2) * (mouseX - x) + height / 2) return false;
            if (mouseY - y < (1.0 * (height / 2)) / (width / 2) * (mouseX - x) - height / 2) return false;
            if (mouseY - y > (1.0 * (height / 2)) / (width / 2) * (mouseX - x) + height / 2) return false;

            return true;

        }
    }

    [Serializable]
    public class GreenEllipse : Shape
    {
        public GreenEllipse(int x, int y) : base(x, y)
        {
            s = "START";
            dots = new List<Dot>();
            Dot d = new Dot(x, y + radius2, 1);
            dots.Add(d);
        }

        public static int radius1 = 100;
        public static int radius2 = 50;

        public GreenEllipse() { }
        public override void DrawShape(Bitmap drawArea)
        {

            using (Graphics g = Graphics.FromImage(drawArea))
            {

                Pen tempPen = new Pen(Color.Green, 3);
                if (isSelected == true)
                {
                    tempPen.DashPattern = new float[] { 2, 1 };
                }

                g.FillEllipse(Brushes.White, x - radius1, y - radius2, 2 * radius1, 2 * radius2);
                g.DrawEllipse(tempPen, x - radius1, y - radius2, 2 * radius1, 2 * radius2);


                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 17);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;


                g.DrawString(s, drawFont, drawBrush, x, y, drawFormat);

                dots[0].x = x;
                dots[0].y = y + radius2;

                foreach(var v in dots)
                {
                    v.DrawShape(drawArea);
                    v.parent = this;
                }
            }

        }

        public override bool isInTheArea(int mouseX, int mouseY)
        {
            if (((mouseX - x) * (mouseX - x) * 1.0) / (radius1 * radius1) + ((mouseY - y) * (mouseY - y) * 1.0) / (radius2 * radius2) > 1.0) return false;

            return true;
        }
    }

    [Serializable]
    public class RedEllipse : Shape
    {
        public RedEllipse(int x, int y) : base(x, y)
        {
            s = "STOP";
            dots = new List<Dot>();
            Dot d = new Dot(x, y - radius2, 0);
            dots.Add(d);
        }

        public static int radius1 = 100;
        public static int radius2 = 50;

        public RedEllipse() { }

        public override void DrawShape(Bitmap drawArea)
        {

            using (Graphics g = Graphics.FromImage(drawArea))
            {

                Pen tempPen = new Pen(Color.Red, 3);
                if(isSelected == true)
                {
                    tempPen.DashPattern = new float[] { 2, 1 };
                }
                

                g.FillEllipse(Brushes.White, x - radius1, y - radius2, 2 * radius1, 2 * radius2);
                g.DrawEllipse(tempPen, x - radius1, y - radius2, 2 * radius1, 2 * radius2);


                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 17);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;


                g.DrawString(s, drawFont, drawBrush, x, y, drawFormat);

                dots[0].x = x;
                dots[0].y = y - radius2;

                foreach(var v in dots)
                {
                    v.DrawShape(drawArea);
                    v.parent = this;
                }

                
            }

        }
        public override bool isInTheArea(int mouseX, int mouseY)
        {
            if (((mouseX - x) * (mouseX - x) * 1.0) / (radius1 * radius1) + ((mouseY - y) * (mouseY - y) * 1.0) / (radius2 * radius2) > 1.0) return false;

            return true;
        }
    }

    [Serializable]
    public class Dot : Shape
    {

        static int radius = 6;

        public Shape parent = null;

        public int inOut;

        public Dot() { }
        public Dot(int x, int y, int inOut) : base(x, y)
        {
            this.inOut = inOut;
        }

        public bool isConnected = false;


        public override void DrawShape(Bitmap drawArea)
        {
            if (isConnected == false)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    Pen tempPen = new Pen(Brushes.Black, 3);

                    g.DrawEllipse(tempPen, x - radius, y - radius, 2 * radius, 2 * radius);
                    if (inOut == 0)
                    {
                        g.FillEllipse(Brushes.White, x - radius, y - radius, 2 * radius, 2 * radius);
                    }
                    else if (inOut == 1)
                    {
                        g.FillEllipse(Brushes.Black, x - radius, y - radius, 2 * radius, 2 * radius);
                    }
                }
            }
        }

        public override bool isInTheArea(int mouseX, int mouseY)
        {
            if (((mouseX - x) * (mouseX - x) * 1.0) / (radius * radius) + ((mouseY - y) * (mouseY - y) * 1.0) / (radius * radius) > 1.0) return false;

            return true;
        }

    }

    [Serializable]
    public class Arrow : Shape
    {
        public int endX;
        public int endY;

        public Dot begin = null;
        public Dot end = null;

        public bool drawn = false;

        public Arrow() { }

        public Arrow(int x, int y, Dot begin) : base(x, y)
        {
            this.begin = begin;
        }

        public override void DrawShape(Bitmap drawArea)
        {
            using(Graphics g = Graphics.FromImage(drawArea))
            {
                Pen tempPen = new Pen(Brushes.Black, 3);

                tempPen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);

                if(end == null)
                {
                    g.DrawLine(tempPen, begin.x, begin.y, endX, endY);
                }
                else if(end != null)
                {
                    g.DrawLine(tempPen, begin.x, begin.y, end.x, end.y);
                }
                
            }
        }

    }

    [Serializable]
    public class ToSerialize
    {
        public List<Shape> shapes;
        public List<Arrow> arrows;
        public int width;
        public int height;
        public int greenEllipses;
        public Shape selectedShape;

        public ToSerialize(List<Shape> shapes, List<Arrow> arrows, int width, int height, int greenEllipses, Shape selectedShape)
        {
            this.shapes = shapes;
            this.arrows = arrows;
            this.width = width;
            this.height = height;
            this.greenEllipses = greenEllipses;
            this.selectedShape = selectedShape;
        }
    }
}
