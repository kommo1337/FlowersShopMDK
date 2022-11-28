using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlowersShopMDK.ClassFolder
{
    internal class CBClass
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=kommo;Integrated Security=True");
        SqlDataAdapter sqlData;
        DataSet dataSet;

        public void RoleCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select RoleId, Name " +
                    "From dbo.[Role] Order by RoleId ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet.Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Role]"].Columns["Name"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Role]"].Columns["RoleId"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
