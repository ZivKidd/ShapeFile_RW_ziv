using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Data;

namespace ShapeFile
{
    public partial class Form1 : Form
    {
        #region
        //global variables
        List<MyPoint> global_mypoint_list = new List<MyPoint>();
        List<MyLine> global_myline_list = new List<MyLine>();
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            global_myline_list = InputShp.inputMyLine(@"test_files\line.shp");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OutputShp.outputMyLine(global_myline_list, @"test_files\line1.shp");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            global_mypoint_list = InputShp.inputMyPoint(@"test_files\point.shp");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OutputShp.outputMyPoint(global_mypoint_list, @"test_files\point1.shp");
        }
    }
}
