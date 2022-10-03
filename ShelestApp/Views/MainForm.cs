using ShelestApp.Models;
using ShelestApp.Utilities;
using ShelestApp.Views;
using ShelestApp.Views.PartialView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShelestApp
{
    public partial class MainForm : Form
    {
        List<Agent> agents;
        List<AgentCard> selectedAgents = new List<AgentCard>();
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
            nPageMax = (agents.Count / 10) < 1 ? 1 : (agents.Count / 10);
            agents = agents.Skip(nPage * pageSize).Take(pageSize).ToList();
            pagesLbl.Text = $"{nPage + 1} из {nPageMax}";
            flowLayoutPanel1.Controls.Clear();
            foreach (Agent agent in agents)
            {
                AgentCard card = new AgentCard();
                card.GenerateAgentData(agent);
                flowLayoutPanel1.Controls.Add(card);

                card.Click += Card_Click;
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            AgentCard card = sender as AgentCard;

            if (card.BackColor == Color.White)
            {
                selectedAgents.Add(card);
                card.BackColor = Color.FromArgb(70, 178, 157);
            }
            else
            {
                selectedAgents.Remove(card);
                card.BackColor = Color.White;
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

            selectedAgents.Clear();
            GenerateAgentList(updatedList, nPage, 10);
        }
        #endregion

        private void TriggerFilters(Object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Введите для поиска"
                || String.IsNullOrWhiteSpace(searchTextBox.Text))
                return;
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

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(searchTextBox.Text))
                searchTextBox.Text = "Введите для поиска";
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if(searchTextBox.Text == "Введите для поиска")
                searchTextBox.Text = String.Empty;
        }

        private void changePriority_Click(object sender, EventArgs e)
        {
            if (selectedAgents.Count >= 1)
            {
                ChangePriorityForm form = new ChangePriorityForm(selectedAgents);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    selectedAgents.Clear();
                    ApplyFilters();
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать хотя бы одного агента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
