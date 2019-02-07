using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSpatial.Data;
using DotSpatial.Topology;

namespace ShapeFile
{
    class OutputShp
    {
        /// <summary>
        /// 由点list新建shp文件
        /// </summary>
        /// <param name="point_list"></param>
        /// <param name="file_path"></param>
        public static void outputMyPoint(List<MyPoint> point_list, string file_path)
        {
            Feature f = new Feature();
            FeatureSet fs = new FeatureSet(f.FeatureType);
            //fs.DataTable.Columns.Add("azimuth", typeof(double));
            //fs.DataTable.Columns.Add("speed", typeof(double));
            DotSpatial.Topology.Coordinate[] coordinate = new DotSpatial.Topology.Coordinate[point_list.Count];
            for (int i = 0; i < point_list.Count; i++)
            {
                coordinate[i] = new DotSpatial.Topology.Coordinate(point_list[i].x, point_list[i].y);
                fs.Features.Add(coordinate[i]);
                //fs.DataTable.Rows[i]["azimuth"] = point_list[i].azimuth;
                //fs.DataTable.Rows[i]["speed"] = point_list[i].speed;
            }
            fs.SaveAs(file_path, true);
            //fs.Projection.SaveAs(file_path.Substring(0, file_path.Length - 4) + ".prj");
        }

        /// <summary>
        /// 由线list新建shp
        /// </summary>
        /// <param name="point_list"></param>
        /// <param name="file_path"></param>
        public static void outputMyLine(List<MyLine> line_list, string file_path)
        {
            DotSpatial.Data.Feature f = new Feature(new Shape(FeatureType.Line));
            DotSpatial.Data.FeatureSet fs = new FeatureSet(f.FeatureType);
            //fs.DataTable.Columns.Add("width", typeof(double));
            //fs.DataTable.Columns.Add("distance", typeof(double));
            for (int i = 0; i < line_list.Count; i++)
            {
                List<Coordinate> coor_list = new List<Coordinate>();
                foreach (MyPoint point in line_list[i].points_mid)
                {
                    coor_list.Add(new DotSpatial.Topology.Coordinate(point.x, point.y));
                }
                fs.Features.Add(coor_list, FeatureType.Line);
                //fs.DataTable.Rows[i]["width"] = line_list[i].width;
                //fs.DataTable.Rows[i]["distance"] = line_list[i].distance_to_ori;
            }
            fs.SaveAs(file_path, true);
            //fs.Projection.SaveAs(file_path.Substring(0, file_path.Length - 4) + ".prj");
        }
    }
}
