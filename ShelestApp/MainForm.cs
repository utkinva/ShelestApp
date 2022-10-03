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

namespace ShelestApp
{
    public partial class MainForm : Form
    {
        public List<Agent> agents = new List<Agent>();
        int nPage = 0;
        int nPageMax = 0;
        public MainForm()
        {
            InitializeComponent();
            agents = DBContext.Context.Agent.ToList();
            GenerateAgentList(agents, nPage, 10);

            List<AgentType> agentTypes = DBContext.Context.AgentType.ToList();
            agentTypes.Insert(0, new AgentType { Title = "Все типы" });
            filterComboBox.DataSource = agentTypes;
            sortComboBox.SelectedIndex = 0;
            filterComboBox.SelectedIndex = 0;
        }

        private void GenerateAgentList(List<Agent> agents, int nPage, int pageSize)
        {
            nPageMax = ((int)agents.Count / 10) < 1 ? 1 : ((int)agents.Count / 10);
            agents = agents.Skip(nPage * pageSize).Take(pageSize).ToList();
            pagesLbl.Text = $"{nPage + 1} из {nPageMax}";
            flowLayoutPanel1.Controls.Clear();
            foreach (Agent agent in agents)
            {
                AgentCard card = new AgentCard();
                card.GenerateAgentData(agent);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        #region Поиск, сортировка и фильтрация
        private void ApplyFilters()
        {
            List<Agent> updatedList = DBContext.Context.Agent.ToList();

            #region Поиск
            if (searchTextBox.Text != "Введите для поиска"
                && !String.IsNullOrWhiteSpace(searchTextBox.Text))
                updatedList = updatedList
                    .Where(item => item.Title.ToLower().Contains(searchTextBox.Text.ToLower())
                    || item.Phone.Replace(" ", "").Contains(searchTextBox.Text)
                    || item.Email.ToLower().Contains(searchTextBox.Text.ToLower()))
                    .ToList();
            #endregion
            #region Сортировка
            if (sortComboBox.SelectedIndex > 0)
                switch (sortComboBox.SelectedIndex)
                {
                    case 1:
                        if (!descCheckBox.Checked)
                            updatedList = updatedList.OrderBy(item => item.Title).ToList();
                        else
                            updatedList = updatedList.OrderByDescending(item => item.Title).ToList();
                        break;
                    case 2:
                        if (!descCheckBox.Checked)
                            updatedList = updatedList.OrderBy(item => item.Discount).ToList();
                        else
                            updatedList = updatedList.OrderByDescending(item => item.Discount).ToList();
                        break;
                    case 3:
                        if (!descCheckBox.Checked)
                            updatedList = updatedList.OrderBy(item => item.Priority).ToList();
                        else
                            updatedList = updatedList.OrderByDescending(item => item.Priority).ToList();
                        break;
                }
            #endregion
            #region Фильтрация
            if (filterComboBox.SelectedIndex > 0)
                updatedList = updatedList
                    .Where(item => item.AgentTypeID == (filterComboBox.SelectedItem as AgentType).ID)
                    .ToList();
            #endregion

            GenerateAgentList(updatedList, nPage, 10);
        }
        #endregion

        private void TriggerFilters(Object sender, EventArgs e)
        {
            nPage = 0;
            ApplyFilters();
        }

        private void prevPageLbl_Click(object sender, EventArgs e)
        {
            if (nPage > 0)
            {
                nPage--;
                ApplyFilters();
            }
        }

        private void nextPageLbl_Click(object sender, EventArgs e)
        {
            if (nPage + 1 < nPageMax)
            {
                nPage++;
                ApplyFilters();
            }
        }
    }
}
