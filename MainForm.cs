using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatchTemplateOpenCV.Lib;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace MatchTemplateOpenCV
{
    public partial class MainForm : Form
    {
        string file_img_source = null;
        string file_img_template = null;

        public MainForm()
        {
            InitializeComponent();
            InitVar();
            InitGUI();
        }

        void InitVar()
        {
            file_img_source = "";
            file_img_template = "";
        }

        void InitGUI()
        {
            cbbTemplateMatchModes.DataSource = Enum.GetValues(typeof(TemplateMatchModes));
            cbbTemplateMatchModes.SelectedItem = TemplateMatchModes.CCoeffNormed;
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            var btn_name = (sender as Button).Name;
            switch(btn_name)
            {
                case "btnLoadSource":
                    file_img_source = MyLib.OpenFileDialog(eTypeFile.File_Image, MyDefine.projectDirectory);
                    lbFileSource.Text = String.IsNullOrEmpty(file_img_source) ? "null" : file_img_source;
                    break;

                case "btnLoadTemplate":
                    file_img_template = MyLib.OpenFileDialog(eTypeFile.File_Image);
                    lbFileTemplate.Text = String.IsNullOrEmpty(file_img_template) ? "null" : file_img_template;
                    break;
            }
        }

        public delegate void DelegateStandardPattern(string data);
        void AddDataListView(string data)
        {
            var date_time = DateTime.Now.ToShortTimeString();
            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateStandardPattern(AddDataListView), data);
                return;
            }
            listLog.Items.Insert(0, String.Format("{0}: {1}", date_time, data));
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {

        }

        int index_img = 0;
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!MyLib.IsImagePath(file_img_source))
                {
                    AddDataListView("err -> check source: " + file_img_source);
                    return;
                }

                if (!MyLib.IsImagePath(file_img_template))
                {
                    AddDataListView("err -> check template: " + file_img_template);
                    return;
                }
                index_img++;

                Mat img_source_color = Cv2.ImRead(file_img_source, ImreadModes.Color);

                Mat img_source = new Mat();
                Cv2.CvtColor(img_source_color, img_source, ColorConversionCodes.BGR2GRAY);
                //AddDataListView("read image: " + file_img_source);

                Mat img_template = Cv2.ImRead(file_img_template, ImreadModes.Grayscale);
                //AddDataListView("read image: " + file_img_template);

                //AddDataListView("blur process");
                //Cv2.MedianBlur(img_source, img_source, 3);
                //Cv2.MedianBlur(img_template, img_template, 3);


                TemplateMatchModes template_match_mode;
                Enum.TryParse<TemplateMatchModes>(cbbTemplateMatchModes.SelectedValue.ToString(), out template_match_mode);
                AddDataListView($"MatchTemplate type: {template_match_mode}");
                
                Mat result = new Mat(img_source.Rows - img_template.Rows + 1, img_source.Cols - img_template.Cols + 1, MatType.CV_32FC1);
                Cv2.MatchTemplate(img_source, img_template, result, template_match_mode);
                //Cv2.Normalize(result, result, 0, 1, NormTypes.MinMax);
                
                double minval=0, maxval=0, score = 0;
                OpenCvSharp.Point minloc = new OpenCvSharp.Point(0,0), maxloc = new OpenCvSharp.Point(0,0);
                Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);
                Rect r;
                if (template_match_mode == TemplateMatchModes.SqDiff || template_match_mode == TemplateMatchModes.SqDiffNormed)
                {
                    //Setup the rectangle to draw
                    r = new Rect(new OpenCvSharp.Point(minloc.X, minloc.Y), new OpenCvSharp.Size(img_template.Width, img_template.Height));
                    score = (1 - minval) * 100;
                    AddDataListView($"***{template_match_mode}: score = {score}, MinVal={minval} MaxVal={maxval} MinLoc={minloc} Max Loc={maxloc} Rect={r}");
                }
                else
                {
                    //Setup the rectangle to draw
                    r = new Rect(new OpenCvSharp.Point(maxloc.X, maxloc.Y), new OpenCvSharp.Size(img_template.Width, img_template.Height));
                    score = maxval * 100;
                    AddDataListView($"{template_match_mode}: score = {score}, MinVal={minval} MaxVal={maxval} MinLoc={minloc} MaxLoc={maxloc} Rect={r}");
                }

                //Draw a rectangle of the matching area
                Cv2.Rectangle(img_source_color, r, Scalar.LimeGreen, 2);
                Cv2.PutText(img_source_color, Math.Round(score, 2).ToString(), r.TopLeft, HersheyFonts.HersheyComplexSmall, 1.0, new Scalar(0, 0, 255));

                MyLib.Save_Mat(img_source_color, index_img.ToString());
                var frameBitmap = BitmapConverter.ToBitmap(img_source_color);
                pictureBox.Image = frameBitmap;


                img_source_color.Release();
                img_source.Release();
                img_template.Release();
                result.Release();
            }
            catch(Exception exception)
            {
                MyLib.ShowDlgError(exception.Message);
            }
        }
    }
}
