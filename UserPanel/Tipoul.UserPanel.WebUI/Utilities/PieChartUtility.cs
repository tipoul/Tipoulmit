using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Utilities
{
    public class PieChartUtility
    {
        private string title;

        public string colName { get; set; }

        private List<string> categories;

        private List<Serie> series;

        public PieChartUtility(string title, string colName, List<string> categories)
        {
            this.title = title;
            this.colName = colName;
            this.categories = categories;
            series = new List<Serie>();
        }

        public PieChartUtility AddSerie(string name, long value)
        {
            series.Add(new Serie(name, value));
            return this;
        }

        public object AsResult()
        {
            return new
            {
                chart = new { type = "pie" },
                tooltip = new { useHTML = true },
                style = new { direction = "rtl" },
                title = new { text = title },
                xAxis = new { categories = categories },
                yAxis = new { title = new { text = colName } },
                series = new[]
                {
                    new
                    {
                        data = series.ToList().ConvertAll(f => new
                        {
                            name = f.Name,
                            y = f.Data
                        })
                    }
                }
            };
        }

        private class Serie
        {
            public Serie(string name, long data)
            {
                Name = name;
                Data = data;
            }

            public string Name { get; set; }

            public long Data { get; set; }
        }
    }
}
