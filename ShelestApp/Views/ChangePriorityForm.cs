using ShelestApp.Models;
using ShelestApp.Utilities;
using ShelestApp.Views.PartialView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShelestApp.Views
{
    public partial class ChangePriorityForm : Form
    {
        List<Agent> agents = new List<Agent>();
        public ChangePriorityForm(List<AgentCard> agentCards)
        {
            InitializeComponent();
            priorityValue.Maximum = Int32.MaxValue;
            GetMaximumPriority(agentCards);
        }

        private void GetMaximumPriority(List<AgentCard> cards)
        {
            foreach (AgentCard card in cards)
            {
                agents.Add(DBContext.Context.Agent.First(item => item.ID.ToString() == card.idLbl.Text));
            }
            foreach (Agent agent in agents)
            {
                if (agent.Priority > priorityValue.Value)
                    priorityValue.Value = agent.Priority;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (Agent agent in agents)
            {
                agent.Priority = (int)priorityValue.Value;
            }
            try
            {
                DBContext.Context.SaveChanges();
                MessageBox.Show($"Данные сохранены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
