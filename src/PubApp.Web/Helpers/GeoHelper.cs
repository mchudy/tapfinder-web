using System.Data.Entity.Spatial;

namespace PubApp.Web.Helpers
{
    public static class GeoHelper
    {
        public static DbGeography FromPoint(double latitude, double longitude)
        {
            var text = $"POINT({longitude} {latitude})";
            return DbGeography.PointFromText(text, 4326);
        }
    }
}