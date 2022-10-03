using ShelestApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShelestApp.Views.PartialView
{
    public partial class AgentCard : UserControl
    {
        public AgentCard()
        {
            InitializeComponent();
        }

        public void GenerateAgentData(Agent agent)
        {
            ImageConverter converter = new ImageConverter();
            if (agent.Image != null)
                logoPictureBox.Image = (Image)converter.ConvertFrom(agent.Image);
            titleTypeLbl.Text = $"{agent.AgentType.Title} | {agent.Title}";
            salesQtyLbl.Text = $"{agent.SalesQtyPerLastYear} продаж за год";
            phoneLbl.Text = $"{agent.Phone}";
            priorityLbl.Text = $"Приоритет: {agent.Priority}";
            discountLbl.Text = $"{agent.Discount}%";

            if (agent.Discount >= 25)
            {
                titleTypeLbl.ForeColor = Color.LightGreen;
                discountLbl.ForeColor = Color.LightGreen;
            }
        }
    }
}
