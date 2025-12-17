using Büromaterialbestellungen.Classes.Records;
using Büromaterialbestellungen.Classes.Container;
using UserAccount.Classes.Container;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Büromaterialbestellungen.Classes.Services
{
    public class CclSvcOrder
    {

        #region Instance variables
        ///**************************************************
        /// Instance variables
        private List<CclContProductOrder> I_liProducts = new List<CclContProductOrder>();

        #endregion Instance variables

        #region Properties
        ///**************************************************
        /// Properties
        internal CclContUserData User { get; }
        internal CclRecOrder Order { get; } = new CclRecOrder();

        internal string ID { get { return Order.ID; } }

        internal DateTime Date { get { return Order.Date; } set { Order.Date = value; } }

        internal int Amount { get { return Order.Amount; } set { Order.Amount = value; } }

        internal ReadOnlyCollection<CclContProductOrder> Products { get { return I_liProducts.AsReadOnly(); } }

        #endregion Properties#

        //public CclSvcOrder(CclContUserData _clUser)
        //{
        //    User = _clUser ?? throw new ArgumentNullException("Der Benutzer ist nicht initialisiert.");
        //    Order.UserID = User.ID;
        //}

        // Fügt ein Produkt zur Bestellung hinzu
        public void AddProduct(CclRecProductData _clRecData, CclRecProductOrder _clRecOrder)
        {
            var product = new CclContProductOrder(_clRecOrder, _clRecData, this);   

            I_liProducts.Add(product);
        }

        // Entfernt ein Produkt aus der Bestellung
        public void RemoveProduct(CclContProductOrder _clProduct)
        {
            I_liProducts.Remove(_clProduct);
        }


    }
}
