using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferLayer;
namespace DataLayer
{
    public class SupplierDL : DataProvider
    {
        public List<Supplier> GetSuppliers()
        {
            string sql = "Select * from Supplier";
            DataTable dt = MyExecuteReader(sql, CommandType.Text);
            List<Supplier> suppliers = new List<Supplier>();
            foreach (DataRow row in dt.Rows)
            {
                suppliers.Add(new Supplier(
                    row["id"].ToString(),
                    row["name"].ToString(),
                    row["address"].ToString()
                ));
            }
            return suppliers;
        }

        public void AddSupplier(Supplier supplier)
        {
            string sql = "Selete * from Supplier";
            DataTable dt = MyExecuteReader(sql, CommandType.Text);
            DataRow row = dt.NewRow();
            row["id"] = supplier.id;
            row["name"] = supplier.name;
            row["address"] = supplier.address;
            dt.Rows.Add(row);
            MyExecuteNonQuery(sql, CommandType.Text, dt);
        }

        public void DeleteSupplier(string id)
        {
            string sql = "Select * from Supplier";
            DataTable dt = MyExecuteReader(sql, CommandType.Text);
            foreach(DataRow row in dt.Rows)
            {
                if (row["id"].ToString() == id)
                {
                    dt.Rows.Remove(row);
                    break;
                }
            }
            MyExecuteNonQuery(sql, CommandType.Text, dt);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            string sql = "Select * from Supplier";
            DataTable dt = MyExecuteReader(sql, CommandType.Text);
            foreach (DataRow row in dt.Rows)
            {
                if (row["id"].ToString() == supplier.id.ToString())
                {
                    row["name"] = supplier.name;
                    row["address"] = supplier.address;
                    break;
                }
            }
            MyExecuteNonQuery(sql, CommandType.Text, dt);
        }
    } 
}
