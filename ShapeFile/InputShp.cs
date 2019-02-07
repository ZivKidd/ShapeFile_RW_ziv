using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSpatial.Data;
using DotSpatial.Topology;

namespace ShapeFile
{
    class InputShp
    {
        /// <summary>
        /// 读入点shp
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        public static List<MyPoint> inputMyPoint(string file_path)
        {
            List<MyPoint> point_list = new List<MyPoint>();
            Shapefile shapefile = Shapefile.Open(file_path) as Shapefile;
            shapefile.ReadProjection();
            foreach (Feature feature in shapefile.Features)
            {
                MyPoint mypoint = new MyPoint(feature.Coordinates[0].X, feature.Coordinates[0].Y);
                point_list.Add(mypoint);
            }
            return point_list;
        }

        /// <summary>
        /// 读入线shp
        /// </summary>
        /// <param name="file_path"></param>
        public static List<MyLine> inputMyLine(string file_path)
        {
            List<MyLine> line_list = new List<MyLine>();
            Shapefile shapefile = Shapefile.Open(file_path) as Shapefile;
            shapefile.ReadProjection();
            foreach (Feature feature in shapefile.Features)
            {
                MyLine myline = new MyLine();
                for (int j = 0; j < feature.Coordinates.Count; j++)
                {
                    MyPoint mypoint = new MyPoint(feature.Coordinates[j].X, feature.Coordinates[j].Y);
                    myline.points_mid.Add(mypoint);
                }
                line_list.Add(myline);
            }
            return line_list;
        }
    }
}
