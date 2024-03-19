using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Utilities
{
    public class BarChartUtility
    {
        private string title;

        public string colName { get; set; }

        private List<string> categories;

        private List<Serie> series;

        public BarChartUtility(string title, string colName, List<string> categories)
        {
            this.title = title;
            this.colName = colName;
            this.categories = categories;
            series = new List<Serie>();
        }

        public BarChartUtility AddSerie(string name)
        {
            series.Add(new Serie(name));
            return this;
        }

        public BarChartUtility AddDataToLastSerie(params long[] data)
        {
            series.Last().AddData(data.ToList());
            return this;
        }

        public object AsResult()
        {
            return new
            {
                chart = new { type = "column" },
                tooltip = new { useHTML = true },
                style = new { direction = "rtl" },
                title = new { text = title },
                xAxis = new { categories = categories },
                yAxis = new { title = new { text = colName } },
                series = series.ToList().ConvertAll(f => new
                {
                    name = f.Name,
                    data = f.Data
                })
            };
        }

        private class Serie
        {
            public Serie(string name)
            {
                Name = name;
                Data = new List<long>();
            }

            public string Name { get; set; }

            public List<long> Data { get; set; }

            public Serie AddData(List<long> data)
            {
                Data.AddRange(data);
                return this;
            }
        }
    }
}
