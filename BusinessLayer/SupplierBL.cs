using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferLayer;
using DataLayer;
using System.Data.SqlClient;
namespace BusinessLayer
{
    public class SupplierBL
    {
        private SupplierDL supplierDL;
        public SupplierBL()
        {
            supplierDL = new SupplierDL();
        }
        public List<Supplier> GetSuppliers()
        {
            try
            {
                return supplierDL.GetSuppliers();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
