using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peon.Maps;

namespace Peon.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void buttonGeocodeDecode_Click(object sender, EventArgs e)
        {
            backgroundWorkerGeocode.RunWorkerAsync(textBoxGeocodeAddress.Text);
        }

        void backgroundWorkerGeocode_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = GeocodeResponse.Get((string)e.Argument);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void backgroundWorkerGeocode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            propertyGridGeocode.SelectedObject = e.Result;

            if (e.Result is GeocodeResponse)
            {
                GeocodeResponse response = ((GeocodeResponse)e.Result);
                if (response.Results.Count >= 1)
                {
                    Map map = new Map(response.Results[0].Geometry.Location.ToString(), zoom:20);
                    map.Width = pictureBoxMap.Width;
                    map.Height = pictureBoxMap.Height;
                    map.Features.Add(new Marker(response.Results[0].Geometry.Location));
                    Path area = new Path(fillColor: FeatureColor.white, weight:0);
                    area.Points.Add(response.Results[0].Geometry.Bounds.SouthWest);
                    area.Points.Add(response.Results[0].Geometry.Bounds.SouthEast);
                    area.Points.Add(response.Results[0].Geometry.Bounds.NorthEast);
                    area.Points.Add(response.Results[0].Geometry.Bounds.NorthWest);
                    area.Geodesic = true;
                    map.Features.Add(area);

                    map.VisiblePlaces.Add(response.Results[0].Geometry.Bounds.SouthWest);
                    map.VisiblePlaces.Add(response.Results[0].Geometry.Bounds.NorthEast);
                    map.Generate();
                    propertyGridMap.SelectedObject = map;
                    pictureBoxMap.Image = map.Image;
                }
            }
        }

        void pictureBoxMap_SizeChanged(object sender, EventArgs e)
        {
            if (propertyGridMap.SelectedObject != null)
            {
                Map map = (Map)propertyGridMap.SelectedObject;
                map.Width = pictureBoxMap.Width;
                map.Height = pictureBoxMap.Height;
                map.Generate();
                pictureBoxMap.Image = map.Image;
            }
        }

        void buttonGenerateMap_Click(object sender, EventArgs e)
        {
            if (propertyGridMap.SelectedObject != null)
            {
                Map map = (Map)propertyGridMap.SelectedObject;
                map.Generate();
                pictureBoxMap.Image = map.Image;
            }
        }
    }
}
