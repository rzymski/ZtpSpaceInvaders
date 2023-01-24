using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTP.Projekt
{
    public class Score
    {
        public int Id { get; set; }
        public int PlayerScore { get; set; }
        public string? Nick { get; set; }
        public void SaveToExcel(WorkSheet ws)
        {
            int lastRow = ws.RowCount;
            // ws.Rows[lastRow + 1].Columns[1].Value = this.Id;
            //ws.Rows[lastRow + 1].Columns[2].Value = this.PlayerScore;
            // ws.Rows[lastRow + 1].Columns[3].Value = this.Nick;

            int lastid = ws[$"A{lastRow}"].IntValue;
            this.Id = lastid + 1;

            ws[$"A{lastRow + 1}"].Value = this.Id;
            ws[$"B{lastRow + 1}"].Value = this.PlayerScore;
            ws[$"C{lastRow + 1}"].Value = this.Nick;
        }
    }
}
